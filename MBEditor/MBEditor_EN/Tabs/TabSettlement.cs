using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MBEditor;
using Newtonsoft.Json.Linq;

namespace MBEditor.Tabs
{
    using TaleWorlds.CampaignSystem;
    using TaleWorlds.Core;
    using TaleWorlds.Library;
    using BrightIdeasSoftware;
    using DarkUI;
    using DarkUI.Support;

    public partial class TabSettlement : DarkUI.Docking.DarkDocument, ITab, IStateSerializer
    {
        private bool _disableEvents;
        public TabSettlement()
        {
            InitializeComponent();
        }

        public Hero Player => Coordinator?.Hero;

        public MBCoordinator Coordinator { get; set; }


        private T GetPrivateField<T>(Object obj, string name)
        {
            if (obj == null) return default(T);
            return (T)obj.GetType().GetField(name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)?.GetValue(obj);
        }
        private void SetPrivateField<T>(Object obj, string name, T value)
        {
            obj?.GetType()?.GetField(name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)?.SetValue(obj, value);
        }

        private T GetPublicProperty<T>(Object obj, string name)
        {
            if (obj == null) return default(T);
            return (T)obj.GetType().GetProperty(name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.GetProperty)?.GetValue(obj, new object[0]);
        }

        void ITab.InitializeTab()
        {
            MBEditor.Log.Debug("Initializing Settlement Tab");
            InitializeGrid();
            InitializeDetail();

            HookChangeEvents();
        }

