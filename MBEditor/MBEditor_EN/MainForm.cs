using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using BrightIdeasSoftware;
using System.Linq;
using System.Reflection;
using JObject = Newtonsoft.Json.Linq.JObject;
using JToken = Newtonsoft.Json.Linq.JToken;
using DarkUI.Win32;

namespace MBEditor
{

    public partial class MainForm : DarkUI.Forms.DarkForm
    {
        public static MainForm instance = null;
        private readonly MBCoordinator coordinator;

        public MainForm()
        {
            InitializeComponent();

            // Add the control scroll message filter to re-route all mousewheel events
            // to the control the user is currently hovering over with their cursor.
            Application.AddMessageFilter(new ControlScrollFilter());

            // Add the dock content drag message filter to handle moving dock content around.
            Application.AddMessageFilter(DockPanel.DockContentDragFilter);

            // Add the dock panel message filter to filter through for dock panel splitter
            // input before letting events pass through to the rest of the application.
            Application.AddMessageFilter(DockPanel.DockResizeFilter);

            if (DesignMode)
                return;

            HookEvents();

            var ver = System.Reflection.Assembly.GetExecutingAssembly()?.GetName()?.Version?.ToString();
            var verinfo = System.Reflection.Assembly.GetExecutingAssembly()?.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute))
                ?.OfType<AssemblyInformationalVersionAttribute>().FirstOrDefault();
            if (verinfo != null && !string.IsNullOrEmpty(verinfo.InformationalVersion))
                this.Text += " " + verinfo.InformationalVersion;
            else if (!string.IsNullOrEmpty(ver))
                this.Text += " " + ver.ToString();

            var party = new Tabs.TabParty() { DockText = "Party" };
            DockPanel.AddContent(party);
            DockPanel.AddContent(new Tabs.TabInventory() { DockText = "Inventory" });
            DockPanel.AddContent(new Tabs.TabTroops() { DockText = "Troops" });
            DockPanel.AddContent(new Tabs.TabHero() { DockText = "Companions" });
            DockPanel.AddContent(new Tabs.TabNPCs() { DockText = "NPCs" });
            DockPanel.AddContent(new Tabs.TabFaction() { DockText = "Factions" });
            DockPanel.AddContent(new Tabs.TabSettlement() { DockText = "Settlements" });
            DockPanel.AddContent(new Tabs.TabCrafted() { DockText = "Crafted Items" });
            DockPanel.AddContent(new Tabs.TabWorkshops() { DockText = "Workshops" });
            DockPanel.ActiveContent = party;

            DockPanel.CloseButtonEnabled = false;

            var hero = (DesignMode == false) ? (Game.Current?.PlayerTroop as CharacterObject).HeroObject : null;
            this.coordinator = new MBCoordinator() { Hero = hero, Control = this.DockPanel };

            RestoreSettings();
            this.InitializeAutoSize();
            DockPanel.ActiveContent = DockPanel.GetDocuments().FirstOrDefault();
        }

        private void HookEvents()
        {
            DockPanel.ContentAdded += DockPanel_ContentAdded; ;
            DockPanel.ContentRemoved += DockPanel_ContentRemoved; ;
            this.FormClosed += DockedForm_FormClosed;
            this.VisibleChanged += DockedForm_VisibleChanged;
            this.FormClosing += DockedForm_FormClosing;
        }

        private void DockedForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // if user closing then cancel and hide
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                SaveSettings();
                this.Visible = false;
            }
        }

        private void DockedForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //Reload();
                this.coordinator.Activate();
            }
            else
            {
                this.coordinator.Deactivate();
            }
        }

        private void DockedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void DockPanel_ContentAdded(object sender, DarkUI.Docking.DockContentEventArgs e)
        {
        }
        private void DockPanel_ContentRemoved(object sender, DarkUI.Docking.DockContentEventArgs e)
        {
        }

        private void DockPanel_Load(object sender, EventArgs e)
        {
        }

        void SaveSettings()
        {
            try
            {
                var obj = new JObject();
                {
                    var main = new JObject();
                    main.Add("Size", JToken.FromObject(this.Size));
                    main.Add("Position", JToken.FromObject(this.Location));
                    main.Add("Selected", DockPanel.ActiveDocument?.DockText);
                    obj.Add("Main", main);
                }

                obj.Add(GlobalState.Instance.SettingsName, GlobalState.Instance.SaveSettings());

                if (coordinator.State.ModDefaultDict.Any())
                {
                    obj.Add("DefaultMods", JToken.FromObject(coordinator.State.ModDefaultDict));
                }
                foreach (var v in this.coordinator.Control.GetDocuments().OfType<IStateSerializer>())
                {
                    var name = v.SettingsName;
                    var value = v.SaveSettings();
                    if (string.IsNullOrEmpty(name) || value == null)
                        continue;

                    obj.Add(v.SettingsName, value);
                }

                MBEditor.Extensions.WriteConfigSave(obj);
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }
        }

        void RestoreSettings()
        {
            try {
                if (MBEditor.Extensions.TryReadConfigSave(out var result)) {
                    var global = result[GlobalState.Instance.SettingsName];
                    if (global != null) {
                        GlobalState.Instance.ReadSettings(global);
                    }

                    Application.DoEvents();

                    var main = result["Main"];
                    var size = main["Size"]?.ToObject<Size>();
                    if (size.HasValue) this.Size = size.Value;

                    Application.DoEvents();

                    var pos = main["Position"]?.ToObject<Point>();
                    if (pos.HasValue) {
                        var rect = new Rectangle(pos.Value, this.Size);

                        var screen = Screen.AllScreens.FirstOrDefault(x => x.WorkingArea.Contains(pos.Value)) ?? Screen.PrimaryScreen;
                        var workingArea = screen.WorkingArea;
                        if (!workingArea.Contains(rect)) {
                            rect.Width = Math.Min(workingArea.Width, rect.Width);
                            rect.Height = Math.Min(workingArea.Height, rect.Height);
                            rect.X = workingArea.X + (workingArea.Width - rect.Width) / 2;
                            rect.Y = workingArea.Y + (workingArea.Height - rect.Height) / 2;
                            this.Size = rect.Size;
                            pos = rect.Location;
                        }

                        this.StartPosition = FormStartPosition.Manual;
                        this.Location = pos.Value;
                    }

                    Application.DoEvents();

                    var mods = result["DefaultMods"]?.ToObject<Dictionary<string, string>>();
                    if (mods != null) {
                        foreach (var kvp in mods) {
                            try {
                                var key = (ItemObject.ItemTypeEnum) Enum.Parse(typeof(ItemObject.ItemTypeEnum), kvp.Key);
                                var value = kvp.Value;
                                coordinator.State.ModDefaultDict[key] = value;
                            }
                            catch { }
                        }

                        //coordinator.State = state;
                    }

                    foreach (var v in this.coordinator.Control.GetDocuments().OfType<IStateSerializer>()) {
                        var name = v.SettingsName;
                        var value = result[name];
                        if (value != null) {
                            v.ReadSettings(value);
                        }
                    }


                    var tab = main["Selected"]?.ToString();
                    if (!string.IsNullOrEmpty(tab)) {
                        var doc = DockPanel.GetDocuments().FirstOrDefault(x => x.DockText == tab);
                        if (doc != null)
                            DockPanel.ActiveContent = doc;
                    }
                }
            }
            catch (Exception ex) {
                Log.Debug(ex.ToString());
            }
        }
        
    }
}
