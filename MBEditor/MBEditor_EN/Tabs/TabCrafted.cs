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
    using DarkUI;

    public partial class TabCrafted : DarkUI.Docking.DarkDocument, ITab, IStateSerializer
    {
        public TabCrafted()
        {
            InitializeComponent();
        }

        public MBCoordinator Coordinator { get; set; }

        void ITab.InitializeTab()
        {
            MBEditor.Log.Debug("Initializing Crafted Items Tab");
            //InitializeList();
        }

        void ITab.Activate()
        {
            MBEditor.Log.Debug("Activating Crafted Items Tab");
            this.InitializeAutoSize();
            //UpdateList(full: false);
            this.UpdateCraftedItems();
        }

        void ITab.AfterLoad()
        {
        }

        void ITab.Deactivate()
        {
            MBEditor.Log.Debug("Deactivating Crafted Items Tab");
        }

        private class CraftedItemInfo
        {
            public ItemObject item;
            public WeaponDesign design;
            public CultureObject culture;
            public TaleWorlds.Localization.TextObject itemName;
            public Crafting.OverrideData overrideData;

            public CraftedItemInfo(ItemObject item
            , WeaponDesign design
            , CultureObject culture
            , TaleWorlds.Localization.TextObject itemName
            , Crafting.OverrideData overrideData)
            {
                this.item = item;
                this.design = design;
                this.culture = culture;
                this.itemName = itemName;
                this.overrideData = overrideData;
            }

            public override string ToString() => this.item.Name.ToString();
        }

        private void UpdateCraftedItems()
        {
            this.lstCraftedItems.BeginUpdate();
            try
            {
                //var indices = this.lstCraftedItems.SelectedIndices ?? new List<int>();

                //this.lstCraftedItems.Items.Clear();
                var campaign = TaleWorlds.CampaignSystem.Campaign.Current;
                var behavior = campaign.GetCampaignBehavior<TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors.CraftingCampaignBehavior>();
                //var asm = System.Reflection.Assembly.GetAssembly(typeof(TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors));
                var dictField = typeof(TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors.CraftingCampaignBehavior).GetField("_craftedItemDictionary", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                var dictValue = dictField.GetValue(behavior) as System.Collections.IDictionary;
                //Debug.Log($"DictValue: {dictValue?.ToString() ?? "<None>"} -> ({dictValue?.Count ?? 0}) ");
                foreach (var key in dictValue.Keys)
                {
                    var item = key as ItemObject;
                    var value = dictValue[item];

                    var design = value.GetType().GetField("CraftedData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).GetValue(value) as WeaponDesign;
                    var culture = value.GetType().GetField("Culture", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).GetValue(value) as CultureObject;
                    var itemName = value.GetType().GetField("ItemName", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).GetValue(value) as TaleWorlds.Localization.TextObject;
                    var overrideData = value.GetType().GetField("OverrideData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).GetValue(value) as Crafting.OverrideData;
                    this.lstCraftedItems.Items.Add(new CraftedItemInfo(item, design, culture, itemName, overrideData));
                }
                //this.lstCraftedItems.SelectItems( indices);
            }
            catch (Exception ex)
            {
                MBEditor.Log.Debug(ex.ToString());
            }
            this.lstCraftedItems.EndUpdate();
        }


        private void lstCraftedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var indices = lstCraftedItems.SelectedIndices;
            if (indices == null || indices.Count != 1) return;

            var craftedItem = lstCraftedItems.Items[indices[0]].Tag as CraftedItemInfo;
            if (craftedItem != null)
            {
                //txtCraftedName.Text = craftedItem.item.Name.GetID() + craftedItem.item.Name.ToString();
                txtCraftedName.Text = craftedItem.item.Name.GetType().GetField("Value", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(craftedItem.item.Name).ToString();

                numCraftHandling.DefaultEditor(craftedItem.overrideData.Handling);
                numCraftSwingDamage.DefaultEditor(craftedItem.overrideData.SwingDamageOverriden);
                numCraftSwingSpeed.DefaultEditor(craftedItem.overrideData.SwingSpeedOverriden);
                numCraftThrustDamage.DefaultEditor(craftedItem.overrideData.ThrustDamageOverriden);
                numCraftThrustSpeed.DefaultEditor(craftedItem.overrideData.ThrustSpeedOverriden);
                numCraftWeight.DefaultEditor(craftedItem.overrideData.WeightOverriden);
            }
            else
            {
                txtCraftedName.Text = "{=!}";
                numCraftHandling.Value = 0;
                numCraftSwingDamage.Value = 0;
                numCraftSwingSpeed.Value = 0;
                numCraftThrustDamage.Value = 0;
                numCraftThrustSpeed.Value = 0;
                numCraftWeight.Value = 0;
            }
        }


        private void btnCraftedCommit_Click(object sender, EventArgs e)
        {

            var craftedItem = lstCraftedItems.GetFirstSelection<CraftedItemInfo>();
            if (craftedItem != null)
            {
                craftedItem.item.Name.GetType().GetField("Value", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(craftedItem.item.Name, txtCraftedName.Text);
                craftedItem.itemName.GetType().GetField("Value", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(craftedItem.item.Name, txtCraftedName.Text);

                craftedItem.overrideData.Handling = (int)numCraftHandling.Value;
                craftedItem.overrideData.SwingDamageOverriden = (int)numCraftSwingDamage.Value;
                craftedItem.overrideData.SwingSpeedOverriden = (int)numCraftSwingSpeed.Value;
                craftedItem.overrideData.ThrustDamageOverriden = (int)numCraftThrustDamage.Value;
                craftedItem.overrideData.ThrustSpeedOverriden = (int)numCraftThrustSpeed.Value;
                craftedItem.overrideData.WeightOverriden = (float)numCraftWeight.Value;

                InitializePreCraftedWeaponOnLoad(craftedItem.item, craftedItem.design, craftedItem.itemName, craftedItem.culture, craftedItem.overrideData);
                try
                {
                    var mgr = TaleWorlds.CampaignSystem.Campaign.Current.CampaignBehaviorManager;
                    var meth = mgr.GetType().GetMethod("OnBeforeSave", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    meth.Invoke(mgr, new object[0]);

                    //TaleWorlds.CampaignSystem.Campaign.Current.CampaignBehaviorManager.OnGameLoaded();
                }
                catch (Exception ex)
                {
                    MBEditor.Log.Debug(ex.ToString());
                }

            }
            UpdateCraftedItems();
        }



        private static ItemObject InitializePreCraftedWeaponOnLoad(ItemObject itemObject, WeaponDesign craftedData, TaleWorlds.Localization.TextObject itemName, BasicCultureObject culture, Crafting.OverrideData overrideData)
        {
            Crafting crafting1 = new Crafting(craftedData.Template, culture);
            crafting1.CraftedWeaponName = itemName.ToString();
            crafting1.GetType().GetField("<CurrentWeaponDesign>k__BackingField", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(crafting1, craftedData);
            crafting1.GetType().GetField("_history", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(crafting1, new List<WeaponDesign> { craftedData });
            crafting1.GetType().GetMethod("SetItemObject", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(crafting1, new Object[] { overrideData, itemObject });
            return itemObject;
        }
        public string SettingsName => "Crafted";
        public JObject SaveSettings()
        {
            var objctrl = new JObject();
            if (splitContainer1.TryGetJsonSettings(out var width))
                objctrl.Add("Split", width);
            return objctrl;
        }

        public void ReadSettings(JToken objctrl)
        {
            splitContainer1.ApplyJsonSettings(objctrl["Split"]);
        }

    }
}