        void InitializeGrid()
        {
            this.splitContainer1.Panel2Collapsed = true;

            this.lstItems.DefaultList();
            this.lstItems.MultiSelect = true;

            this.lstItems.Columns.Clear();
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Name", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 80, Width = 180,
                AspectGetter = item => ((Settlement)item).Name?.ToString() ?? "<None>",
            });
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Owner", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, MinimumWidth = 80, Width = 140,
                AspectGetter = item => ((Settlement)item).OwnerClan?.Name?.ToString() ?? "<None>",
            });
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Building", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 150,
                AspectGetter = item => ((Settlement)item).Town?.CurrentBuilding?.Name?.ToString()
            });
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Finish", IsVisible = false, TextAlign = HorizontalAlignment.Center, IsEditable = false, MinimumWidth = 80,
                Renderer = new DarkUI.Support.ColumnButtonRenderer(), IsButton = true,
                AspectGetter = item =>
                {
                    var building = ((Settlement)item).Town?.CurrentBuilding;
                    if (building == null || building.BuildingProgress >= building.GetConstructionCost()) return null;
                    return "Done";
                }
            });
            //this.lstItems.AllColumns.Add(new OLVColumn
            //{
            //    Text = "Focus", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, MinimumWidth = 80,
            //    Renderer = new DarkUI.Support.ColumnButtonRenderer(), IsButton = true,
            //    AspectGetter = item => "Focus",
            //});
            this.lstItems.AllColumns.Add(new OLVColumn {
                Text = "Security", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = true, Width = 120,
                AspectGetter = item => (decimal?)(((Settlement)item).Town?.Security),
                AspectPutter = (item, value) => {
                    if (((Settlement)item).Town == null) return;
                    ((Settlement)item).Town.Security = Math.Max(0.0f, Convert.ToSingle(value)); },
            });
            this.lstItems.AllColumns.Add(new OLVColumn {
                Text = "Food", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = true, Width = 120,
                AspectGetter = item => (decimal?)(((Settlement)item).Town?.FoodStocks),
                AspectPutter = (item, value) => {
                    if (((Settlement)item).Town == null) return;
                    ((Settlement)item).Town.FoodStocks = Math.Max(0.0f, Convert.ToSingle(value)); },
            });
            this.lstItems.AllColumns.Add(new OLVColumn {
                Text = "Prosperity", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = true, Width = 120,
                AspectGetter = item => (decimal)(((Settlement)item).Prosperity),
                AspectPutter = (item, value) => { ((Settlement)item).Prosperity = Math.Max(0.0f, Convert.ToSingle(value)); },
            });
            this.lstItems.AllColumns.Add(new OLVColumn {
                Text = "Militia", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = true, Width = 110,
                AspectGetter = item => (decimal)(((Settlement)item).Militia),
#if !MBVER_010301
                AspectPutter = (item, value) => { ((Settlement)item).Militia = Math.Max(0.0f, Convert.ToSingle(value)); },
#endif
            });
            this.lstItems.AllColumns.Add(new OLVColumn {
                Text = "Loyalty", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = true, Width = 110,
                AspectGetter = item => (decimal?)(((Settlement)item).Town?.Loyalty),
                AspectPutter = (item, value) => {
                    if (((Settlement)item).Town == null) return;
                    ((Settlement)item).Town.Loyalty = Math.Max(0.0f, Convert.ToSingle(value)); 
                },
            });
            this.lstItems.AllColumns.Add(new OLVColumn {
                Text = "State", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = true,  Width = 110,
                AspectGetter = item => (((Settlement)item).Village?.VillageState),
            });

            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Town", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 80,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((Settlement)item).IsTown,
            });
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Village", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 80,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((Settlement)item).IsVillage,
            });
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Castle", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 80,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((Settlement)item).IsCastle,
            });
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Raided", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 80,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((Settlement)item).IsRaided,
            });
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Target", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, MinimumWidth = 80,
                Renderer = new DarkUI.Support.ColumnButtonRenderer(), IsButton = true,
                AspectGetter = item => "Target"
            });
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "Teleport", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, MinimumWidth = 80,
                Renderer = new DarkUI.Support.ColumnButtonRenderer(), IsButton = true,
                AspectGetter = item => "Teleport"
            });

            lstItems.Columns.Clear();
            lstItems.Columns.AddRange(lstItems.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());

            //this.lstItems.AllColumns.First(x => x.Text == "Owner").ValuesChosenForFiltering = new List<string> { Player.Clan?.Name?.ToString() ?? "" }; // remove dead people
            //this.lstItems.UpdateColumnFiltering();

            lstItems.CellEditStarting += LstItems_CellEditStarting;
            lstItems.CellEditFinishing += LstItems_CellEditFinishing;
            lstItems.ButtonClick += LstItems_ButtonClick;
        }

        void InitializeDetail()
        {
            lstBuildingQueue.DefaultList();
            lstBuildingQueue.AllColumns.Clear();

            lstBuildingQueue.Columns.Clear();
            lstBuildingQueue.AllColumns.Add(new OLVColumn
            {
                Text = "Name",IsVisible = true,TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 100,
                Width = 100,
                AspectGetter = item => ((Building)item).Name?.ToString() ?? "<None>",
            });
            lstBuildingQueue.AllColumns.Add(new OLVColumn
            {
                Text = "Level",IsVisible = true,TextAlign = HorizontalAlignment.Left, IsEditable = false, Width = 50,
                AspectGetter = item => ((Building)item).CurrentLevel,
            });
            lstBuildingQueue.AllColumns.Add(new OLVColumn
            {
                Text = "Finish", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.ColumnButtonRenderer(), IsButton = true,
                AspectGetter = item =>
                {
                    if (((Building)item).BuildingProgress >= ((Building)item).GetConstructionCost()) return null;
                    return "Done";
                }
            });
            lstBuildingQueue.AllColumns.Add(new OLVColumn
            {
                Text = "Level Down", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.ColumnButtonRenderer(), IsButton = true,
                AspectGetter = item => (((Building)item).CurrentLevel > 0) ? "-1" : null,
            });
            lstBuildingQueue.AllColumns.Add(new OLVColumn
            {
                Text = "Level Up", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.ColumnButtonRenderer(), IsButton = true,
                AspectGetter = item => (((Building)item).CurrentLevel < 3) ? "+1" : null,
            });
            lstBuildingQueue.Columns.Clear();
            lstBuildingQueue.Columns.AddRange(lstBuildingQueue.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());
            lstBuildingQueue.AutoResizeColumns();

            lstBuildingQueue.CellEditStarting += LstBuildingQueue_CellEditStarting; ;
            lstBuildingQueue.CellEditFinishing += LstBuildingQueue_CellEditFinishing;
            lstBuildingQueue.ButtonClick += LstBuildingQueue_ButtonClick;

        }

        private void LstBuildingQueue_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (!e.Column.CheckBoxes && !(e.Column.Renderer is DarkUI.Support.CheckStateRenderer))
            {
                e.AutoDispose = false;
                e.Control = new DarkUI.Controls.DarkNumericUpDown { Bounds = e.CellBounds }.DefaultEditor(e.Value);
            }
        }
        private void LstBuildingQueue_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (!e.Column.CheckBoxes && !(e.Column.Renderer is DarkUI.Support.CheckStateRenderer))
            {
                e.Control = null;
            }
        }

        private void LstBuildingQueue_ButtonClick(object sender, CellClickEventArgs e)
        {
            if (e.Column.Text == "Finish")
            {
                var building = (Building)e.Model;
                if (building != null)
                {
                    if (building.BuildingProgress < building.GetConstructionCost())
                        building.BuildingProgress = building.GetConstructionCost();
                }
                lstBuildingQueue.UpdateObject(e.Model);
                lstItems.UpdateObject(lstItems.SelectedItem);
            }
            else if (e.Column.Text == "Level Up")
            {
                var building = (Building)e.Model;
                if (building != null)
                    building.LevelUp();
                lstBuildingQueue.UpdateObject(e.Model);
                lstItems.UpdateObject(lstItems.SelectedItem);
            }
            else if (e.Column.Text == "Level Down")
            {
                var building = (Building)e.Model;
                if (building != null)
                    building.LevelDown();
                lstBuildingQueue.UpdateObject(e.Model);
                lstItems.UpdateObject(lstItems.SelectedItem);
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

        private void LstItems_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (!e.Column.CheckBoxes && !(e.Column.Renderer is DarkUI.Support.CheckStateRenderer))
            {
                e.Control = null;
            }
        }

        private void LstItems_ButtonClick(object sender, CellClickEventArgs e)
        {
            if (e.Column.Text == "Finish")
            {
                var building = ((Settlement)e.Model).Town?.CurrentBuilding;
                if (building != null)
                {
                    if (building.BuildingProgress < building.GetConstructionCost())
                        building.BuildingProgress = building.GetConstructionCost();
                }
                lstItems.UpdateObject(e.Model);
            }
            else if (e.Column.Text == "Focus")
            {

            }
            else if (e.Column.Text == "Max")
            {
                foreach (Building building in ((Settlement)e.Model).Town.Buildings)
                    if (building.BuildingProgress >= building.GetConstructionCost())
                        building.CurrentLevel = 3;
            }
            else if (e.Column.Text == "Target")
            {
                Player.PartyBelongedTo.SetMoveGoToSettlement((Settlement)e.Model);

                var form = this.FindForm();
                if (form != null) form.Visible = false;
            }
            else if (e.Column.Text == "Teleport")
            {
                var settle = ((Settlement)e.Model);
                Player.PartyBelongedTo.Position2D = Helpers.MobilePartyHelper.FindReachablePointAroundPosition(partyBase, settle.GatePosition, 4f, 3f, false);
                Player.PartyBelongedTo.SetMoveGoToSettlement((Settlement)e.Model);

                var form = this.FindForm();
                if (form != null) form.Visible = false;
            }
        }

        void ITab.Activate()
        {
            MBEditor.Log.Debug("Activating Settlement Tab");
            this.InitializeAutoSize();
            Reload();
        }

        void ITab.AfterLoad()
        {
        }

        void ITab.Deactivate()
        {
            MBEditor.Log.Debug("Deactivating Settlement Tab");
        }

        void Reload()
        {
            if (_disableEvents) return;
            var disableEvents = _disableEvents;
            _disableEvents = true;
            try {
                var values = Settlement.All
                    .OrderByDescending(x => x.OwnerClan == Player.Clan)
                    .ThenBy(x => x.OwnerClan?.Name?.ToString() ?? "ZZZZ")
                    .ThenByDescending(x => x.IsTown)
                    .ThenByDescending(x => x.IsCastle)
                    .ThenBy(x => x.Name?.ToString())
                    .ToArray();
                this.lstItems.SetObjects(values);
                this.lstItems.UpdateObjects(values);
            }
            catch (Exception e) {
                Log.Debug(e.ToString());
            }
            finally {
                _disableEvents = disableEvents;
            }
        }
        
        private void lstItems_SelectionChanged(object sender, EventArgs e)
        {
            var obj = lstItems.SelectedObject;
            if (tabSettlementDetails.SelectedTab == tabDetails)
                this.darkPropertyGrid1.SetObject(obj);
            else
                this.darkPropertyGrid1.SetObject(null);

            this.splitContainer1.Panel2Collapsed = (obj == null);

            var settlement = obj as Settlement;
            if (settlement != null)
            {
                //txtSettlementName.Text = GetPrivateField<string>(settlement.Name, "Value");
                txtDisplayName.Text = settlement.Name?.ToString();
                //txtQueueSize.Text = settlement.Town?.CurrentBuilding?.Name?.ToString();

                var town = settlement?.Town;
                if (town != null)
                {
                    txtBuildingCurrent.Text = town.CurrentBuilding?.Name?.ToString();
                    var buildings = typeof(Town).GetField("BuildingsInProgress", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).GetValue(town) as System.Collections.ICollection;
                    lstBuildingQueue.SetObjects(buildings as System.Collections.IEnumerable);
                }
                else
                {
                    lstBuildingQueue.SetObjects(null);
                }
            }
            else
            {
                //txtSettlementName.Text = "";
                txtBuildingCurrent.Text = "";
                lstBuildingQueue.SetObjects(null);
            }
        }

        private void btnFinishBuilding_Click(object sender, EventArgs e)
        {
            var building = (lstItems.SelectedObject as Settlement)?.Town?.CurrentBuilding;
            if (building != null)
            {
                building.BuildingProgress = building.GetConstructionCost();

                var town = (lstItems.SelectedObject as Settlement)?.Town;
                if (town != null)
                {
                    var tick = typeof(Town).GetMethod("TickCurrentBuilding", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    if (tick != null)
                        tick.Invoke(town, new object[0]);

                    lstItems_SelectionChanged(this.lstItems, EventArgs.Empty); //refresh
                }
            }
        }


        private void btnFinishQueue_Click(object sender, EventArgs e)
        {
            var town = (lstItems.SelectedObject as Settlement)?.Town;
            if (town != null)
            {
                var buildings = typeof(Town).GetField("BuildingsInProgress", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).GetValue(town) as System.Collections.ICollection;
                foreach (var building in buildings.OfType<Building>().ToArray()) {
                    building.BuildingProgress = building.GetConstructionCost();

                    var tick = typeof(Town).GetMethod("TickCurrentBuilding", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    if (tick != null)
                        tick.Invoke(town, new object[0]);

                    lstItems_SelectionChanged(this.lstItems, EventArgs.Empty); //refresh
                }
            }
        }

        private void tabSettlementDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSettlementDetails.SelectedTab == tabDetails)
            {
                var obj = lstItems.SelectedObject;
                this.darkPropertyGrid1.SetObject(obj);
            }
        }

#if false
        // name changes do not persist
        private void txtSettlementName_TextChanged(object sender, EventArgs e)
        {
            var obj = lstItems.SelectedObject as Settlement;
            if (obj?.Name != null && !string.IsNullOrEmpty(this.txtSettlementName.Text))
            {
                var originalName = GetPrivateField<string>(obj.Name, "Value");
                if (originalName != this.txtSettlementName.Text) {
                    SetPrivateField(obj.Name, "Value", this.txtSettlementName.Text);
                    //obj.Name = new TaleWorlds.Localization.TextObject(this.txtSettlementName.Text);

                    txtDisplayName.Text = obj.Name?.ToString();
                }
            }
        }
#endif

        private void HookChangeEvents()
        {
            void Handler(object sender, EventArgs args) => this.lstItems.UpdateObject(this.lstItems.SelectedObject);
            //this.txtSettlementName.TextChanged += Handler;
            this.btnFinishBuilding.Click += Handler;
            this.btnFinishQueue.Click += Handler;
        }

        public string SettingsName => "Settlement";

        public PartyBase partyBase { get; private set; }

        public JObject SaveSettings()
        {
            var objctrl = new JObject();
            if (lstItems.TryGetJsonSettings(out var allitems))
                objctrl.Add("Items", allitems);
            if (lstBuildingQueue.TryGetJsonSettings(out var items))
                objctrl.Add("Queue", items);
            if (splitContainer1.TryGetJsonSettings(out var width))
                objctrl.Add("Split", width);
            return objctrl;
        }

        public void ReadSettings(JToken objctrl)
        {
            splitContainer1.ApplyJsonSettings(objctrl["Split"]);
            lstItems.ApplyJsonSettings(objctrl["Items"]);
            lstBuildingQueue.ApplyJsonSettings(objctrl["Queue"]);
        }
    }
}
