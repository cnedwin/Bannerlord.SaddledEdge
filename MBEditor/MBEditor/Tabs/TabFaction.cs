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

namespace MBEditor.Tabs
{
    using TaleWorlds.CampaignSystem;
    using TaleWorlds.Core;
    using TaleWorlds.Library;
    using BrightIdeasSoftware;
    using DarkUI;
    using DarkUI.Support;

    public partial class TabFaction : DarkUI.Docking.DarkDocument, ITab, IStateSerializer
    {

        public TabFaction()
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
        private T GetPublicProperty<T>(Object obj, string name)
        {
            if (obj == null) return default(T);
            return (T)obj.GetType().GetProperty(name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.GetProperty)?.GetValue(obj, new object[0]);
        }

        void ITab.InitializeTab()
        {
            MBEditor.Log.Debug("Initializing IFaction Tab");

            this.MainSplitter.Panel2Collapsed = true;

            this.lstItems.DefaultList();
            this.lstItems.MultiSelect = true;

            this.lstItems.Columns.Clear();
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "名称", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 80, Width = 275,
                AspectGetter = item => ((IFaction)item).Name?.ToString() ?? "<None>",
            });
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "领袖", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 80, Width = 170,
                AspectGetter = item => ((IFaction)item).Leader?.Name?.ToString() ?? "<None>",
            });
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "氏族成员", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 89,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((IFaction)item).IsClan,
            });
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "犯罪等级", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = true, Width = 110,
                AspectGetter = item => ((IFaction)item).MainHeroCrimeRating,
                AspectPutter = (item, value) => { ((IFaction)item).MainHeroCrimeRating = Convert.ToSingle(value); },
            });
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "声望", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = true, Width = 130,
                AspectGetter = item => (item as Clan)?.Renown,
                AspectPutter = (item, value) => { var clan = (item as Clan); if (clan != null) clan.Renown = Convert.ToSingle(value); },
            });
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "影响力", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = true, Width = 120,
                AspectGetter = item => (item as Clan)?.Influence,
                AspectPutter = (item, value) => { var clan = (item as Clan); if (clan != null) clan.Influence = Convert.ToSingle(value); },
            });
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "等阶", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = false, Width = 90,
                AspectGetter = item => (item as Clan)?.Tier,
            });
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "氏族", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, Width = 150,
                AspectGetter = item => (item as Kingdom)?.RulingClan?.Name?.ToString(),
            });
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "实力", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = false, Width = 120,
                AspectGetter = item => Math.Round(((IFaction)item).TotalStrength,1),
            });
#if !MBVER_010400 && !MBVER_010301
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "好斗", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = false, Width = 93,
                AspectGetter = item => Math.Round(((IFaction)item).Aggressiveness,1),
            });
#endif
#if !MBVER_010403
            this.lstItems.AllColumns.Add(new OLVColumn
            {
                Text = "贵族", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = false, Width = 75,
                AspectGetter = item => ((IFaction)item).StringId?.Count(),
            });
#endif

            lstItems.Columns.Clear();
            lstItems.Columns.AddRange(lstItems.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());

            lstItems.CellEditStarting += LstItems_CellEditStarting;
            lstItems.CellEditFinishing += LstItems_CellEditFinishing;
            lstItems.ButtonClick += LstItems_ButtonClick;
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
        }

        void ITab.Activate()
        {
            MBEditor.Log.Debug("Activating IFaction Tab");
            this.InitializeAutoSize();
            Reload();
        }

        void ITab.AfterLoad()
        {
        }

        void ITab.Deactivate()
        {
            MBEditor.Log.Debug("Deactivating IFaction Tab");
        }

        void Reload()
        {
            var values = Kingdom.All.OrderBy(x=>x.Name.ToString()).OfType<IFaction>().Union(Clan.All.OrderBy(x => x.Name.ToString()).OfType<IFaction>())
                .OrderByDescending(x=>x.Leader == Player)
                .ThenBy(x=>x.IsClan)
                .ThenBy(x=>x.Name.ToString())
                .ToArray();
            this.lstItems.SetObjects(values);
            this.lstItems.UpdateObjects(values);
        }

        private void lstItems_SelectionChanged(object sender, EventArgs e)
        {
            var obj = lstItems.SelectedObject;
            this.PropertyGrid.SetObject(obj);
            this.MainSplitter.Panel2Collapsed = (obj == null);
        }

        public string SettingsName => "势力";
        public JObject SaveSettings()
        {
            var objctrl = new JObject();
            if (lstItems.TryGetJsonSettings(out var items))
                objctrl.Add("Items", items);
            if (MainSplitter.TryGetJsonSettings(out var width))
                objctrl.Add("Split", width);
            return objctrl;
        }

        public void ReadSettings(JToken objctrl)
        {
            MainSplitter.ApplyJsonSettings(objctrl["Split"]);
            lstItems.ApplyJsonSettings(objctrl["Items"]);
        }

    }
}
