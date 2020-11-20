namespace SaddledEdgeModule
{
    using System;
    using System.Linq;
    using TaleWorlds.Core;
    using TaleWorlds.Library;
    using TaleWorlds.MountAndBlade;

    public class SubModule : MBSubModuleBase
    {

        public override void OnGameEnd(Game game)
        {
            base.OnGameEnd(game);
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            //LoadChildAssembly();
            //delayedLoad?.Invoke();
        }

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            LoadChildAssembly();
        }

        void LoadChildAssembly()
        {
            try
            {
                Log.Debug("ModuleLoad");
                var asm = System.Reflection.Assembly.GetExecutingAssembly();
                if (!string.IsNullOrEmpty(asm.Location))
                {
                    var dir = System.IO.Path.GetDirectoryName(asm.Location);

                    var native = ModuleInfo.GetModules().OfType<ModuleInfo>().FirstOrDefault(x => x.IsNative());
                    var selfmod = ModuleInfo.GetModules().OfType<ModuleInfo>().FirstOrDefault(x=>x.Id == "SaddledEdgeEditor");
                    if (native != null && selfmod != null)
                    {
                        var nativever = new System.Version(native.Version.Major, native.Version.Minor, native.Version.Revision);

                        var curfname = "";
                        var curver = new System.Version(0,0,0);
                        var re = new System.Text.RegularExpressions.Regex("^MBEditor.([0-9]+).([0-9]+).([0-9]+).dll$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        foreach (var filename in System.IO.Directory.GetFiles(dir, "MBEditor*.dll", System.IO.SearchOption.TopDirectoryOnly))
                        {
                            var fpart = System.IO.Path.GetFileName(filename);
                            var m = re.Match(fpart);
                            if (m.Success)
                            {
                                var fver = new System.Version(int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value), int.Parse(m.Groups[3].Value));
                                if (fver > curver)
                                {
                                    curver = fver;
                                    curfname = filename;
                                    if (fver == nativever)
                                        break;
                                }
                            }
                        }
                        //System.AppDomain.CurrentDomain.load
                        if (!string.IsNullOrEmpty(curfname))
                        {
                            // not available in 1.3.1
                            //var doc = new System.Xml.XmlDocument();
                            //doc.LoadXml($@"<?xml version=""1.0"" encoding=""utf-8""?><SubModule><Name value=""MBEditor""/><DLLName value=""{System.IO.Path.GetFileName(curfname)}""/><SubModuleClassType value=""MBEditor.SubModule""/><Tags><Tag key=""DedicatedServerType"" value =""none"" /><Tag key=""IsNoRenderModeElement"" value =""false"" /></Tags></SubModule>");
                            //var mod = new SubModuleInfo();
                            //mod.LoadFrom(doc.DocumentElement, curfname);
                            //selfmod.SubModules.Add(mod);
                            

                            var modasm = System.Reflection.Assembly.LoadFrom(curfname);
                            if (modasm != null)
                            {
                                var t = modasm.GetType("MBEditor.SubModule");

                                // hack in the submodule
                                var module = TaleWorlds.MountAndBlade.Module.CurrentModule;
                                var submodules = module.GetType().GetField("_submodules", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(module) as System.Collections.Generic.List<MBSubModuleBase>;
                                if (submodules != null)
                                {
                                    var c = t.GetConstructor(new Type[0]);
                                    submodules.Add(c.Invoke(new object[0]) as MBSubModuleBase);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Debug("Exception on SubModule Load:");
                Log.Debug(ex.ToString());
            }

        }

    }
}

