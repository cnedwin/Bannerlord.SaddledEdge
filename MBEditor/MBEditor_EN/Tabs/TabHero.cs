using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace MBEditor.Tabs
{
    using TaleWorlds.CampaignSystem;
    using TaleWorlds.Core;
    using TaleWorlds.Library;
    using BrightIdeasSoftware;
    using DarkUI;
    using MBEditor.Tabs.HeroTab;

    public partial class TabHero : DarkUI.Docking.DarkDocument, ITab, IStateSerializer
    {
        private bool _disableEvents = false;
        private MBEditor.Tabs.HeroTab.TabHeroMain mainInfo;
        public MBCoordinator HeroCoordinator;

        public Hero Player => Coordinator?.Hero;

        public TabHero()
        {
            InitializeComponent();
        }

        public MBCoordinator Coordinator { get; set; }

        void ITab.InitializeTab()
        {
            //this.SuspendLayout();
            MBEditor.Log.Debug("Initializing NPC Tab");
            InitListControls();
            InitMainPanel();
            InitAttrPanel();
            InitHeroPanel();
            HeroCoordinator.DataChanged += HeroInfoDataChanged;

            //this.ResumeLayout();
            //this.mainInfo.Scale(0.75f);
            this.mainInfo.PerformAutoScale();
        }

        private void InitHeroPanel()
        {
            this.HeroCoordinator = new MBCoordinator() {Hero = this.lstCompanions.SelectedObject as Hero, Control = this.DockPanel};
            this.mainInfo.Coordinator = this.HeroCoordinator;
            ((ITab) this.mainInfo).InitializeTab();
        }

        void ITab.Activate()
        {
            MBEditor.Log.Debug("Activating NPC Tab");
            this.InitializeAutoSize();
            Reload();
        }

        void ITab.AfterLoad()
        {
        }

        void ITab.Deactivate()
        {
            MBEditor.Log.Debug("Deactivating NPC Tab");
        }

        private const System.Reflection.BindingFlags privatePropertyFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
        private const System.Reflection.BindingFlags publicPropertyFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public;
        private static string BackingField(string name) => $"<{name}>k__BackingField";


        private void InitListControls()
        {
            this.lstCompanions.DefaultList();
            this.lstCompanions.MultiSelect = false;

            lstCompanions.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
            lstCompanions.ShowGroups = false;
            olvNPCName.Width = 350;
            olvNPCName.AspectName = null;
            olvNPCName.AspectGetter = item => ((Hero)item).Name?.ToString();
            olvNPCName.IsEditable = false;
            lstCompanions.AllColumns.Add(new OLVColumn
            {
                Text = "Clan",IsVisible = false,TextAlign = HorizontalAlignment.Center,IsEditable = false,MinimumWidth = 80,Width = 100,
                AspectGetter = item => ((Hero)item).Clan?.Name?.ToString() ?? "<None>",
            });

            lstCompanions.AllColumns.Add(new OLVColumn
            {
                Text = "Age",IsVisible = true,TextAlign = HorizontalAlignment.Center,IsEditable = true,Width = 60,
                AspectGetter = item => (int)((Hero)item).BirthDay.ElapsedYearsUntilNow,
            });
            lstCompanions.AllColumns.Add(new OLVColumn
            {
                Text = "Relations",IsVisible = false,TextAlign = HorizontalAlignment.Center,IsEditable = true,Width = 60,
                AspectGetter = item => ((Hero)item).GetRelation(this.Coordinator.Hero),
                AspectPutter = (item, value) => { ((Hero)item).SetPersonalRelation(this.Coordinator.Hero, Convert.ToInt32(value)); }
            }); ;
            lstCompanions.AllColumns.Add(new OLVColumn
            {
                Text = "Companion", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false,Width = 140,
                AspectGetter = item => ((Hero)item).CompanionOf?.Name?.ToString() ?? "",
            });
            lstCompanions.AllColumns.Add(new OLVColumn {
                Text = "Controversy", IsVisible = false, TextAlign = HorizontalAlignment.Center,IsEditable = false,Width = 60,
                AspectGetter = item => ((Hero)item).Controversy,
            });
            lstCompanions.AllColumns.Add(new OLVColumn {
                Text = "Settlement", IsVisible = true,TextAlign = HorizontalAlignment.Center, IsEditable = false, MinimumWidth = 80, Width = 160,
                AspectGetter = item => ((Hero)item).CurrentSettlement?.Name?.ToString(),
            });
            lstCompanions.AllColumns.Add(new OLVColumn {
                Text = "LastSeen", IsVisible = false, TextAlign = HorizontalAlignment.Center, IsEditable = false, MinimumWidth = 80, Width = 100,
                AspectGetter = item => ((Hero)item).LastSeenPlace?.Name?.ToString(),
            });
            lstCompanions.AllColumns.Add(new OLVColumn {
                Text = "IsDead", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false,Width = 90,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((Hero)item).IsDead,
            });
            lstCompanions.AllColumns.Add(new OLVColumn {
                Text = "IsLeader", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false,Width = 100,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((Hero)item).IsFactionLeader,
            });
            lstCompanions.CellEditStarting += MBEditor.Extensions.DarkUI_ObjectList_CellEditStarting;
            lstCompanions.CellEditFinishing += MBEditor.Extensions.DarkUI_ObjectList_CellEditFinishing;
            lstCompanions.Columns.Clear();
            lstCompanions.Columns.AddRange(lstCompanions.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());

            lstCompanions.AllColumns.First(x => x.Text == "IsDead").ValuesChosenForFiltering = new List<bool> { false }; // remove dead people
            this.lstCompanions.UpdateColumnFiltering();
        }

        private void HeroInfoDataChanged(object sender, EventArgs e)
        {
            if (_disableEvents) return;
            this.lstCompanions.UpdateObject(this.HeroCoordinator.Hero);
        }

        private void InitMainPanel()
        {
            this.mainInfo = new MBEditor.Tabs.HeroTab.TabHeroMain();
            this.splVertical.Panel1.Controls.Add(this.mainInfo);
            // 
            // mainInfo
            // 
            this.mainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainInfo.Location = new System.Drawing.Point(0, 0);
            this.mainInfo.Name = "mainInfo";
            this.mainInfo.Size = new System.Drawing.Size(611, 343);
            this.mainInfo.TabIndex = 0;

            this.splHorizontal.SplitterDistance = this.splHorizontal.Width * 60 / 100;
            this.splVertical.SplitterDistance = this.splVertical.Height * 33 / 100;
        }
        private void InitAttrPanel()
        {
            //var content = new TabHeroMain() { DockText = "Hero Attributes" };
            //DockPanel.AddContent(content);

            var attrs = new TabHeroAttrs() { DockText = "Attributes"};
            DockPanel.AddContent(attrs);
            DockPanel.AddContent(new TabHeroPerks() { DockText = "Perks"}, attrs.DockGroup);
            DockPanel.AddContent(new TabHeroSkills() { DockText = "Skills"}, attrs.DockGroup);
            DockPanel.AddContent(new TabHeroTraits() { DockText = "Traits"}, attrs.DockGroup);
            DockPanel.AddContent(new TabHeroRelations() { DockText = "Relations" }, attrs.DockGroup);
            //DockPanel.AddContent(new TabHeroProps() { DockText = "Detail" }, attrs.DockGroup);

            //DockPanel.ActiveContent = content; // main document
            DockPanel.ActiveContent = attrs; // attributes
            DockPanel.CloseButtonEnabled = false;
        }

        private void Reload()
        {
            if (_disableEvents) return;

            bool disableEvents = _disableEvents;
            _disableEvents = true;
            try {
                
                if (this.Player != null) {
                    this.UpdateCharacterList();
                    if (HeroCoordinator.Hero == null)
                        HeroCoordinator.Hero = Player;

                    ((ITab) this.mainInfo).Activate();
                } else {
                    HeroCoordinator.Hero = null;
                    ((ITab) this.mainInfo).Deactivate();
                }
            }
            catch (Exception e) {
                Log.Debug(e.ToString());
            }
            finally {
                _disableEvents = disableEvents;
            }
        }

        private void UpdateCharacterList()
        {
            //this.lstCompanions.BeginUpdate();

            var selection = this.lstCompanions.SelectedObject;
            var items = new List<Hero>();
            items.Add(this.Player);
            if (this.Player.Spouse != null)
                items.Add(this.Player.Spouse);
            items.AddRange(this.Player.Children.Except(items).ToArray());
            items.AddRange(this.Player.Siblings.Except(items).ToArray());
            items.AddRange(this.Player.CompanionsInParty.Except(items).ToArray());

            var all_items = ObjectCache.GetObjectTypeList<Hero>();
            items.AddRange(all_items.Where(x=> x.Clan == Player.Clan).Except(items).ToArray()  );

            this.lstCompanions.SetObjects(items, true);
            //this.lstCompanions.EndUpdate();
            if (selection != null && items.Contains(selection))
                this.lstCompanions.SelectedObject = selection;
        }

        private void lstCompanions_SelectionChanged(object sender, EventArgs e)
        {
            var disableEvents = _disableEvents;
            _disableEvents = true;
            try {

                var newhero = this.lstCompanions.SelectedObject as Hero;
                var oldhero = HeroCoordinator?.Hero;

                if (newhero != oldhero) {
                    HeroCoordinator.Hero = newhero;
                    ((ITab) this.mainInfo).Activate();
                }
            }
            catch (Exception exception) {
                Log.Debug(exception.ToString());
            }
            finally {
                _disableEvents = disableEvents;
            }
        }

        public string SettingsName => "Hero";
        public JObject SaveSettings()
        {
            var objctrl = new JObject();
            if (lstCompanions.TryGetJsonSettings(out var items))
                objctrl.Add("Items", items);
            if (splHorizontal.TryGetJsonSettings(out var width))
                objctrl.Add("HorizSplit", width);
            if (splVertical.TryGetJsonSettings(out var vert))
                objctrl.Add("VertSplit", vert);
            return objctrl;
        }

        public void ReadSettings(JToken objctrl)
        {
            splHorizontal.ApplyJsonSettings(objctrl["HorizSplit"]);
            splVertical.ApplyJsonSettings(objctrl["VertSplit"]); ;
            lstCompanions.ApplyJsonSettings(objctrl["Items"]);
        }
    }
}
