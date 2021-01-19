using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DarkUI.Forms;
using TaleWorlds.Library;

namespace MBEditor
{
    using System;
    using System.IO;
    using TaleWorlds.CampaignSystem;
    using TaleWorlds.Core;
    using TaleWorlds.InputSystem;
    using TaleWorlds.MountAndBlade;

    public class SubModule : MBSubModuleBase
    {
        MainForm _instance = null;
        bool _userWarned = false;

        internal class ClassCommandKey
        {
            public InputKey Code;
            public bool? Control;
            public bool? Alt;
            public bool? Shift;
        }
        internal static ClassCommandKey OpenKey = null;

        private static readonly ClassCommandKey _defaultOpenKey = new ClassCommandKey { Code = InputKey.F8, Alt = false, Control = true, Shift = false };

        public class WindowWrapper : System.Windows.Forms.IWin32Window
        {
            public WindowWrapper(IntPtr handle) { Handle = handle; }
            public IntPtr Handle { get; private set; }
        }
        enum QUERY_USER_NOTIFICATION_STATE
        {
            QUNS_NOT_PRESENT = 1,
            QUNS_BUSY = 2,
            QUNS_RUNNING_D3D_FULL_SCREEN = 3,
            QUNS_PRESENTATION_MODE = 4,
            QUNS_ACCEPTS_NOTIFICATIONS = 5,
            QUNS_QUIET_TIME = 6
        };
        [DllImport("shell32.dll")]
        static extern int SHQueryUserNotificationState(out QUERY_USER_NOTIFICATION_STATE pquns);


        protected override void OnApplicationTick(float dt)
        {
            base.OnApplicationTick(dt);
            if (Campaign.Current?.GameStarted == true)
            {
                if (OpenKey.Code.IsReleased()
                    && (!OpenKey.Control.HasValue || OpenKey.Control.Value == (InputKey.LeftControl.IsDown() || InputKey.RightControl.IsDown()))
                    && (!OpenKey.Shift.HasValue || OpenKey.Shift.Value == (InputKey.LeftShift.IsDown() || InputKey.RightShift.IsDown()))
                    && (!OpenKey.Alt.HasValue || OpenKey.Alt.Value == (InputKey.LeftAlt.IsDown() || InputKey.RightAlt.IsDown()))
                    )
                { 
                    System.AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                    System.AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
                    try {
                        if (_instance == null)
                            _instance = new MainForm();

                        QUERY_USER_NOTIFICATION_STATE pquns;
                        SHQueryUserNotificationState(out pquns);
                        Log.Debug($"SHQueryUserNotificationState: {pquns}");

                        if (pquns == QUERY_USER_NOTIFICATION_STATE.QUNS_RUNNING_D3D_FULL_SCREEN) {
                            // fullscreen
                            Log.Info("FullScreen is not supported.  Please use 'Borderless Fullscreen' or 'Windowed' in Video Options");
                            return;
                        } 

                        var curstate = Game.Current.GameStateManager.ActiveState;
                        Log.Debug($"Active State: {curstate}");
                        string warningText = null;
                        if (curstate is CharacterDeveloperState)
                            warningText = "Please do not edit while on Character screen.  Please use Quests (J) screen for edits for consistency.";
                        else if (curstate is InventoryState)
                            warningText = "Please do not edit while on Inventory screen.  Please use Quests (J) screen for edits for consistency.";
                        else if (curstate is PartyState)
                            warningText = "Please do not edit while on Party screen.  Please use Quests (J) screen for edits for consistency.";
                        if (warningText != null) {
                            Log.Info(warningText);
                            if (!_userWarned) {
                                _userWarned = true;
                                var msgbox = new DarkUI.Forms.DarkMessageBox(warningText, "Consistency Warning"
                                    , DarkMessageBoxIcon.Error, DarkDialogButton.RetryCancel);
                                msgbox.TopMost = true;
                                var result = msgbox.ShowDialog();
                                if (result == DialogResult.Cancel)
                                    return;
                            }
                        }
                        //var handle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
                        //Log.Debug($"Handle: {handle}");
                        //_instance.Show(new WindowWrapper(handle));
                        _instance.ShowDialog();
                    }
                    catch (Exception ex) {
                        Log.Debug(ex.Message);
                    }
                    finally {
                        System.AppDomain.CurrentDomain.UnhandledException -= CurrentDomain_UnhandledException;
                        System.AppDomain.CurrentDomain.FirstChanceException -= CurrentDomain_FirstChanceException;
                    }

                }
            }
        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();
        }

