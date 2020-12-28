using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using BrightIdeasSoftware;
using DarkUI;

namespace MBEditor.Tabs
{


    public partial class TabInventory : DarkUI.Docking.DarkDocument, ITab, IStateSerializer
    {
        private const string defaultNoneName = "<None>";
        private static string[] itemTypeNames = new string[] {
            "全部", "坐骑", "单手武器", "双手武器", "长杆", "箭矢", "弩矢", "盾牌", "弓", "十字弩", "投掷", "物品", "头盔", "盔甲", "护腿", "手斧",
            "火枪", "步枪", "子弹", "动物", "书籍", "胸甲", "斗篷", "马具", "旗帜"
        };

        #region SubClasses
        private class AllItemInfo
        {
            public ItemObject item;
            public string name;

            public AllItemInfo(string name, ItemObject item)
            {
                this.name = name;
                this.item = item;
            }

            public override string ToString() => this.name;
        }
        private class InvItemModInfo
        {
            public ItemModifier item;
            public string name;

            public InvItemModInfo(string name, ItemModifier item)
            {
                this.name = name;
                this.item = item;
            }

            public override string ToString() => this.name;
        }

        #endregion

        public TabInventory()
        {
            InitializeComponent();
        }

        public MBCoordinator Coordinator { get; set; }

        public void InitializeTab()
        {
            MBEditor.Log.Debug("Initializing Inventory Tab");
            InitializeList();
            InitializeAllList();
            this.splInventory.SplitterDistance = 300;

            this.UpdateItemTypeBox();
            this.UpdateItemModList();
            this.UpdateInventoryList();
        }

        public void Activate()
        {
            MBEditor.Log.Debug("Activating Inventory Tab");
            UpdateAllItemList();
            UpdateInventoryList(full: false);
        }

        public void AfterLoad()
        {
        }

        public void Deactivate()
        {
            MBEditor.Log.Debug("Deactivating Inventory Tab");
        }

        public Hero Player => this.Coordinator?.Hero;


        private const System.Reflection.BindingFlags privatePropertyFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
        private const System.Reflection.BindingFlags publicPropertyFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public;
        private static string BackingField(string name) => $"<{name}>k__BackingField";
        private void InitializeAllList()
        {
            this.lstAllItems.DefaultList();
            this.lstAllItems.MultiSelect = true;

            //lstAllItems.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
            //lstAllItems.ShowGroups = false;
            lstAllItems.AllColumns.Clear();
            lstAllItems.AllColumns.Add(new OLVColumn
            {
                Text = "名称", IsVisible = true,TextAlign = HorizontalAlignment.Left, IsEditable = false, Width = 200, MinimumWidth = 80,
                AspectGetter = item => ((ItemObject)item).Name?.ToString(),
            });
            lstAllItems.AllColumns.Add(new OLVColumn
            {
                Text = "类型", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 175,
                AspectGetter = item => itemTypeNames[(int)((ItemObject)item).ItemType],
            });
            lstAllItems.AllColumns.Add(new OLVColumn
            {
                Text = "等阶", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 50,
                AspectGetter = item => ((ItemObject)item).Tier,
            });
            lstAllItems.AllColumns.Add(new OLVColumn
            {
                Text = "食物", IsVisible = false, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 40,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((ItemObject)item).IsFood,
            });
            lstAllItems.AllColumns.Add(new OLVColumn
            {
                Text = "动物", IsVisible = false, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 40,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((ItemObject)item).IsAnimal,
            });
            lstAllItems.AllColumns.Add(new OLVColumn
            {
                Text = "重量", IsVisible = false, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 40,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((ItemObject)item).Weight,
            });
            lstAllItems.Columns.Clear();
            lstAllItems.Columns.AddRange(lstAllItems.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());
            lstAllItems.AutoSizeColumns();

        }

