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
    public partial class TabTroops : DarkUI.Docking.DarkDocument, ITab, IStateSerializer
    {
        bool prisonRoster = false;

        static readonly Occupation[] junk_excludes = new [] { Occupation.NotAssigned, Occupation.Special, Occupation.Wanderer };

        private static readonly Func<CharacterObject, bool> IsStrictExcluded = x =>
            x.IsHero || x.IsPlayerCharacter || x.IsTemplate || x.IsNotTransferable || x.IsChildTemplate;

        private static readonly Func<CharacterObject, bool> IsExcluded = x =>
            IsStrictExcluded(x) || junk_excludes.Contains(x.Occupation) || x.Culture == null || x.StringId.Contains("contender") || x.StringId.Contains("test");

        public TabTroops()
        {
            InitializeComponent();
        }

        public MBCoordinator Coordinator { get; set; }

        void ITab.InitializeTab()
        {
            MBEditor.Log.Debug("Initializing Troops Tab");
            Roster = Coordinator.Hero.PartyBelongedTo.Party.MemberRoster;
            InitializeLists();
            InitializeAllTropsLists();
        }

        void ITab.Activate()
        {
            MBEditor.Log.Debug("Activating Troops Tab");
            this.InitializeAutoSize();
            UpdateLists();
        }

        void ITab.AfterLoad()
        {            
        }

        void ITab.Deactivate()
        {
            MBEditor.Log.Debug("Deactivating Troops Tab");
        }

        private TroopRoster Roster { get; set; }

        private const System.Reflection.BindingFlags privatePropertyFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
        private const System.Reflection.BindingFlags publicPropertyFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public;
        private static string BackingField(string name) => $"<{name}>k__BackingField";

        private void InitializeAllTropsLists()
        {
            this.lstAllItems.DefaultList();

            lstAllItems.AllColumns.Clear();
            lstAllItems.AllColumns.Add(new OLVColumn {
                Text = "Name", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, Width = 280, MinimumWidth = 100,
                AspectGetter = item => ((CharacterObject)item).Name?.ToString(),
            });
            lstAllItems.AllColumns.Add(new OLVColumn {
                Text = "Culture", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, Width = 136, MinimumWidth = 80,
                AspectGetter = item => ((CharacterObject)item).Culture?.Name?.ToString(),
            });
            lstAllItems.AllColumns.Add(new OLVColumn {
                Text = "Occupation", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, Width = 100,
                AspectGetter = item => ((CharacterObject)item).Occupation,
            });
            lstAllItems.AllColumns.Add(new OLVColumn {
                Text = "Level", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                AspectGetter = item => ((CharacterObject)item).Level,
            });
            lstAllItems.AllColumns.Add(new OLVColumn {
                Text = "Female", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((CharacterObject)item).IsFemale,
            });
            lstAllItems.AllColumns.Add(new OLVColumn {
                Text = "Bandit", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((CharacterObject)item).Culture?.IsBandit ?? false,
            });
            lstAllItems.AllColumns.Add(new OLVColumn {
                Text = "Infantry", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((CharacterObject)item).IsInfantry,
            });
            lstAllItems.AllColumns.Add(new OLVColumn {
                Text = "Archer", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((CharacterObject)item).IsArcher,
            });
            lstAllItems.AllColumns.Add(new OLVColumn {
                Text = "Mounted", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((CharacterObject)item).IsMounted,
            });
            lstAllItems.AllColumns.Add(new OLVColumn {
                Text = "Basic", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => ((CharacterObject)item).IsBasicTroop,
            });
            lstAllItems.AllColumns.Add( new OLVColumn {
                Text = "Excluded", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => IsExcluded((CharacterObject)item),
            });

            lstAllItems.CellEditStarting += DarkList_CellEditStarting;
            lstAllItems.CellEditFinishing += DarkList_CellEditFinishing;

            lstAllItems.Columns.Clear();
            lstAllItems.Columns.AddRange(lstAllItems.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());
            lstAllItems.AutoSizeColumns();

            lstAllItems.AllColumns.First(x => x.Text == "Occupation").ValuesChosenForFiltering = new List<Occupation> { Occupation.Soldier, Occupation.Bandit, Occupation.Mercenary };
            lstAllItems.AllColumns.First(x => x.Text == "Excluded").ValuesChosenForFiltering = new List<bool> {false};
            this.lstAllItems.UpdateColumnFiltering();
        }

        private void InitializeLists()
        {
            this.lstRosterTroops.DefaultList();
            this.lstRosterTroops.MultiSelect = true;

            lstRosterTroops.AllColumns.Clear();
            lstRosterTroops.AllColumns.Add(new OLVColumn {
                Text = "#",IsVisible = true,TextAlign = HorizontalAlignment.Right,IsEditable = false,Width = 50, MinimumWidth = 50,
                AspectGetter = item => (int)item,
            });
            lstRosterTroops.AllColumns.Add(new OLVColumn {
                Text = "Name", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, Width = 280, MinimumWidth = 100,
                AspectGetter = item => Roster.GetCharacterAtIndex((int)item)?.Name?.ToString(),
            });
            lstRosterTroops.AllColumns.Add(new OLVColumn {
                Text = "Culture", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, Width = 136, MinimumWidth = 100,
                AspectGetter = item => Roster.GetCharacterAtIndex((int)item)?.Culture?.Name?.ToString(),
            });
            lstRosterTroops.AllColumns.Add(new OLVColumn {
                Text = "Occupation", IsVisible = true, TextAlign = HorizontalAlignment.Left, IsEditable = false, Width = 120, MinimumWidth = 100,
                AspectGetter = item => Roster.GetCharacterAtIndex((int)item)?.Occupation,
            });
            lstRosterTroops.AllColumns.Add(new OLVColumn {
                Text = "Count",IsVisible = true,TextAlign = HorizontalAlignment.Right,IsEditable = true,MinimumWidth = 60,
                AspectGetter = item => Roster.GetElementNumber((int)item),
                AspectPutter = (item, value) => {
                    if (Roster.GetCharacterAtIndex((int)item).IsHero) return;
                    var newcount = Math.Max(0, System.Convert.ToInt32(value));
                    var idx = (int) item;
                    var obj = Roster.GetCharacterAtIndex(idx);
                    var oldcount = Roster.GetElementNumber(idx);
                    int diff = newcount - oldcount;
                    if (diff == 0)
                        return;
                    else if (diff < 0)
                        Roster.RemoveTroop(obj, -diff);
                    else
                        Roster.AddToCounts(obj, diff, false, 0, 0, true, -1);
                    if (newcount <= 0)
                    {
                        Roster.RemoveZeroCounts();
                        UpdateRosterList();
                    }
                },
            });
            lstRosterTroops.AllColumns.Add(new OLVColumn {
                Text = "Wounded",IsVisible = true,TextAlign = HorizontalAlignment.Right,IsEditable = true,MinimumWidth = 60,
                AspectGetter = item => Roster.GetElementWoundedNumber((int)item),
                AspectPutter = (item, value) => {
                    if (Roster.GetCharacterAtIndex((int)item).IsHero) return;
                    Roster.SetElementWoundedNumber((int)item, Math.Max(0, System.Convert.ToInt32(value))); },
            });
            lstRosterTroops.AllColumns.Add(new OLVColumn
            {
                Text = "Xp", IsVisible = true, TextAlign = HorizontalAlignment.Right, IsEditable = true, MinimumWidth = 60,
                AspectGetter = item => Roster.GetElementXp((int)item),
                AspectPutter = (item, value) =>
                {
                    if (Roster.GetCharacterAtIndex((int)item).IsHero) return;
                    var oldvalue = Roster.GetElementXp((int)item);
                    int newvalue = System.Convert.ToInt32(value);
                    int diff = newvalue - oldvalue;
                    if (diff > 0)
                        Roster.AddXpToTroopAtIndex(diff, (int)item);
                    else
                        Roster.SetElementXp((int)item, newvalue);
                },
            });
            lstRosterTroops.AllColumns.Add(new OLVColumn {
                Text = "Level", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                AspectGetter = item => Roster.GetCharacterAtIndex((int)item)?.Level ?? 0,
            });
            lstRosterTroops.AllColumns.Add(new OLVColumn {
                Text = "Female", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => Roster.GetCharacterAtIndex((int)item)?.IsFemale ?? false,
            });
            lstRosterTroops.AllColumns.Add(new OLVColumn {
                Text = "Bandit", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => Roster.GetCharacterAtIndex((int)item)?.Culture?.IsBandit ?? false,
            });
            lstRosterTroops.AllColumns.Add(new OLVColumn {
                Text = "Infantry", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => Roster.GetCharacterAtIndex((int)item)?.IsInfantry ?? false,
            });
            lstRosterTroops.AllColumns.Add(new OLVColumn {
                Text = "Archer", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => Roster.GetCharacterAtIndex((int)item)?.IsArcher ?? false,
            });
            lstRosterTroops.AllColumns.Add(new OLVColumn {
                Text = "Mounted", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => Roster.GetCharacterAtIndex((int)item)?.IsMounted ?? false,
            });
            lstRosterTroops.AllColumns.Add(new OLVColumn {
                Text = "Basic", IsVisible = true, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => Roster.GetCharacterAtIndex((int)item)?.IsBasicTroop ?? false,
            });
            lstRosterTroops.AllColumns.Add(new OLVColumn {
                Text = "Hero", IsVisible = false, TextAlign = HorizontalAlignment.Center, IsEditable = false, Width = 60,
                Renderer = new DarkUI.Support.CheckStateRenderer(), CheckBoxes = true,
                AspectGetter = item => Roster.GetCharacterAtIndex((int)item)?.IsHero ?? false,
            }); ;
            lstRosterTroops.CellEditStarting += DarkList_CellEditStarting;
            lstRosterTroops.CellEditFinishing += DarkList_CellEditFinishing;

            lstRosterTroops.Columns.Clear();
            lstRosterTroops.Columns.AddRange(lstRosterTroops.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());
            lstRosterTroops.AutoSizeColumns();
        }

        private void DarkList_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (e.Column.CheckBoxes)
            {
                e.AutoDispose = false;
                e.Control = new DarkUI.Controls.DarkCheckBox
                {
                    Bounds = e.CellBounds,
                    Checked = Convert.ToBoolean(e.Value),
                };
            }
            else if (!e.Column.CheckBoxes && !(e.Column.Renderer is DarkUI.Support.CheckStateRenderer))
            {
                e.AutoDispose = true;

                var incr = e.Column.Text.Contains("Gold") ? 1000 : 1;

                e.Control = new DarkUI.Controls.DarkNumericUpDown
                {
                    Bounds = e.CellBounds, Minimum = int.MinValue, Maximum = int.MaxValue, Increment = incr, MouseWheelIncrement = incr,
                    Value = Convert.ToDecimal(e.Value),
                };
            }
        }
        private void DarkList_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Column.CheckBoxes)
            {
                if (e.Control is IDisposable)
                    e.Control.Dispose();
                e.Control = null;
            }
        }


        private void UpdateLists(bool full = false)
        {
            this.UpdateAllTroopList();
            this.UpdateRosterList();

        }
        private void UpdateRosterList()
        { 
            if (this.Coordinator == null)
            {
                MBEditor.Log.Debug("Coordinator: <null>");
            }
            var hero = this.Coordinator?.Hero;
            if (hero != null)
            {
                int oldcnt = this.lstRosterTroops.GetItemCount();
                var oldSelection = this.lstRosterTroops.SelectedObject;
                int newcnt = Roster.Count;
                var full = (newcnt > 0 && this.lstRosterTroops.GetItemCount() == 0); // force autosize when filling with content
                var items = new List<object>(newcnt);
                for (int i = 0; i < newcnt; ++i) items.Add(i);

                if (full)
                {
                    lstRosterTroops.AllColumns.First(x => x.Text == "Hero").ValuesChosenForFiltering = new List<bool> { false };
                    this.lstRosterTroops.UpdateColumnFiltering();
                }

                this.lstRosterTroops.SetObjects(items);
                this.lstRosterTroops.SelectedObject = oldSelection;
                this.lstRosterTroops.AutoSizeColumns();
            }
            else
            {
                this.lstRosterTroops.SetObjects(null);
            }
        }


        private void UpdateAllTroopList()
        {
            this.lstAllItems.ShowGroups = false;
            this.lstAllItems.PrimarySortColumn = null;
            this.lstAllItems.PrimarySortOrder = SortOrder.None;

            var excludes = new Occupation[] { Occupation.NotAssigned, Occupation.Special, Occupation.Wanderer };
            this.lstAllItems.SetObjects(CharacterObject.All
                .Where(x=>!IsStrictExcluded(x))
                .OrderBy(x => x.Culture?.Name?.ToString() ?? "<None>")
                .ThenBy(x => x.IsFemale?1:0)
                .ThenBy(x => x.Level)
                .ThenBy(x => x.Name?.ToString() ?? "<None>")
                );
        }
        
        private void btnTroopsAdd_Click(object sender, EventArgs e)
        {
            AddCurrentSelection();
        }

        private void btnTroopsRemove_Click(object sender, EventArgs e)
        {
            var selection = this.lstRosterTroops.SelectedObjects;
            if ((selection?.Count ?? 0) > 0) {
                // remove from back
                int[] indices = selection.OfType<int>().OrderByDescending(x=>x).ToArray();
                foreach (var entry in indices)
                {
                    var idx = (int)entry;
                    var chr = Roster.GetCharacterAtIndex(idx);
                    var count = Roster.GetElementNumber(idx);
                    Roster.RemoveTroop(chr, count);
                }
                Roster.RemoveZeroCounts();
                UpdateRosterList();
            }
        }

        private void btnTroopsUpgrade_Click(object sender, EventArgs e)
        {
            var selection = this.lstRosterTroops.SelectedObjects;
            if ((selection?.Count ?? 0) > 0)
            {
                foreach (var entry in selection)
                {
                    var idx = (int)entry;
                    var chr = Roster.GetCharacterAtIndex(idx);
                    if (prisonRoster)
                    {
                        var behavior = Campaign.Current?.GetCampaignBehavior<TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors.RecruitPrisonersCampaignBehavior>();
                        if (behavior != null)
                        {
                            //没修好
                            //behavior.SetRecruitableNumber(Roster.GetCharacterAtIndex(idx), Roster.GetElementNumber(idx));

                        }
                    }
                    else
                    {
                        if (!chr.IsHero && (chr.UpgradeTargets != null) && (chr.UpgradeTargets.Length > 0))
                        {
                            int xpAmount = Roster.GetElementNumber(idx) * chr.UpgradeXpCost;
                            Roster.AddXpToTroopAtIndex(xpAmount, idx);
                        }
                    }
                }
                this.lstRosterTroops.UpdateObjects(selection);
            }
        }

        private void btnPrisoners_Click(object sender, EventArgs e)
        {
            this.prisonRoster = !this.prisonRoster;
            Roster = this.prisonRoster ? Coordinator.Hero.PartyBelongedTo.Party.PrisonRoster : Coordinator.Hero.PartyBelongedTo.Party.MemberRoster;
            this.UpdateRosterList();
            this.btnPrisoners.Text = "Show " + (this.prisonRoster ? "Troops" : "Prisoners");
            this.btnTroopsUpgrade.Text = this.prisonRoster ? "Recruit" : "Upgrade";
        }

        private void AddCurrentSelection()
        {
            if (this.numTroopsAdd.Value != decimal.Zero)
            {
                foreach( CharacterObject troop in this.lstAllItems.SelectedObjects )
                {
                    int count = (int)this.numTroopsAdd.Value;
                    int idx = Roster.AddToCounts(troop, count, false, 0, 0, true, -1);
                    this.lstRosterTroops.UpdateObject(idx);
                    this.UpdateRosterList();
                }
            }

        }
        private void lstAllItems_DoubleClick(object sender, EventArgs e)
        {
            AddCurrentSelection();
        }
        

        public string SettingsName => "Troops";
        public JObject SaveSettings()
        {
            var objctrl = new JObject();
            if (lstAllItems.TryGetJsonSettings(out var allitems))
                objctrl.Add("AllItems", allitems);
            if (lstRosterTroops.TryGetJsonSettings(out var items))
                objctrl.Add("Items", items);
            if (splParty.TryGetJsonSettings(out var width))
                objctrl.Add("Split", width);
            return objctrl;
        }

        public void ReadSettings(JToken objctrl)
        {
            splParty.ApplyJsonSettings(objctrl["Split"]);
            lstAllItems.ApplyJsonSettings(objctrl["AllItems"]);
            lstRosterTroops.ApplyJsonSettings(objctrl["Items"]);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {

        }
    }
}