        public override void OnGameEnd(Game game)
        {
            Log.Debug("On Game End");
            base.OnGameEnd(game);
            try {
                if (_instance != null) {
                    _instance.Visible = false;
                    System.Windows.Forms.Application.DoEvents();
                    _instance.Close();
                    _instance.Dispose();
                    _instance = null;
                    System.AppDomain.CurrentDomain.UnhandledException -= CurrentDomain_UnhandledException;
                    System.AppDomain.CurrentDomain.FirstChanceException -= CurrentDomain_FirstChanceException;
                }
            }
            catch (Exception ex) {
                Log.Debug(ex.ToString());
            }
        }
        private void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            Log.Debug(e.Exception?.ToString());
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Debug(e.ToString());
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);
            if (!Directory.Exists(Log.LogPath))
                Directory.CreateDirectory(Log.LogPath);
            Log.Debug("On Game Start");

            var defaultConfig = true;
            try
            {
                if (global::MBEditor.Extensions.TryReadConfigSave(out var json, "Commands.json"))
                {
                    var open = json["Open"];
                    if (open != null)
                    {
                        OpenKey = open.ToObject<ClassCommandKey>();
                        defaultConfig = false;
                    }
                }
                else
                {
                    // create missing file
                    var obj = new Newtonsoft.Json.Linq.JObject();
                    obj.Add("Open", Newtonsoft.Json.Linq.JToken.FromObject(_defaultOpenKey));
                    global::MBEditor.Extensions.WriteConfigSave(obj, "Commands.json");
                }
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }

            if (defaultConfig)
                OpenKey = _defaultOpenKey;
        }
        private static ItemObject InitializePreCraftedWeaponOnLoad(ItemObject itemObject, WeaponDesign craftedData, TaleWorlds.Localization.TextObject itemName, BasicCultureObject culture, Crafting.OverrideData overrideData)
        {
            Crafting crafting1 = new Crafting(craftedData.Template, culture);
            crafting1.CraftedWeaponName = itemName.ToString();
            crafting1.GetType().GetProperty("CurrentWeaponDesign", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty).SetValue(crafting1, craftedData);
            crafting1.GetType().GetProperty("_history", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty).SetValue(crafting1, new System.Collections.Generic.List<WeaponDesign> { craftedData });
            crafting1.GetType().GetMethod("SetItemObject", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.InvokeMethod).Invoke(crafting1, new Object[] { overrideData, itemObject });
            return itemObject;
        }

        public override void OnGameLoaded(Game game, object initializerObject)
        {
            Log.Debug("->OnGameLoaded");
            base.OnGameLoaded(game, initializerObject);
            //Debug.Log("<-OnGameLoaded");
        }
        public override void OnGameInitializationFinished(Game game)
        {
            Log.Debug("->OnGameInitializationFinished");
            base.OnGameInitializationFinished(game);

            try
            {
                // do proper initialization of custom weapons
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
                    Log.Debug(item.Name.ToString());
                    var design = value.GetType().GetField("CraftedData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).GetValue(value) as WeaponDesign;
                    var culture = value.GetType().GetField("Culture", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).GetValue(value) as CultureObject;
                    var itemName = value.GetType().GetField("ItemName", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).GetValue(value) as TaleWorlds.Localization.TextObject;
                    var overrideData = value.GetType().GetField("OverrideData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).GetValue(value) as Crafting.OverrideData;

                    InitializePreCraftedWeaponOnLoad(item, design, itemName, culture, overrideData);
                }
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString()); 
            }

            Log.Debug("<-OnGameInitializationFinished");
        }
        public override void OnNewGameCreated(Game game, object initializerObject)
        {
            Log.Debug("->OnNewGameCreated");
            base.OnNewGameCreated(game, initializerObject);
            Log.Debug("<-OnNewGameCreated");
        }
        public override void OnCampaignStart(Game game, object starterObject)
        {
            Log.Debug("->OnCampaignStart");
            base.OnCampaignStart(game, starterObject);
            Log.Debug("<-OnCampaignStart");
        }

        public Hero Player
        {
            get
            {
                if (Game.Current == null)
                {
                    return null;
                }
                CharacterObject playerTroop = Game.Current.PlayerTroop as CharacterObject;
                return playerTroop?.HeroObject;
            }
        }
    }
}