        private void InitializeList()
        {
            this.lstInvEquipment.DefaultList();
            this.lstInvEquipment.MultiSelect = true;
            lstInvEquipment.AllColumns.Clear();
            lstInvEquipment.AllColumns.Add(new OLVColumn
            {
                Text = "#",IsVisible = true,TextAlign = HorizontalAlignment.Right,IsEditable = false,Width = 70,MinimumWidth = 25,
                AspectGetter = item => (int)item,
            });
            lstInvEquipment.AllColumns.Add(new OLVColumn
            {
                Text = "名称",IsVisible = true,TextAlign = HorizontalAlignment.Left,IsEditable = false,Width = 260,MinimumWidth = 100,
                AspectGetter = item => this.Player.PartyBelongedTo.ItemRoster.GetItemAtIndex((int)item)?.Name?.ToString(),
            });
            lstInvEquipment.AllColumns.Add(new OLVColumn
            {
                Text = "数量",IsVisible = true,TextAlign = HorizontalAlignment.Right,IsEditable = true,MinimumWidth = 60, Width = 86,
                AspectGetter = item => this.Player.PartyBelongedTo.ItemRoster.GetElementNumber((int)item),
                AspectPutter = (item, value) =>
                {
                    var oldvalue = this.Player.PartyBelongedTo.ItemRoster.GetElementNumber((int)item);
                    var itme2 = this.Player.PartyBelongedTo.ItemRoster.GetItemAtIndex((int)item);
                    int newvalue = System.Convert.ToInt32(value);
                    int diff = newvalue - oldvalue;
                    this.Player.PartyBelongedTo.ItemRoster.AddToCounts(itme2, diff);
                },
            });
            lstInvEquipment.AllColumns.Add(new OLVColumn
            {
                Text = "类型", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 60, Width = 180,
                AspectGetter = item => itemTypeNames[(int)this.Player.PartyBelongedTo.ItemRoster.GetItemAtIndex((int)item).ItemType],
            });
            lstInvEquipment.AllColumns.Add(new OLVColumn
            {
                Text = "等阶", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 40, Width = 50,
                AspectGetter = item => this.Player.PartyBelongedTo.ItemRoster.GetItemAtIndex((int)item).Tier,
            });
            lstInvEquipment.AllColumns.Add(new OLVColumn
            {
                Text = "重量", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 40, Width = 95,
                AspectGetter = item => {
                    var weight = this.Player.PartyBelongedTo.ItemRoster.GetItemAtIndex((int)item).Weight;
                    var mod = this.Player.PartyBelongedTo.ItemRoster.GetElementCopyAtIndex((int)item).EquipmentElement.ItemModifier;
                    return (mod == null) ? weight : weight;
                }
            });
            lstInvEquipment.AllColumns.Add(new OLVColumn
            {
                Text = "挥砍伤害", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 40, Width = 95,
                AspectGetter = item => {
                    var weapon = this.Player.PartyBelongedTo.ItemRoster.GetItemAtIndex((int)item).WeaponComponent;
                    if (weapon == null) return null;
                    return Helpers.ItemHelper.GetSwingDamageText(weapon.PrimaryWeapon,itemModifier).ToString();
                }
            });
            lstInvEquipment.AllColumns.Add(new OLVColumn
            {
                Text = "穿刺伤害", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 40, Width = 100,
                AspectGetter = item => {
                    var weapon = this.Player.PartyBelongedTo.ItemRoster.GetItemAtIndex((int)item).WeaponComponent;
                    if (weapon == null) return null;
                    return Helpers.ItemHelper.GetThrustDamageText(weapon.PrimaryWeapon,itemModifier).ToString();
                }
            });
            lstInvEquipment.AllColumns.Add(new OLVColumn
            {
                Text = "效果", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 40, Width = 100,
                AspectGetter = item => this.Player.PartyBelongedTo.ItemRoster.GetItemAtIndex((int)item).Effectiveness,
            });

            lstInvEquipment.AllColumns.Add(new OLVColumn
            {
                Text = "前缀", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = true, MinimumWidth = 150, Width = 210,
                AspectGetter = item => this.Player.PartyBelongedTo.ItemRoster.GetElementCopyAtIndex((int)item).EquipmentElement.ItemModifier?.StringId,
                AspectPutter = (item, value) => { },
            });
            lstInvEquipment.AllColumns.Add(new OLVColumn
            {
                Text = "头盔", IsVisible = false, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 40, Width = 100,
                AspectGetter = item => GetArmorTooltip(this.Player.PartyBelongedTo.ItemRoster.GetElementCopyAtIndex((int)item), ItemObject.ItemTypeEnum.HeadArmor)
            });
            lstInvEquipment.AllColumns.Add(new OLVColumn
            {
                Text = "盔甲", IsVisible = false, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 40, Width = 100,
                AspectGetter = item => GetArmorTooltip(this.Player.PartyBelongedTo.ItemRoster.GetElementCopyAtIndex((int)item), ItemObject.ItemTypeEnum.BodyArmor)
            });
            lstInvEquipment.AllColumns.Add(new OLVColumn
            {
                Text = "手套", IsVisible = false, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 40, Width = 100,
                AspectGetter = item => GetArmorTooltip(this.Player.PartyBelongedTo.ItemRoster.GetElementCopyAtIndex((int)item), ItemObject.ItemTypeEnum.HandArmor)
            });
            lstInvEquipment.AllColumns.Add(new OLVColumn
            {
                Text = "护腿", IsVisible = false, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 40, Width = 100,
                AspectGetter = item => GetArmorTooltip(this.Player.PartyBelongedTo.ItemRoster.GetElementCopyAtIndex((int)item), ItemObject.ItemTypeEnum.LegArmor)
            });
            lstInvEquipment.AllColumns.Add(new OLVColumn
            {
                Text = "马具", IsVisible = false, TextAlign = HorizontalAlignment.Left, IsEditable = false, MinimumWidth = 40, Width = 100,
                AspectGetter = item => GetArmorTooltip(this.Player.PartyBelongedTo.ItemRoster.GetElementCopyAtIndex((int)item), ItemObject.ItemTypeEnum.HorseHarness)
            });

            lstInvEquipment.Columns.Clear();
            lstInvEquipment.Columns.AddRange(lstInvEquipment.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());
            lstInvEquipment.AutoSizeColumns();
        }

