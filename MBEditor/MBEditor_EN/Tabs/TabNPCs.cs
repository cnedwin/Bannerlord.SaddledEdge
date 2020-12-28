using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MBEditor.Tabs.HeroTab;
using Newtonsoft.Json.Linq;
using TaleWorlds.MountAndBlade;

namespace MBEditor.Tabs
{
    using TaleWorlds.CampaignSystem;
    using TaleWorlds.Core;
    using TaleWorlds.Library;
    using DarkUI;
    using BrightIdeasSoftware;
    using Helpers;

    public partial class TabNPCs : DarkUI.Docking.DarkDocument, ITab, IStateSerializer
    {
        private bool _disableEvents;
        public TabNPCs()
        {
            InitializeComponent();
        }

        public Hero Player => Coordinator?.Hero;
        public MBCoordinator Coordinator { get; set; }


        private TabHeroMain mainInfo;
        public MBCoordinator HeroCoordinator = new MBCoordinator() { Hero = null, Control = null};


        void ITab.InitializeTab()
        {
            MBEditor.Log.Debug("Initializing NPC Tab");
            InitializeNPCList();
            InitMainPanel();
            InitAttrPanel();
            InitHeroPanel();
            this.splitContainer1.SplitterDistance = this.splitContainer1.Width * 70 / 100;
            //this.splitContainer1.Panel2Collapsed = true;
            this.splVertical.SplitterDistance = this.splVertical.Height * 40 / 100;
            this.HeroCoordinator.DataChanged += HeroInfoDataChanged;
            this.darkPropertyGrid1.CellEditFinished += (sender, args) => HeroInfoDataChanged(null, EventArgs.Empty);
        }

