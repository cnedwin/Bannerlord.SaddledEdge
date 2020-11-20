using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MBEditor.Tabs.HeroTab
{
    using TaleWorlds.CampaignSystem;
    using TaleWorlds.Core;
    using TaleWorlds.Library;
    using BrightIdeasSoftware;
    using DarkUI;

    public partial class TabHeroRelations : DarkUI.Docking.DarkDocument, ITab
    {
        public Hero selHero => Coordinator?.Hero;

        public TabHeroRelations()
        {
            InitializeComponent();
        }

        public MBCoordinator Coordinator { get; set; }

        void ITab.InitializeTab()
        {
            MBEditor.Log.Debug("Initializing Relation Tab");
            InitListControls();
        }

        void ITab.Activate()
        {
            MBEditor.Log.Debug("Activating Relation Tab");
            this.InitializeAutoSize();
            Reload();
        }

        void ITab.AfterLoad()
        {
        }

        void ITab.Deactivate()
        {
            MBEditor.Log.Debug("Deactivating Relation Tab");
        }

        private void InitListControls()
        {
            this.lstItems.DefaultList();
            this.lstItems.MultiSelect = false;
            lstItems.ShowGroups = false;

            var player = (Game.Current?.PlayerTroop as CharacterObject).HeroObject;

            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "姓名",IsVisible = true,TextAlign = HorizontalAlignment.Left,IsEditable = false,MinimumWidth = 80,Width = 100,
                AspectGetter = item => ((Hero)item).Name?.ToString() ?? "<None>",
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "氏族",IsVisible = true,TextAlign = HorizontalAlignment.Center,IsEditable = false,MinimumWidth = 80,Width = 100,
                AspectGetter = item => ((Hero)item).Clan?.Name?.ToString() ?? "<None>",
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "关系", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = true,
                AspectGetter = item => ((Hero)item).GetRelation(this.Coordinator.Hero ?? player),
                AspectPutter = (item, value) => { ((Hero)item).SetPersonalRelation(this.Coordinator.Hero?? player, Convert.ToInt32(value)); }
            });
            lstItems.AllColumns.Add(new OLVColumn {
                Text = "领袖", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((Hero)item).IsFactionLeader,
            });
            lstItems.Columns.Clear();
            lstItems.Columns.AddRange(lstItems.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());
            lstItems.CellEditStarting += MBEditor.Extensions.DarkUI_ObjectList_CellEditStarting;
            lstItems.CellEditFinishing += MBEditor.Extensions.DarkUI_ObjectList_CellEditFinishing;
        }
        private void Reload()
        {
            this.UpdateList();
        }

        private void UpdateList(bool full = false)
        {
            var lastSel = this.lstItems.SelectedObject;
            var items = ObjectCache.GetObjectTypeList<Hero>();
            var new_items = items.OrderByDescending(x => x.Clan == Clan.PlayerClan)
                .ThenByDescending(x => x.IsFactionLeader)
                .ThenBy(x => x.Clan?.Name?.ToString())
                .ThenBy(x => x.Name.ToString())
                .ToArray();

            this.lstItems.SetObjects(new_items, true);
            this.lstItems.UpdateColumnFiltering();
            this.lstItems.SelectedObject = lastSel;

        }

    }
}