        private static string GetArmorTooltip(ItemRosterElement elem, ItemObject.ItemTypeEnum type)
        {
            switch (type) {
                case ItemObject.ItemTypeEnum.HeadArmor:
                    return elem.EquipmentElement.GetModifiedHeadArmor().ToString();
                case ItemObject.ItemTypeEnum.BodyArmor:
                    return elem.EquipmentElement.GetModifiedBodyArmor().ToString();
                case ItemObject.ItemTypeEnum.HorseHarness:
                    return elem.EquipmentElement.GetModifiedMountBodyArmor().ToString();
                case ItemObject.ItemTypeEnum.HandArmor:
                    return elem.EquipmentElement.GetModifiedArmArmor().ToString();
                case ItemObject.ItemTypeEnum.LegArmor:
                    return elem.EquipmentElement.GetModifiedLegArmor().ToString();
            }

            return null;
        }


        private void lstInvEquipment_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (e.Column.Text == "前缀")
            {
                var cb = new DarkUI.Controls.DarkComboBox
                {
                    Bounds = e.CellBounds,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Sorted = false,
                };
                var modList = ObjectCache.GetObjectTypeList<ItemModifier>();
                cb.Items.Add(new InvItemModInfo(defaultNoneName, null));
                cb.Items.AddRange(modList.OrderBy(x=>x.StringId).Select(mod => new InvItemModInfo(mod.StringId, mod)).ToArray());
                var lastSelIdx = (int)e.RowObject;
                var lastSelElem = this.Player.PartyBelongedTo.ItemRoster.GetElementCopyAtIndex(lastSelIdx);
                var lastMod = lastSelElem.EquipmentElement.ItemModifier;
                cb.SelectedIndex = cb.FindStringExact(lastSelElem.EquipmentElement.ItemModifier?.StringId ?? defaultNoneName);
                cb.SelectedIndexChanged += (cb_sender, cbe) =>
                {
                    var modInfo = (cb.SelectedItem as InvItemModInfo)?.item;
                    if (modInfo == lastMod) return;
                    var y = new ItemRosterElement(lastSelElem.EquipmentElement.Item, lastSelElem.Amount, modInfo);
                    //this.Player.PartyBelongedTo.ItemRoster.SetElementAtIndex(lastSelIdx, y);
                };
                e.Control = cb;
            }
            else if (!e.Column.CheckBoxes && !(e.Column.Renderer is DarkUI.Support.CheckStateRenderer))
            {
                e.AutoDispose = false;
                e.Control = new DarkUI.Controls.DarkNumericUpDown { Bounds = e.CellBounds }.DefaultEditor(e.Value);
            }
        }