        private void HeroInfoDataChanged(object sender, EventArgs e)
        {
            if (_disableEvents) return;
            this.lstNPCs.UpdateObject( this.HeroCoordinator.Hero );
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


        private void InitializeNPCList()
        {
            this.lstNPCs.DefaultList();
            this.lstNPCs.MultiSelect = false;

            olvNPCName.Width = 275;
            olvNPCName.AspectName = null;
            olvNPCName.AspectGetter = item => ((Hero)item).Name?.ToString();
            olvNPCName.IsEditable = false;
            lstNPCs.AllColumns.Add(new OLVColumn
            {
                Text = "Clan",IsVisible = true,TextAlign = HorizontalAlignment.Center,IsEditable = false,MinimumWidth = 80,Width = 160,
                AspectGetter = item => ((Hero)item).Clan?.Name?.ToString() ?? "<None>",
            });

            lstNPCs.AllColumns.Add(new OLVColumn
            {
                Text = "Age",IsVisible = true,TextAlign = HorizontalAlignment.Center,IsEditable = true, Width = 80,
                AspectGetter = item => (int)((Hero)item).BirthDay.ElapsedYearsUntilNow,
            });
            lstNPCs.AllColumns.Add(new OLVColumn
            {
                Text = "Relations", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = true, Width = 90,
                AspectGetter = item => ((Hero)item).GetRelation(this.Coordinator.Hero),
                AspectPutter = (item, value) => { ((Hero)item).SetPersonalRelation(this.Coordinator.Hero, Convert.ToInt32(value)); }
            });
            lstNPCs.AllColumns.Add(new OLVColumn {
                Text = "Renown", IsVisible = false, TextAlign = HorizontalAlignment.Right, IsEditable = true, Width = 60,
                AspectGetter = item => (decimal)(((Hero)item).Clan?.Renown ?? 0.0f),
                AspectPutter = (item, value) => {
                    if (((Hero)item).Clan == null) return;
                    ((Hero)item).Clan.Renown = Math.Max(-999999.0f, Convert.ToSingle(value)); },
            });
            lstNPCs.AllColumns.Add(new OLVColumn {
                Text = "Influence", IsVisible = false, TextAlign = HorizontalAlignment.Right, IsEditable = true, Width = 60,
                AspectGetter = item => (decimal)(((Hero)item).Clan?.Influence ?? 0.0f),
                AspectPutter = (item, value) => {
                    if (((Hero)item).Clan == null) return;
                    ((Hero)item).Clan.Influence = Math.Max(-999999.0f, Convert.ToSingle(value)); },
            });
            lstNPCs.AllColumns.Add(new OLVColumn
            {
                Text = "Companion", IsVisible = false, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                AspectGetter = item => ((Hero)item).CompanionOf?.Name?.ToString() ?? "",
            });
            lstNPCs.AllColumns.Add(new OLVColumn {
                Text = "Controversy", IsVisible = false, TextAlign = HorizontalAlignment.Center,IsEditable = false, Width = 60,
                AspectGetter = item => ((Hero)item).Controversy,
            });
            lstNPCs.AllColumns.Add(new OLVColumn {
                Text = "Settlement", IsVisible = false,TextAlign = HorizontalAlignment.Center, IsEditable = false, MinimumWidth = 80, Width = 100,
                AspectGetter = item => ((Hero)item).CurrentSettlement?.Name?.ToString(),
            });
            lstNPCs.AllColumns.Add(new OLVColumn {
                Text = "LastSeen", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, MinimumWidth = 80, Width = 140,
                AspectGetter = item => ((Hero)item).LastSeenPlace?.Name?.ToString(),
            });
            lstNPCs.AllColumns.Add(new OLVColumn {
                Text = "IsDead", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 80,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((Hero)item).IsDead,
            });
            lstNPCs.AllColumns.Add(new OLVColumn {
                Text = "IsLeader", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 100,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((Hero)item).IsFactionLeader,
            });
            lstNPCs.AllColumns.Add(new OLVColumn {
                Text = "Trade Gold", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = true, Width = 90,
                AspectGetter = item => ((Hero)item).Gold,
                AspectPutter = (item, value) => { ((Hero)item).Gold = Math.Max(0, Convert.ToInt32(value)); },
            });
            lstNPCs.AllColumns.Add(new OLVColumn
            {
                Text = "Target", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, MinimumWidth = 80,
                Renderer = new DarkUI.Support.ColumnButtonRenderer(), IsButton = true,
                AspectGetter = item => "Target"
            });
            lstNPCs.AllColumns.Add(new OLVColumn
            {
                Text = "Teleport", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, MinimumWidth = 80,
                Renderer = new DarkUI.Support.ColumnButtonRenderer(), IsButton = true,
                AspectGetter = item => "Teleport"
            });
            lstNPCs.Columns.Clear();
            lstNPCs.Columns.AddRange(lstNPCs.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());

            //lstNPCs.CellEditStarting += LstNPCs_CellEditStarting;
            lstNPCs.CellEditStarting += MBEditor.Extensions.DarkUI_ObjectList_CellEditStarting;
            lstNPCs.CellEditFinishing += MBEditor.Extensions.DarkUI_ObjectList_CellEditFinishing;
            lstNPCs.ButtonClick += LstNPCs_ButtonClick;

            lstNPCs.AllColumns.First(x => x.Text == "IsDead").ValuesChosenForFiltering = new List<bool> { false }; // remove dead people
            this.lstNPCs.UpdateColumnFiltering();
        }

        private void LstNPCs_ButtonClick(object sender, CellClickEventArgs e)
        {
            if (e.Column.Text == "Target")
            {
                var other = (Hero)e.Model;
                if (other.PartyBelongedTo != null)
                {
                    Player.PartyBelongedTo.SetMoveEngageParty(other.PartyBelongedTo);
                }
                else if (other.CurrentSettlement != null)
                {
                    var settle = other.CurrentSettlement;
                    Player.PartyBelongedTo.SetMoveGoToSettlement(settle);
                }
                var form = this.FindForm();
                if (form != null) form.Visible = false;
            }
            else if (e.Column.Text == "Teleport")
            {
                var other = (Hero)e.Model;
                if (other.CurrentSettlement != null)
                {
                    var settle = other.CurrentSettlement;
                    Player.PartyBelongedTo.Position2D = MobilePartyHelper.FindReachablePointAroundPosition(partyBase,settle.GatePosition, 4f, 3f, false);

                    Player.PartyBelongedTo.SetMoveGoToSettlement(settle);
                } else if(other.PartyBelongedTo != null) {
                    Player.PartyBelongedTo.Position2D = MobilePartyHelper.FindReachablePointAroundPosition(partyBase, other.GetMapPoint().Position2D, 4f, 3f, false);
                    Player.PartyBelongedTo.SetMoveEngageParty(other.PartyBelongedTo);
                }
                var form = this.FindForm();
                if (form != null) form.Visible = false;
            }
        }

        private void LstNPCs_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (!e.Column.CheckBoxes && !(e.Column.Renderer is DarkUI.Support.CheckStateRenderer))
            {
                e.AutoDispose = true;
                e.Control = new DarkUI.Controls.DarkNumericUpDown { Bounds = e.CellBounds }.DefaultEditor(e.Value);
            }
        }

