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

    public partial class TabHeroAttrs : DarkUI.Docking.DarkDocument, ITab
    {
        public Hero selHero => Coordinator?.Hero;

        public TabHeroAttrs()
        {
            InitializeComponent();
        }

        public MBCoordinator Coordinator { get; set; }

        void ITab.InitializeTab()
        {
            MBEditor.Log.Debug("Initializing Attribute Tab");
            InitListControls();
        }

        void ITab.Activate()
        {
            MBEditor.Log.Debug("Activating Attribute Tab");
            this.InitializeAutoSize();
            Reload();
        }

        void ITab.AfterLoad()
        {
        }

        void ITab.Deactivate()
        {
            MBEditor.Log.Debug("Deactivating Attribute Tab");
        }

        private void InitListControls()
        {
            this.lstItems.DefaultList();
            this.lstItems.MultiSelect = false;
            lstItems.ShowGroups = false;
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "属性", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 80, Width = 160,
                AspectGetter = item => Enum.GetName(typeof(CharacterAttributesEnum),Convert.ToInt32(item)),
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Value", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = true,
                AspectGetter = item => selHero?.GetAttributeValue((CharacterAttributesEnum)Convert.ToInt32(item)) ,
                AspectPutter = (item, value) => selHero?.SetAttributeValue((CharacterAttributesEnum)Convert.ToInt32(item), Math.Max(int.MinValue, Math.Min(int.MaxValue, Convert.ToInt32(value))))
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
            var excludes = new CharacterAttributesEnum[] { CharacterAttributesEnum.NumCharacterAttributes, CharacterAttributesEnum.End };
            var values = Enum.GetValues(typeof(CharacterAttributesEnum)).OfType<CharacterAttributesEnum>().Except(excludes).ToArray();
            if (full)
                this.lstItems.SetObjects(values);
            this.lstItems.UpdateObjects(values);
        }

    }
}
