using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace MBEditor.Tabs
{
    using TaleWorlds.CampaignSystem;
    using TaleWorlds.Core;
    using TaleWorlds.Library;
    using DarkUI;
    using DarkUI.Support;
    using BrightIdeasSoftware;

    public partial class TabParty : DarkUI.Docking.DarkDocument, ITab, IStateSerializer
    {
        private const string defaultNoneName = "<None>";
        private static string[] itemTypeNames = new string[] {
            "All", "Horse", "One Handed Weapons", "Two Handed Weapons", "Polearms", "Arrows", "Bolts", "Shields", "Bows", "Crossbows", "Thrown", "Goods", "Helmets", "Body Armor", "Leg Armor", "Hand Armor",
            "Pistols", "Muskets", "Bullets", "Animals", "Books", "Chest Armor", "Capes", "Horse Harnesses", "Banners"
        };
       

        public TabParty()
        {
            InitializeComponent();
        }
        public Hero Player => Coordinator?.Hero;

        public MBCoordinator Coordinator { get; set; }

        void ITab.InitializeTab()
        {
            MBEditor.Log.Debug("Initializing Party Tab");
            Initialize();
            InitializeKeys();
        }

        void ITab.Activate()
        {
            MBEditor.Log.Debug("Activating Party Tab");
            this.InitializeAutoSize();
            ReloadPlayer();
            ReloadMods();
            ReloadSeige();
            ReloadKeys();

            if (this.tabStripDetail.SelectedTab == tabDetail)
                this.darkPropertyGrid1.SetObject(Player);
        }

        void ITab.AfterLoad()
        {
        }

        void ITab.Deactivate()
        {
            MBEditor.Log.Debug("Deactivating Party Tab");
        }

        void Initialize()
        {
            InitializeItems();
            txtSiegeSettlement.ReadOnly = true;
        }

        private void ReloadPlayer()
        {
            this.numInvGold.DefaultEditor(this.Player.Gold);
            this.numInfluence.DefaultEditor(this.Player.Clan.Influence);
            this.numRenown.DefaultEditor(this.Player.Clan.Renown);
            this.numControversy.DefaultEditor(this.Player.Controversy);

            int prisoners = GetPrivateStaticField<int>(typeof(DefaultPartySizeLimitModel), "_additionalPrisonerSizeAsCheat");
            this.numMaxPartySize.DefaultEditor(GetPrivateStaticField<int>(typeof(DefaultPartySizeLimitModel), "_additionalPartySizeAsCheat"));
            this.numPartyMaxPrisoners.DefaultEditor(GetPrivateStaticField<int>(typeof(DefaultPartySizeLimitModel), "_additionalPrisonerSizeAsCheat"));

        }
        private static T GetPrivateField<T>(Object obj, string name)
        {
            if (obj == null) return default(T);
            return (T)obj.GetType().GetField(name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)?.GetValue(obj);
        }
        private static T GetPrivateStaticField<T>(Type type, string name)
        {
            return (T)type.GetField(name, System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)?.GetValue(null);
        }
        private static void SetPrivateStaticField<T>(Type type, string name, T value)
        {
            type.GetField(name, System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)?.SetValue(null, value);
        }
        

        private void ReloadSeige()
        {
            var siege = PlayerSiege.PlayerSiegeEvent;
#if !MBVER_010403
            //if (PlayerSiege.Current != null) return;
#endif
            if (PlayerSiege.PlayerSiegeEvent != null)
            {
                grpSiege.Enabled = true;
                txtSiegeSettlement.Enabled = true;
                txtSiegeSettlement.Text = siege.BesiegedSettlement.Name.ToString();
                chkPlayerSiege.Enabled = false;
                var attacking = siege.BesiegerCamp.IsBesiegerSideParty(Player.PartyBelongedTo);
                chkPlayerSiege.Checked = attacking;
                btnComplete.Enabled = attacking;

            }
            else
            {
                grpSiege.Enabled = false;
                txtSiegeSettlement.Text = "";
                txtSiegeSettlement.Enabled = false;
                chkPlayerSiege.Enabled = false;
                chkPlayerSiege.Checked = false;
                btnComplete.Enabled = false;
            }
        }

        private void numInvGold_ValueChanged(object sender, EventArgs e)
        {
            int curgold = this.Player.Gold;
            int newgold = (int)this.numInvGold.Value;
            int diff = newgold - curgold;
            this.Player.ChangeHeroGold(diff);
        }

        private void TabParty_Load(object sender, EventArgs e)
        {

        }


        private void InitializeItems()
        {
            this.lstInvMod.DefaultList();
            lstInvMod.AllColumns.Clear();
            lstInvMod.AllColumns.Add(new OLVColumn
            {
                Text = "Name", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, Width = 270, MinimumWidth = 80,
                AspectGetter = item => itemTypeNames[((int)item)],
            });
            lstInvMod.AllColumns.Add(new OLVColumn
            {
                Text = "Modifier", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = true, MinimumWidth = 150, Width = 270,
                AspectGetter = item => { this.Coordinator.State.ModDefaultDict.TryGetValue((ItemObject.ItemTypeEnum)item, out var mod); return mod ?? defaultNoneName; },
                AspectPutter = (item, value) => { },
            });
            lstInvMod.Columns.Clear();
            lstInvMod.Columns.AddRange(lstInvMod.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());
            lstInvMod.AutoSizeColumns();

            lstInvMod.CellEditStarting += lstInvMod_CellEditStarting;
            lstInvMod.CellEditFinishing += lstInvMod_CellEditFinishing;

            spltItems.SplitterDistance = spltItems.Width * 70 / 100;
        }

        private void ReloadMods()
        {

            var items = Enum.GetValues(typeof(ItemObject.ItemTypeEnum)).OfType<ItemObject.ItemTypeEnum>().Where(x=>x != ItemObject.ItemTypeEnum.Invalid);
            this.lstInvMod.SetObjects(items);
        }

        private void lstInvMod_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (e.Column.Text == "Modifier")
            {
                var cb = new DarkUI.Controls.DarkComboBox
                {
                    Bounds = e.CellBounds,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Sorted = false,
                };

                var modList = ObjectCache.GetObjectTypeList<ItemModifier>();
                cb.Items.Add(defaultNoneName);
                cb.Items.AddRange(modList.OrderBy(o=>o.StringId).Select(x=>x.StringId).ToArray());

                var lastSelIdx = (ItemObject.ItemTypeEnum)e.RowObject;
                var lastMod = defaultNoneName;
                if (!Coordinator.State.ModDefaultDict.TryGetValue(lastSelIdx, out lastMod))
                    lastMod = defaultNoneName;
                cb.SelectedIndex = cb.FindStringExact(lastMod ?? defaultNoneName);
                cb.SelectedIndexChanged += (cb_sender, cbe) =>
                {
                    var modInfo = (cb.SelectedItem as string);
                    Coordinator.State.ModDefaultDict[lastSelIdx] = modInfo;
                };
                e.Control = cb;
            }
        }

        private void lstInvMod_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Column.Text == "Modifier")
            {
                e.Control = null;
                ((ObjectListView)sender).RefreshItem(e.ListViewItem);
                e.Cancel = true;
            }
        }

        private void numRenown_ValueChanged(object sender, EventArgs e)
        {
            if (this.Player.Clan != null)
            {
                var newval = (float)((DarkUI.Controls.DarkNumericUpDown)sender).Value;
                this.Player.Clan.Renown = newval;
            }
        }

        private void numInfluence_ValueChanged(object sender, EventArgs e)
        {
            if (this.Player.Clan != null)
            {
                var newval = (float)((DarkUI.Controls.DarkNumericUpDown)sender).Value;
                this.Player.Clan.Influence = newval;
            }
        }

        private void numControversy_ValueChanged(object sender, EventArgs e)
        {
            if (this.Player.Clan != null)
            {
                var newval = (float)((DarkUI.Controls.DarkNumericUpDown)sender).Value;
                this.Player.Controversy = newval;
            }
        }

        private void btnAbandon_Click(object sender, EventArgs e)
        {
#if MBVER_010403
            PlayerSiege.ClosePlayerSiege();
#else
            PlayerSiege.ClosePlayerSiege();
#endif
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            var siege = PlayerSiege.PlayerSiegeEvent;
#if !MBVER_010403
            //if (PlayerSiege.Current != null) return;
#endif
            if (PlayerSiege.PlayerSiegeEvent != null)
            {
                if (siege.BesiegerCamp.IsBesiegerSideParty(Player.PartyBelongedTo))
                {
                    var evt = PlayerSiege.PlayerSiegeEvent;
                    if (evt.IsPlayerSiegeEvent)
                    {
                        var attacker = evt.GetSiegeEventSide(BattleSideEnum.Attacker);
                        foreach (var progress in attacker.SiegeEngines.AllSiegeEngines())
                        {
                            if (!progress.IsConstructed && progress.Progress < 1f) {
                                progress.SetProgress(0.999f);
                                //progress.SetRedeploymentProgress(0f);
                                progress.SetHitpoints(progress.MaxHitPoints);
                            }                            
                            else if (progress.IsBeingRedeployed)
                            {
                                if (progress.RedeploymentProgress < 1f)
                                {
                                    progress.SetRedeploymentProgress(0.999f);
                                    progress.SetHitpoints(progress.MaxHitPoints);
                                }
                            }
                        }
                         
                        ////evt.FinalizeSiegeEvent(); 
                        //int i = 0;
                        //while (evt.BesiegerCamp.BesiegerParty.MapEvent != null && !evt.ReadyToBeRemoved && ++i < 100)
                        //{
                        //    evt.AdvanceStrategy(evt.BesiegerCamp);
                        //    evt.ConstructionTick(evt.BesiegerCamp);
                        //    evt.BombardTick(evt.BesiegerCamp);
                        //    //evt.BesiegerCamp.Tick(1.0f);
                        //}
                    }
                }
            }


        
            //PlayerSiege.PlayerSiegeEvent.ConstructionTick(PlayerSiege.ClosePlayerSiege);

            //PlayerSiege.PlayerSiegeEvent.FinalizeSiegeEvent();
        }

        private void tabStripDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabStripDetail.SelectedTab == tabDetail)
            {
                this.darkPropertyGrid1.SetObject(Player);
            }
            
        }


        void InitializeKeys()
        {

            cboOpenKey.Items.AddRange(Enum.GetNames(typeof(TaleWorlds.InputSystem.InputKey)));
        }

        void ReloadKeys()
        {

            int index = cboOpenKey.FindStringExact(MBEditor.SubModule.OpenKey.Code.ToString());
            if (index < 0)
                index = cboOpenKey.FindStringExact(TaleWorlds.InputSystem.InputKey.F8.ToString());
            cboOpenKey.SelectedIndex = index;
            cboOpenCtrl.SelectedIndex = !MBEditor.SubModule.OpenKey.Control.HasValue ? 2 : MBEditor.SubModule.OpenKey.Control.Value ? 1 : 0;
            cboOpenAlt.SelectedIndex = !MBEditor.SubModule.OpenKey.Alt.HasValue ? 2 : MBEditor.SubModule.OpenKey.Alt.Value ? 1 : 0;
            cboOpenShift.SelectedIndex = !MBEditor.SubModule.OpenKey.Shift.HasValue ? 2 : MBEditor.SubModule.OpenKey.Shift.Value ? 1 : 0;
        }

        private void btnOpenKeySave_Click(object sender, EventArgs e)
        {
            if (Enum.TryParse<TaleWorlds.InputSystem.InputKey>(cboOpenKey.SelectedItem.ToString(), out var key))
            {
                MBEditor.SubModule.OpenKey.Code = key;
                MBEditor.SubModule.OpenKey.Control = cboOpenCtrl.SelectedIndex == 2 ? (bool?)null : (bool?)(cboOpenCtrl.SelectedIndex == 1);
                MBEditor.SubModule.OpenKey.Alt = cboOpenAlt.SelectedIndex == 2 ? (bool?)null : (bool?)(cboOpenAlt.SelectedIndex == 1);
                MBEditor.SubModule.OpenKey.Shift = cboOpenShift.SelectedIndex == 2 ? (bool?)null : (bool?)(cboOpenShift.SelectedIndex == 1);

                var obj = new Newtonsoft.Json.Linq.JObject();
                obj.Add("Open", Newtonsoft.Json.Linq.JToken.FromObject(MBEditor.SubModule.OpenKey));
                global::MBEditor.Extensions.WriteConfigSave(obj, "Commands.json");
            }
        }

        private void numMaxPartySize_ValueChanged(object sender, EventArgs e)
        {
            var value = GetPrivateStaticField<int>(typeof(DefaultPartySizeLimitModel), "_additionalPartySizeAsCheat");
            var new_value = Convert.ToInt32(numMaxPartySize.Value);
            if (value != new_value)
                SetPrivateStaticField(typeof(DefaultPartySizeLimitModel), "_additionalPartySizeAsCheat", new_value);
        }

        private void numPartyMaxPrisoners_ValueChanged(object sender, EventArgs e)
        {
            var value = GetPrivateStaticField<int>(typeof(DefaultPartySizeLimitModel), "_additionalPrisonerSizeAsCheat");
            var new_value = Convert.ToInt32(numPartyMaxPrisoners.Value);
            if (value != new_value)
                SetPrivateStaticField(typeof(DefaultPartySizeLimitModel), "_additionalPrisonerSizeAsCheat", new_value);

        }

        public string SettingsName => "Party";
        public JObject SaveSettings()
        {
            var objctrl = new JObject();
            if (lstInvMod.TryGetJsonSettings(out var allitems))
                objctrl.Add("Mods", allitems);
            if (spltItems.TryGetJsonSettings(out var width))
                objctrl.Add("Split", width);
            return objctrl;
        }

        public void ReadSettings(JToken objctrl)
        {
            spltItems.ApplyJsonSettings(objctrl["Split"]);
            lstInvMod.ApplyJsonSettings(objctrl["Mods"]);
        }
    }
}