        private void UpdateNPCList(bool full = false)
        {
            var lastSel = this.lstNPCs.SelectedObject;
            var items = ObjectCache.GetObjectTypeList<Hero>();
            var new_items = items.OrderByDescending(x => x.Clan == Clan.PlayerClan)
                .ThenBy(x => x.Clan?.Name?.ToString() ?? "")
                .ThenByDescending(x => x.IsFactionLeader)
                .ThenBy(x => x.Name.ToString())
                .ToArray();

            this.lstNPCs.SetObjects(new_items, true);
            this.lstNPCs.UpdateColumnFiltering();
            this.lstNPCs.SelectedObject = lastSel;
        }

        private void lstNPCs_SelectionChanged(object sender, EventArgs e)
        {
            var disableEvents = _disableEvents;
            _disableEvents = true;
            try {

                var obj = lstNPCs.SelectedObject;
                if (tabStripDetail.SelectedTab == tabNPCDetail)
                    this.darkPropertyGrid1.SetObject(obj);
                else
                    this.darkPropertyGrid1.SetObject(null);

                //this.splitContainer1.Panel2Collapsed = (obj == null);

                var newhero = obj as Hero;
                var oldhero = HeroCoordinator?.Hero;
                if (newhero != oldhero) {
                    HeroCoordinator.Hero = newhero;
                    ((ITab) this.mainInfo).Activate();
                }
            } catch (Exception ex) {
                Log.Debug(ex.ToString());
            }
            finally
            {
                _disableEvents = disableEvents;
            }
        }

        private void tabStripDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabStripDetail.SelectedTab == tabNPCDetail)
            {
                var obj = lstNPCs.SelectedObject;
                this.darkPropertyGrid1.SetObject(obj);
            }
        }

        private void InitMainPanel()
        {
            this.mainInfo = new TabHeroMain();
            this.splVertical.Panel1.Controls.Add(this.mainInfo);
            // 
            // mainInfo
            // 
            this.mainInfo.Dock = DockStyle.Fill;
            this.mainInfo.Location = new System.Drawing.Point(0, 0);
            this.mainInfo.Name = "mainInfo";
            this.mainInfo.Size = new System.Drawing.Size(611, 343);
            this.mainInfo.TabIndex = 0;

        }
        private void InitAttrPanel()
        {
            var attrs = new TabHeroAttrs() { DockText = "Attributes" };
            dockPanel.AddContent(attrs);
            dockPanel.AddContent(new TabHeroPerks() { DockText = "Perks" }, attrs.DockGroup);
            dockPanel.AddContent(new TabHeroSkills() { DockText = "Skills" }, attrs.DockGroup);
            dockPanel.AddContent(new TabHeroTraits() { DockText = "Traits" }, attrs.DockGroup);
            dockPanel.AddContent(new TabHeroRelations() { DockText = "Relations" }, attrs.DockGroup);

            //dockPanel.ActiveContent = content; // main document
            dockPanel.ActiveContent = attrs; // attributes
            dockPanel.CloseButtonEnabled = false;
        }


        private void InitHeroPanel()
        {
            this.HeroCoordinator = new MBCoordinator() { Hero = this.lstNPCs.SelectedObject as Hero, Control = this.dockPanel };
            this.mainInfo.Coordinator = this.HeroCoordinator;
            ((ITab)this.mainInfo).InitializeTab();
        }
        private void Reload()
        {
            if (_disableEvents) return;
            var disableEvents = _disableEvents;
            _disableEvents = true;
            try {
                if (this.Player != null)
                {
                    this.UpdateNPCList();
                    if (HeroCoordinator.Hero == null)
                        HeroCoordinator.Hero = Player;

                    ((ITab)this.mainInfo).Activate();
                }
                else
                {
                    HeroCoordinator.Hero = null;
                    ((ITab)this.mainInfo).Deactivate();
                }
            }
            catch (Exception ex) {
                Log.Debug(ex.ToString());
            }
            finally {
                _disableEvents = disableEvents;
            }
        }

        public string SettingsName => "NPCs";

        public PartyBase partyBase { get; private set; }

        public JObject SaveSettings()
        {
            var objctrl = new JObject();
            if (lstNPCs.TryGetJsonSettings(out var items))
                objctrl.Add("Items", items);
            if (splitContainer1.TryGetJsonSettings(out var width))
                objctrl.Add("HorizSplit", width);
            if (splVertical.TryGetJsonSettings(out var vert))
                objctrl.Add("VertSplit", vert);
            return objctrl;
        }

        public void ReadSettings(JToken objctrl)
        {
            splitContainer1.ApplyJsonSettings(objctrl["HorizSplit"]);
            splVertical.ApplyJsonSettings(objctrl["VertSplit"]); ;
            lstNPCs.ApplyJsonSettings(objctrl["Items"]);
        }
    }
}
