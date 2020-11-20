using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MBEditor.Tabs.HeroTab
{
    using TaleWorlds.CampaignSystem;
    using TaleWorlds.Core;
    using TaleWorlds.Library;
    using BrightIdeasSoftware;
    using DarkUI;

    public partial class TabHeroSkills : DarkUI.Docking.DarkDocument, ITab
    {
        const int MaxFocus = 5;
        public Hero selHero => Coordinator?.Hero;

        public TabHeroSkills()
        {
            InitializeComponent();
        }

        public MBCoordinator Coordinator { get; set; }

        void ITab.InitializeTab()
        {
            MBEditor.Log.Debug("Initializing Skill Tab");
            InitListControls();
        }

        void ITab.Activate()
        {
            MBEditor.Log.Debug("Activating Skill Tab");
            this.InitializeAutoSize();
            Reload();
        }

        void ITab.AfterLoad()
        {
        }

        void ITab.Deactivate()
        {
            MBEditor.Log.Debug("Deactivating Skill Tab");
        }

        private void InitListControls()
        {
            this.lstItems.DefaultList();
            this.lstItems.MultiSelect = false;
            lstItems.ShowGroups = false;

            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Skill", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 80, Width = 160,
                AspectGetter = item => ((SkillObject)item).Name?.ToString(),
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Value", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = true,
                AspectGetter = item => selHero?.GetSkillValue((SkillObject)item) ,
                AspectPutter = (item, value) => {
                    if (selHero == null || item == null) return;
                    var oldlevel = selHero.GetSkillValue((SkillObject) item);
                    var level = Math.Max(0, Math.Min(0x3ff, Convert.ToInt32(value)));
                    if (oldlevel == level) return;
                    selHero.SetSkillValue((SkillObject)item, level);
                    int lowerxp = Campaign.Current.Models.CharacterDevelopmentModel.GetXpRequiredForSkillLevel(level);
                    int upperxp = Campaign.Current.Models.CharacterDevelopmentModel.GetXpRequiredForSkillLevel(level + 1)-1;
                    var xp = (level > oldlevel || upperxp <= lowerxp) ? lowerxp : (upperxp + lowerxp) / 2;
                    selHero.HeroDeveloper.SetPropertyValue((SkillObject) item, (float)xp);

                    var dev = selHero.HeroDeveloper;
                    var checkLevel = dev.GetType().GetMethod("CheckLevel", BindingFlags.Instance | BindingFlags.NonPublic, 
                        null, new[] {typeof(bool)}, new ParameterModifier[0]);
                    if (checkLevel != null)
                        checkLevel.Invoke(dev, new object[] {true});
                    Coordinator.InvokeDataChange<SkillChangeArgs>();
                }
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Focus", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = true,
                AspectGetter = item => selHero?.HeroDeveloper?.GetFocus((SkillObject)item),
                AspectPutter = (item, value) => {
                    var dev = selHero?.HeroDeveloper;
                    if (dev == null) return;
                    var curval = dev.GetFocus((SkillObject)item);
                    var newval = Math.Max(0, Math.Min(MaxFocus, Convert.ToInt32(value)));
                    selHero?.HeroDeveloper?.AddFocus((SkillObject)item, newval - curval, false);
                }
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Xp", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = true, Width = 120,
                AspectGetter = item => selHero?.HeroDeveloper.GetPropertyValue((SkillObject)item) ,
                AspectPutter = (item, value) => selHero?.HeroDeveloper.SetPropertyValue((SkillObject)item, Math.Max(0, Math.Min((float)int.MaxValue, Convert.ToSingle(value))))
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Lower Xp", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = false, Width = 120,
                AspectGetter = item => Campaign.Current.Models.CharacterDevelopmentModel.GetXpRequiredForSkillLevel( selHero?.GetSkillValue((SkillObject)item) ?? 0 ),
            });
            lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Upper Xp", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = false, Width = 120,
                AspectGetter = item => Campaign.Current.Models.CharacterDevelopmentModel.GetXpRequiredForSkillLevel( (selHero?.GetSkillValue((SkillObject)item) ?? 0) + 1 ),
            });
            lstItems.Columns.Clear();
            lstItems.Columns.AddRange(lstItems.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());
            lstItems.CellEditStarting += LstItems_CellEditStarting;
            lstItems.CellEditFinishing += LstItems_CellEditFinishing; ;

            UpdateList(full: true);
        }

        private void LstItems_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (!e.Column.CheckBoxes && !(e.Column.Renderer is DarkUI.Support.CheckStateRenderer))
            {
                e.Control = null;
            }
        }

        private void LstItems_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (!e.Column.CheckBoxes && !(e.Column.Renderer is DarkUI.Support.CheckStateRenderer))
            {
                e.AutoDispose = false;
                e.Control = new DarkUI.Controls.DarkNumericUpDown { Bounds = e.CellBounds }.DefaultEditor(e.Value);
            }
        }

        private void Reload()
        {
            this.UpdateList();
        }

        private void UpdateList(bool full = false)
        {
            var values = SkillObject.All;
            if (full)
                this.lstItems.SetObjects(values);
            this.lstItems.UpdateObjects(values);
        }

    }
}
