using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DarkUI.Controls;

namespace MBEditor.Tabs.HeroTab
{
    using TaleWorlds.CampaignSystem;
    using TaleWorlds.Core;
    using TaleWorlds.Library;
    using BrightIdeasSoftware;
    using DarkUI;

    public partial class TabHeroMain : UserControl, ITab
    {
        bool _disableEvents = false;

        public Hero selectedHero => Coordinator?.Hero;

        public TabHeroMain()
        {
            InitializeComponent();
        }

        public MBCoordinator Coordinator { get; set; }

        void ITab.InitializeTab()
        {
            MBEditor.Log.Debug("Initializing NPC Tab");

            this.numAttr.DefaultEditor(0);
            this.numFocus.DefaultEditor(0);
            this.numHealth.DefaultEditor(0);
            this.numLevel.DefaultEditor(0);
            this.numAge.DefaultEditor(100);

            InitializeControls();

            EnableControls(false);

            HookChangeEvents();

            this.Coordinator.DataChanged += (sender, args) => {
                if (args is SkillChangeArgs) {

                    bool disableEvents = _disableEvents;
                    _disableEvents = true;
                    this.numLevel.Value = Coordinator.Hero.Level;
                    _disableEvents = disableEvents;
                }
            };
        }

        private void HookChangeEvents()
        {
            void Handler(object sender, EventArgs args)
            {
                if (_disableEvents) return;
                Coordinator.InvokeDataChange();
            }

            this.txtFirstName.TextChanged += Handler;
            this.txtFullName.TextChanged += Handler;
            this.numAge.ValueChanged += Handler;
            //this.numAttr.ValueChanged += Handler;
            //this.numFocus.ValueChanged += Handler;
            //this.numHealth.ValueChanged += Handler;
            //this.numLevel.ValueChanged += Handler;
            this.btnMakeSibling.Click += Handler;
            this.cboClanInfo.SelectionChangeCommitted += Handler;
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

        private T GetPrivateField<T>(Object obj, string name)
        {
            if (obj == null) return default(T);
            return (T)obj.GetType().GetField(name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(obj);
        }
        private void SetPrivateField<T>(Object obj, string name, T value)
        {
            obj?.GetType()?.GetField(name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)?.SetValue(obj, value);
        }

        private void Reload()
        {
            var oldDisableEvents = _disableEvents;
            _disableEvents = true;
            try
            {
                var hero = selectedHero;
                if (hero == null)
                {
                    this.numLevel.Value = 1;
                    this.numHealth.Value = 100;
                    this.numFocus.Value = 0;
                    this.numAttr.Value = 0;
                    this.numAge.Value = 50;
                    this.EnableControls(false);
                }
                else
                {
                    this.UpdateControls(hero);
                }
            }
            finally
            {
                _disableEvents = oldDisableEvents;
            }
        }

        private void numAttr_ValueChanged(object sender, EventArgs e)
        {
            if (this._disableEvents) return;
            var hero = selectedHero;
            if (hero != null)
                hero.HeroDeveloper.UnspentAttributePoints = Math.Max(0, Math.Min(int.MaxValue, (int)this.numAttr.Value));
        }

        private void numFocus_ValueChanged(object sender, EventArgs e)
        {
            if (this._disableEvents) return;
            var hero = selectedHero;
            if (hero != null)
                hero.HeroDeveloper.UnspentFocusPoints = Math.Max(0, Math.Min(int.MaxValue, (int)this.numFocus.Value));
        }

        private void numHealth_ValueChanged(object sender, EventArgs e)
        {
            if (this._disableEvents) return;
            var hero = selectedHero;
            if (hero != null)
                hero.HitPoints = Math.Max(0, Math.Min(hero.MaxHitPoints, (int)this.numHealth.Value));
        }
        private void EnableControls(bool enable)
        {
            this.numHealth.Enabled = enable;
            this.numLevel.Enabled = enable;
            this.numFocus.Enabled = enable;
            this.numAttr.Enabled = enable;
            this.numAge.Enabled = enable;
            this.btnBodyPropsCopy.Enabled = enable;
            this.btnBodyPropsPaste.Enabled = enable;
            this.btnMakeSibling.Enabled = enable;
            this.txtFirstName.Enabled = enable;
            this.txtFullName.Enabled = enable;
        }

        private void UpdateControls(Hero hero)
        {
            EnableControls(true);

            if (hero.FirstName != null)
            {
                this.txtFirstName.ReadOnly = false;
                this.txtFirstName.Enabled = true;
                this.txtFirstName.Text = GetPrivateField<string>(hero.FirstName, "Value");
            }
            else
            {
                this.txtFirstName.ReadOnly = true;
                this.txtFirstName.Enabled = false;
                this.txtFirstName.Text = "";
            }
            if (hero.Name != null)
            {
                this.txtFullName.ReadOnly = false;
                this.txtFullName.Enabled = true;
                this.txtFullName.Text = GetPrivateField<string>(hero.Name, "Value");
            }
            else
            {
                this.txtFullName.ReadOnly = true;
                this.txtFullName.Enabled = false;
                this.txtFullName.Text = "";
            }
            this.numLevel.Value = hero.Level;
            this.numAge.Value = (int)hero.BirthDay.ElapsedYearsUntilNow;
            this.numHealth.Maximum = hero.MaxHitPoints;
            this.numHealth.Value = Math.Max(0, Math.Min(hero.MaxHitPoints, hero.HitPoints));
            this.numAttr.Value = hero.HeroDeveloper.UnspentAttributePoints;
            this.numFocus.Value = hero.HeroDeveloper.UnspentFocusPoints;

            this.cboClanInfo.SelectedItem = this.cboClanInfo.Items.OfType<DarkListItem>().FirstOrDefault(x => (x.Tag as Clan) == Coordinator.Hero?.Clan);
        }

        private void btnBodyPropsCopy_Click(object sender, EventArgs e)
        {
            var hero = selectedHero;
            if (hero != null)
            {
                Clipboard.SetText(hero.BodyProperties.ToString());
            }
        }

        private void btnBodyPropsPaste_Click(object sender, EventArgs e)
        {
            var hero = selectedHero;
            if (hero != null)
            {
                var props = Clipboard.GetText();
                if (BodyProperties.FromString(props, out var bp))
                {
                    hero.CharacterObject.UpdatePlayerCharacterBodyProperties(bp, hero.IsFemale);
//#if MBVER_010403
//                    hero.CharacterObject.UpdatePlayerCharacterBodyProperties(bp, hero.IsFemale);
//#else
//                    hero.ModifyPlayersFamilyAppearance(bp.StaticProperties);
//                    hero.BodyProperties.DynamicProperties = bp.DynamicProperties;
//#endif
                }
            }
        }

        private void UpdateFirstName()
        {
            if (this._disableEvents) return;

            var hero = selectedHero;
            if (hero != null && hero.FirstName != null)
            {
                var originalName = GetPrivateField<string>(hero.FirstName, "Value");
                if (originalName != this.txtFirstName.Text) {
                    SetPrivateField(hero.FirstName, "Value", this.txtFirstName.Text);
                    try {
                        if (hero.CharacterObject != null)
                            hero.CharacterObject.Name = NameGenerator.Current.GenerateHeroFullName(hero, true);
                    }
                    catch (Exception exception) {
                        Log.Debug(exception.ToString());
                    }
                }

                //hero.FirstName = new TaleWorlds.Localization.TextObject(this.txtFirstName.Text);
                //hero.CharacterObject.Name = NameGenerator.Current.GenerateHeroFullName(hero, false);
            }
        }

        private void UpdateFullName()
        {
            if (this._disableEvents) return;
            var hero = selectedHero;
            if (hero != null && hero.Name != null && !string.IsNullOrEmpty(this.txtFullName.Text))
            {
                var originalName = GetPrivateField<string>(hero.Name, "Value");
                if (originalName != this.txtFullName.Text)
                {
                    SetPrivateField(hero.Name, "Value", this.txtFullName.Text);
                }
            }
        }

        private void btnMakeSibling_Click(object sender, EventArgs e)
        {
            var hero = selectedHero;
            if (hero != null && selectedHero != hero)
            {
                if (hero.Father != null)
                    hero.Father.Children.Remove(hero);
                if (hero.Mother != null)
                    hero.Mother.Children.Remove(hero);
                hero.Clan = selectedHero.Clan;
                hero.Father = selectedHero.Father;
                hero.Mother = selectedHero.Mother;
                hero.SetPersonalRelation(selectedHero, 100);

                hero.CharacterObject.Name = NameGenerator.Current.GenerateHeroFullName(hero, false);
                //Helpers.HeroHelper.SetNPCRelationshipToNPCString(mainHero, hero, false);
            }
        }

        private void numLevel_ValueChanged(object sender, EventArgs e)
        {
            if (this._disableEvents) return;
            var hero = selectedHero;
            if (hero != null)
            {
                hero.Level = (int)this.numLevel.Value;
            }
        }

        private void numCharAge_ValueChanged(object sender, EventArgs e)
        {
            if (this._disableEvents) return;
            var hero = selectedHero;
            if (hero != null)
            {
                int curAge = (int)hero.BirthDay.ElapsedYearsUntilNow;
                int newAge = (int)this.numAge.Value;
                int diff = (curAge - newAge);

                if (diff != 0)
                {
                    hero.BirthDay += TaleWorlds.CampaignSystem.CampaignTime.Years(diff);

                    var finalAge = (int)hero.BirthDay.ElapsedYearsUntilNow;
                    MBEditor.Log.Debug($"调整年龄 {curAge} -> {newAge} = {finalAge}");
                }
            }
        }

        private void InitializeControls()
        {
            var playerClan = (Game.Current?.PlayerTroop as CharacterObject)?.HeroObject.Clan;

            var values = Clan.All
                .OrderByDescending(x => x == playerClan)
                .ThenBy(x => x.Name.ToString())
                .ToArray();

            this.cboClanInfo.Items.Clear();
            this.cboClanInfo.Items.Add(new DarkListItem(null, x=> "Empty"));
            this.cboClanInfo.Items.AddRange( values.Select( x=> new DarkListItem(x, y=> (y as Clan).Name.ToString() )).ToArray() );
        }

        private void cboClanInfo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_disableEvents) return;

        }

        private void cboClanInfo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_disableEvents) return;

            // ignore attempts at changing player
            var player = (Game.Current?.PlayerTroop as CharacterObject)?.HeroObject;
            if (Coordinator.Hero == player)
                return;

            var clan = ((this.cboClanInfo.SelectedItem as DarkListItem)?.Tag as Clan);
            if (clan != Coordinator.Hero.Clan) {
                Coordinator.Hero.Clan = clan;
            }
        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                UpdateFirstName();
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            UpdateFirstName();
        }

        private void txtFullName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                UpdateFullName();
        }

        private void txtFullName_Leave(object sender, EventArgs e)
        {
            UpdateFullName();
        }
    }
}
