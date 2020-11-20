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

    public partial class TabHeroTraits : DarkUI.Docking.DarkDocument, ITab
    {
        public Hero selHero => Coordinator?.Hero;

        public TabHeroTraits()
        {
            InitializeComponent();
        }

        public MBCoordinator Coordinator { get; set; }

        void ITab.InitializeTab()
        {
            MBEditor.Log.Debug("Initializing Trait Tab");
            InitListControls();
        }

        void ITab.Activate()
        {
            MBEditor.Log.Debug("Activating Trait Tab");
            this.InitializeAutoSize();
            Reload();
        }

        void ITab.AfterLoad()
        {
        }

        void ITab.Deactivate()
        {
            MBEditor.Log.Debug("Deactivating Trait Tab");
        }

        private void InitListControls()
        {
            this.lstItems.DefaultList();
            this.lstItems.MultiSelect = false;
            lstItems.ShowGroups = false;

            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Trait", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 80, Width = 160,
                AspectGetter = item => ((TraitObject)item).Name?.ToString(),
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Value", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = true,
                AspectGetter = item => selHero?.GetTraitLevel((TraitObject)item) ,
                AspectPutter = (item, value) => selHero?.SetTraitLevel((TraitObject)item, Math.Max(int.MinValue, Math.Min(int.MaxValue, Convert.ToInt32(value))))
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Hidden", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((TraitObject)item).IsHidden
            });
            lstItems.Columns.Clear();
            lstItems.Columns.AddRange(lstItems.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());
            lstItems.CellEditStarting += MBEditor.Extensions.DarkUI_ObjectList_CellEditStarting;
            lstItems.CellEditFinishing += MBEditor.Extensions.DarkUI_ObjectList_CellEditFinishing;

            UpdateList(full: true);
        }
        private void Reload()
        {
            this.UpdateList();
        }

        private void UpdateList(bool full = false)
        {
            var values = TraitObject.All.ToArray();
            if (full)
                this.lstItems.SetObjects(values);
            this.lstItems.UpdateObjects(values);
        }

    }
}
