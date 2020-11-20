using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MBEditor.Tabs;
using Newtonsoft.Json.Linq;

namespace MBEditor
{
    public class GlobalState : IStateSerializer
    {
        public static GlobalState Instance  = new GlobalState();

        public bool? LoggingEnabled = null;
        //public bool AutoSize = true;
        //public AutoSizeMode AutoSizeMode = AutoSizeMode.GrowAndShrink;
        //public SizeF AutoScaleDimensions = new SizeF(6F, 13F);
        //public AutoScaleMode AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

        public string SettingsName => "Global";

        public Newtonsoft.Json.Linq.JObject SaveSettings()
        {
            return new JObject {
                {"LoggingEnabled", JToken.FromObject(this.LoggingEnabled.HasValue && this.LoggingEnabled.Value )}
                //  {"AutoSize", JToken.FromObject(this.AutoSize)}
                //, {"AutoSizeMode", JToken.FromObject(this.AutoSizeMode.ToString())}
                //, {"AutoScaleDimensions", JToken.FromObject(this.AutoScaleDimensions)}
                //, {"AutoScaleMode", JToken.FromObject(this.AutoScaleMode.ToString())}
            };
        }

        public void ReadSettings(Newtonsoft.Json.Linq.JToken jObject)
        {
            try {
                this.LoggingEnabled = bool.TryParse(jObject["LoggingEnabled"]?.ToString() ?? "false", out var _enable) && _enable;
                //this.AutoSize = jObject["AutoSize"]?.ToObject<bool>() ?? this.AutoSize;
                //this.AutoSizeMode = jObject["AutoSize"]?.ToObject<AutoSizeMode>() ?? this.AutoSizeMode;
                //this.AutoScaleDimensions = jObject["AutoSize"]?.ToObject<SizeF>() ?? this.AutoScaleDimensions;
                //this.AutoScaleMode = jObject["AutoSize"]?.ToObject<AutoScaleMode>() ?? this.AutoScaleMode;
            }
            catch (Exception e) {
                Log.Debug(e.ToString());
            }
        }
    }
}
