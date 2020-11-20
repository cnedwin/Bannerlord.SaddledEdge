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


    public partial class TabHeroPerks : DarkUI.Docking.DarkDocument, ITab
    {
        public Hero selHero => Coordinator?.Hero;

        public TabHeroPerks()
        {
            InitializeComponent();
        }

        public MBCoordinator Coordinator { get; set; }

        void ITab.InitializeTab()
        {
            MBEditor.Log.Debug("Initializing Perk Tab");
            InitListControls();
        }

        void ITab.Activate()
        {
            MBEditor.Log.Debug("Activating Perk Tab");
            this.InitializeAutoSize();
            Reload();
        }

        void ITab.AfterLoad()
        {
        }

        void ITab.Deactivate()
        {
            MBEditor.Log.Debug("Deactivating Perk Tab");
        }

        private void InitListControls()
        {
            this.lstItems.DefaultList();
            this.lstItems.MultiSelect = false;
            lstItems.ShowGroups = false;

            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "技巧", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 80, Width = 160,
                AspectGetter = item => ((PerkObject)item).Name?.ToString(),
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "数值", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = true,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => selHero?.GetPerkValue(((PerkObject)item)) ,
                AspectPutter = (item, value) => selHero?.SetPerkValue(((PerkObject)item), Convert.ToBoolean(value))
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "技能", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, Width = 80,
                AspectGetter = item => ((PerkObject)item).Skill?.Name?.ToString(),
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "技能数值", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false,
                AspectGetter = item => ((PerkObject)item).RequiredSkillValue,
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "学习条件", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => selHero?.GetSkillValue(((PerkObject)item).Skill) >= ((PerkObject)item).RequiredSkillValue,
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "1st Bonus", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, Width = 80,
                AspectGetter = item => ((PerkObject)item).PrimaryRole,
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "1st Bonus Value", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = false,
                AspectGetter = item => ((PerkObject)item).PrimaryBonus,
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "2nd Bonus", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, Width = 80,
                AspectGetter = item => ((PerkObject)item).SecondaryRole,
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "2nd Bonus Value", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = false,
                AspectGetter = item => ((PerkObject)item).SecondaryBonus,
            });

            lstItems.Columns.Clear();
            lstItems.Columns.AddRange(lstItems.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());
            UpdateList(full: true);
        }

        private void Reload()
        {
            this.UpdateList();
        }

        private void UpdateList(bool full = false)
        {
            var values = PerkObject.All.OrderBy(x=>x.Skill.Name.ToString()).ThenBy(x=>x.RequiredSkillValue).ToArray();
            if (full)
                this.lstItems.SetObjects(values);
            this.lstItems.UpdateObjects(values);
        }

    }
}