        private void lstInvEquipment_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Column.Text == "前缀")
            {
                e.Control = null;
                ((ObjectListView)sender).RefreshItem(e.ListViewItem);
                e.Cancel = true;
            }
        }

        private void UpdateInventoryList(bool full = false, bool refresh = false)
        {
            if (this.Coordinator == null)
            {
                MBEditor.Log.Debug("Coordinator: <null>");
            }
            var hero = this.Coordinator?.Hero;
            if (hero != null)
            {
                var newcnt = Player.PartyBelongedTo.ItemRoster.Count;
                var curcnt = this.lstInvEquipment.GetItemCount();
                if (newcnt == curcnt)
                {
                    this.lstInvEquipment.Refresh();
                    return;
                }

                var oldSelection = this.lstInvEquipment.SelectedObject;

                full |= (newcnt > 0 && this.lstInvEquipment.GetItemCount() == 0); // force autosize when filling with content
                var items = new List<object>(newcnt);
                for (int i = 0; i < newcnt; ++i) items.Add(i);
                this.lstInvEquipment.SetObjects(items);

                if (this.lstInvEquipment.PrimarySortColumn != null)
                    this.lstInvEquipment.Sort();

                this.lstInvEquipment.SelectedObject = oldSelection;
            }
            else
            {
                this.lstInvEquipment.SetObjects(null);
            }
            if (full)
            {
                lstInvEquipment.AutoSizeColumns();
            }
        }

        private void UpdateItemTypeBox()
        {
            this.cboInvItemFilter.Items.Clear();
            for (int i = 0; i < 0x19; i++)
                this.cboInvItemFilter.Items.Add(itemTypeNames[i]);
            this.cboInvItemFilter.SelectedIndex = 0;
        }

        private void UpdateItemModList()
        {
            var modList = ObjectCache.GetObjectTypeList<ItemModifier>();

            this.cboItemModifier.BeginUpdate();
            this.cboItemModifier.Items.Clear();
            var defaultitem = new InvItemModInfo(defaultNoneName, null);
            this.cboItemModifier.Items.Add(defaultitem);
            this.cboItemModifier.Items.AddRange(modList.OrderBy(x => x.StringId).Select(mod => new InvItemModInfo(mod.StringId, mod)).ToArray());
            cboItemModifier.SelectedIndex = 0;
            this.cboItemModifier.EndUpdate();
        }

        private void UpdateAllItemList()
        {
            if ((this.cboInvItemFilter.SelectedIndex == -1) || (this.cboInvItemFilter.SelectedIndex == 0))
            {
                this.UpdateAllItemListNoFilter();
            }
            else
            {
                ItemObject.ItemTypeEnum selectedIndex = (ItemObject.ItemTypeEnum)this.cboInvItemFilter.SelectedIndex;
                this.UpdateAllItemList(selectedIndex);
            }
        }

        private void UpdateAllItemListNoFilter()
        {
            //this.lstAllItems.ShowGroups = false;
            //this.lstAllItems.PrimarySortColumn = null;
            //this.lstAllItems.PrimarySortOrder = SortOrder.None;
            this.lstAllItems.SetObjects(ItemObject.All
                .OrderBy(x=>(int)x.ItemType)
                .ThenBy(x => (int)x.Tier)
                .ThenBy(x => x.IsFood?1:0)
                .ThenBy(x => x.Name.ToString())
                );
        }

        private void UpdateAllItemList(ItemObject.ItemTypeEnum itemType)
        {
            //this.lstAllItems.ShowGroups = false;
            //this.lstAllItems.PrimarySortColumn = null;
            //this.lstAllItems.PrimarySortOrder = SortOrder.None;
            this.lstAllItems.SetObjects(ItemObject.All
                .Where(x => x.ItemType == itemType)
                .OrderBy(x => (int)x.ItemType)
                .ThenBy(x => (int)x.Tier)
                .ThenBy(x => x.IsFood ? 1 : 0)
                .ThenBy(x => x.Name.ToString())
                );
            if (this.lstAllItems.PrimarySortColumn != null)
                this.lstAllItems.Sort();
        }

        private void cboInvItemFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAllItemList();
        }

        private void btnInvAdd_Click(object sender, EventArgs e)
        {
            AddCurrentSelect();
        }
        private void lstAllItems_DoubleClick(object sender, EventArgs e)
        {
            AddCurrentSelect();
        }

        private void AddCurrentSelect()
        {
            if (this.numInvItemCount.Value != decimal.Zero)
            {
                foreach(ItemObject item in lstAllItems.SelectedObjects)
                {
                    int number = (int)this.numInvItemCount.Value;
                    var mod = (this.cboItemModifier.SelectedItem as InvItemModInfo)?.item;
                    var rosterItem = new ItemRosterElement(item, number, mod);
                    var idx = this.Player.PartyBelongedTo.ItemRoster.FindIndexOfElement(rosterItem.EquipmentElement);
                    if (idx < 0)
                    {
                        this.Player.PartyBelongedTo.ItemRoster.Add(rosterItem);
                        idx = this.Player.PartyBelongedTo.ItemRoster.FindIndexOfElement(rosterItem.EquipmentElement);
                        UpdateInventoryList(refresh: true);
                        this.lstInvEquipment.SelectObject(idx);
                        this.lstInvEquipment.EnsureModelVisible(idx);
                    }
                    else
                    {
                        this.Player.PartyBelongedTo.ItemRoster.AddToCounts(this.Player.PartyBelongedTo.ItemRoster.GetItemAtIndex(idx), number);                        
                        lstInvEquipment.RefreshObject(idx);
                    }
                }
            }
        }


        private void btnInvRemove_Click(object sender, EventArgs e)
        {
            var idx = Math.Max(0, this.lstInvEquipment.SelectedIndex);
            foreach (var idxObj in lstInvEquipment.SelectedObjects)
            {
                var lastSelIdx = (int)idxObj;
                var lastSelElem = this.Player.PartyBelongedTo.ItemRoster.GetElementCopyAtIndex(lastSelIdx);
                this.Player.PartyBelongedTo.Party.ItemRoster.Remove(lastSelElem);
                this.UpdateInventoryList();
            }
            this.lstInvEquipment.SelectedIndex = idx-1;
            this.lstInvEquipment.EnsureVisible(idx-1);
        }

        private void btnEnsureFood_Click(object sender, EventArgs e)
        {
            int minCount = 25;
            var foodlist = ItemObject.All.Where(x => x.IsFood);
            var modList = ObjectCache.GetObjectTypeList<ItemModifier>();

            var modname = Coordinator.State.ModDefaultDict[ItemObject.ItemTypeEnum.Goods];
            var mod = modList.FirstOrDefault(x => x.StringId == modname);
            foreach (var food in foodlist)
            {
                var found = false;
                var curidx = this.Player.PartyBelongedTo.ItemRoster.FindIndex(x => x == food);

                while (curidx >= 0)
                {
                    found = true;
                    var itemelem = this.Player.PartyBelongedTo.ItemRoster.GetElementCopyAtIndex(curidx);
                    if (itemelem.EquipmentElement.ItemModifier == null && mod != null)
                    {
                        this.Player.PartyBelongedTo.ItemRoster.AddToCounts(food, Math.Max(itemelem.Amount, minCount));
                    }
                    else
                    {
                        if (itemelem.Amount < minCount)
                            this.Player.PartyBelongedTo.ItemRoster.AddToCounts(food, Math.Max(itemelem.Amount, minCount));
                    }
                    var newidx = this.Player.PartyBelongedTo.ItemRoster.FindIndexFirstAfterXthElement(x => x == food, curidx);
                    if (newidx <= curidx) break;
                    curidx = newidx;
                }
                if (!found)
                {
                    this.Player.PartyBelongedTo.ItemRoster.Add(new ItemRosterElement(food, minCount, mod));
                }
            }
            UpdateInventoryList(refresh:true);
        }

        class SortItem
        {
            public ItemObject item;
            public string name;
            public ItemObject.ItemTypeEnum type;
            public ItemModifier mod;
            public string modid;
            public int cnt;
        }

        private void btnSortItems_Click(object sender, EventArgs e)
        {
            var items = this.Player.PartyBelongedTo.ItemRoster;
            var n = this.Player.PartyBelongedTo.ItemRoster.Count;
            var elems = new List<SortItem>(n);
            for (var i = 0; i < n; ++i)
            {
                var item = items.GetItemAtIndex(i);
                var elem = items.GetElementCopyAtIndex(i);
                elems.Add(new SortItem
                {
                    item = item,
                    name = item.Name?.ToString(),
                    type = item.ItemType,
                    mod = elem.EquipmentElement.ItemModifier,
                    modid = elem.EquipmentElement.ItemModifier?.StringId,
                    cnt = items.GetElementNumber(i),
                });
            }
            //this.Player.PartyBelongedTo.ItemRoster.RemoveAllItems();
            foreach (var elem in elems.OrderBy(x =>x.type).ThenBy(x=>x.item.Tier).ThenBy(z => z.name).ThenBy(y => y.modid))
                this.Player.PartyBelongedTo.ItemRoster.Add(new ItemRosterElement(elem.item, elem.cnt, elem.mod));
            if (n != this.Player.PartyBelongedTo.ItemRoster.Count) // some items consolidated
            {
                n = this.Player.PartyBelongedTo.ItemRoster.Count;
                lstInvEquipment.BeginUpdate();
                UpdateInventoryList(full: true, refresh: true);
                for (int i = 0; i < n; ++i)
                    lstInvEquipment.UpdateObject(i);
                lstInvEquipment.EndUpdate();
            }
            else
            {
                lstInvEquipment.BeginUpdate();
                for (int i = 0; i < n; ++i)
                    lstInvEquipment.UpdateObject(i);
                UpdateInventoryList(refresh: true);
                lstInvEquipment.EndUpdate();
            }
        }

        private void btnApplyMods_Click(object sender, EventArgs e)
        {
            //var originalElements = this.Player.PartyBelongedTo.ItemRoster.GetCopyOfAllElements();

            var mods = new Dictionary<ItemObject.ItemTypeEnum, ItemModifier>();
            var modList = ObjectCache.GetObjectTypeList<ItemModifier>();

            foreach (ItemObject.ItemTypeEnum itm in Enum.GetValues(typeof(ItemObject.ItemTypeEnum)))
                mods[itm] = modList.FirstOrDefault(x => Coordinator.State.ModDefaultDict.TryGetValue(itm, out var value) && value == x.StringId);

            lstInvEquipment.BeginUpdate();
            var n = this.Player.PartyBelongedTo.ItemRoster.Count;
            for (var i=0; i<n;  ++i )
            {
                var elem = this.Player.PartyBelongedTo.ItemRoster.GetElementCopyAtIndex(i);
                if (elem.EquipmentElement.ItemModifier == null)
                {
                    var item = this.Player.PartyBelongedTo.ItemRoster.GetItemAtIndex(i);
                    if (item == null) continue;
                    if (mods.TryGetValue(item.ItemType, out var mod) && mod != null)
                    {
                        //this.Player.PartyBelongedTo.ItemRoster.SetElementAtIndex(i, new ItemRosterElement(elem.EquipmentElement.Item, elem.Amount, mod));
                        lstInvEquipment.UpdateObject(i);
                        continue;
                    }
                }
            }
            lstInvEquipment.EndUpdate();
            UpdateInventoryList(refresh: true);
        }

        public string SettingsName => "背包";

        public ItemModifier itemModifier { get; private set; }

        public JObject SaveSettings()
        {
            var objctrl = new JObject();
            if ( lstAllItems.TryGetJsonSettings(out var allitems) )
                objctrl.Add("AllItems", allitems);
            if (lstInvEquipment.TryGetJsonSettings(out var items))
                objctrl.Add("Items", items);
            if (splInventory.TryGetJsonSettings(out var width))
                objctrl.Add("Split", width);
            return objctrl;
        }

        public void ReadSettings(JToken objctrl)
        {
            splInventory.ApplyJsonSettings(objctrl["Split"]);
            lstAllItems.ApplyJsonSettings(objctrl["AllItems"]);
            lstInvEquipment.ApplyJsonSettings(objctrl["Items"]);
        }
    }
}
