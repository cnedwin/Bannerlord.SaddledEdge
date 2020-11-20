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

    public partial class TabWorkshops : DarkUI.Docking.DarkDocument, ITab, IStateSerializer
    {
        public TabWorkshops()
        {
            InitializeComponent();
        }

        public MBCoordinator Coordinator { get; set; }

        void ITab.InitializeTab()
        {
            MBEditor.Log.Debug("Initializing Workshop Tab");
            InitializeList();
        }

        void ITab.Activate()
        {
            MBEditor.Log.Debug("Activating Workshop Tab");
            this.InitializeAutoSize();
            UpdateList(full: false);
        }

        void ITab.AfterLoad()
        {            
        }

        void ITab.Deactivate()
        {
            MBEditor.Log.Debug("Deactivating Workshop Tab");
        }

        private const System.Reflection.BindingFlags privatePropertyFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
        private const System.Reflection.BindingFlags publicPropertyFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public;
        private static string BackingField(string name) => $"<{name}>k__BackingField";

        private void InitializeList()
        {
            this.lstItems.DefaultList();

            lstItems.AllColumns.Add(new OLVColumn { Text = "Settlement", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable=false, Width = 150,
                AspectGetter = item => ((Workshop)item).Settlement?.Name?.ToString() ?? "<None>",
            });
            lstItems.AllColumns.Add(new OLVColumn { Text = "Owner", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable=false,Width = 150,
                AspectGetter = item => ((Workshop)item).Owner?.Name?.ToString() ?? "<None>",
            });
            lstItems.AllColumns.Add(new OLVColumn { Text = "InitCapital", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable=true,Width = 110,
                AspectGetter = item => ((Workshop)item).InitialCapital,
                AspectPutter = (item, value) => ((Workshop)item).GetType().GetField(BackingField("InitialCapital"), privatePropertyFlags).SetValue(item, System.Convert.ToInt32(value)),
            });
            lstItems.AllColumns.Add(new OLVColumn { Text = "Capital", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable=true,Width = 110,
                AspectGetter = item => ((Workshop)item).Capital,
                AspectPutter = (item, value) => ((Workshop)item).GetType().GetField(BackingField("Capital"), privatePropertyFlags).SetValue(item, System.Convert.ToInt32(value)),
            });
            lstItems.AllColumns.Add(new OLVColumn { Text = "Expense", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable=false,Width = 110,
                AspectGetter = item => ((Workshop)item).Expense,
            });
            lstItems.AllColumns.Add(new OLVColumn { Text = "Profit", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable=false,Width = 110,
                AspectGetter = item => ((Workshop)item).ProfitMade,
            });
            lstItems.AllColumns.Add(new OLVColumn { Text = "Level", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable=true,Width = 100,
                AspectGetter = item => ((Workshop)item).Level,
                AspectPutter = (item, value) => ((Workshop)item).GetType().GetField(BackingField("Level"), privatePropertyFlags).SetValue(item, System.Convert.ToInt32(value)),
            });
            lstItems.AllColumns.Add(new OLVColumn { Text = "Construction", IsVisible = false, TextAlign = HorizontalAlignment.Center, IsEditable=true,Width = 60,
                AspectGetter = item => ((Workshop)item).ConstructionTimeRemained,
                AspectPutter = (item, value) => ((Workshop)item).GetType().GetField(BackingField("ConstructionTimeRemained"), privatePropertyFlags).SetValue(item, System.Convert.ToInt32(value)),
            });
            lstItems.AllColumns.Add(new OLVColumn { Text = "Upgradable", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable=false,Width = 130,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((Workshop)item).CanBeUpgraded,
            });
            lstItems.Columns.Clear();
            lstItems.Columns.AddRange(lstItems.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());
            lstItems.AutoSizeColumns();

            lstItems.CellEditStarting += LstItems_CellEditStarting;
            lstItems.CellEditFinishing += LstItems_CellEditFinishing;
        }

        private void LstItems_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (!e.Column.CheckBoxes && !(e.Column.Renderer is DarkUI.Support.CheckStateRenderer))
            {
                e.AutoDispose = true;
                e.Control = new DarkUI.Controls.DarkNumericUpDown { Bounds = e.CellBounds }.DefaultEditor(e.Value);
            }
        }

        private void LstItems_CellEditFinishing(object sender, CellEditEventArgs e)
        {
        }

        private void UpdateList(bool full = false)
        {
            var lastSel = this.lstItems.SelectedObject;
            var items = new List<Workshop>();
            if (this.Coordinator == null)
            {
                MBEditor.Log.Debug("Coordinator: <null>");
            }
            var hero = this.Coordinator?.Hero;
            if (hero != null)
            {
                this.lstItems.SetObjects(hero.OwnedWorkshops);
                this.lstItems.AutoSizeColumns();
            }
            else
            {
                MBEditor.Log.Debug("Hero <null>");

                this.lstItems.SetObjects(null);
            }
            this.lstItems.SelectedObject = lastSel;
        }

        public string SettingsName => "Workshops";
        public JObject SaveSettings()
        {
            var objctrl = new JObject();
            if (lstItems.TryGetJsonSettings(out var items))
                objctrl.Add("Items", items);
            return objctrl;
        }

        public void ReadSettings(JToken objctrl)
        {
            lstItems.ApplyJsonSettings(objctrl["Items"]);
        }
    }
}
