using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace MBEditor
{
    using System;
    using System.IO;

    public enum LogColor
    {
        Black,
        White,
        Red,
        Blue,
        Green,
        Magenta,
        Yellow,
        Cyan,
    }

    public static class Log
    {
        public static string LogPath = (Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Mount and Blade II Bannerlord\SaddledEdgeEditor");
        public static bool _enabled = true;

        private static Dictionary<LogColor, Color> _colors;

        public static Dictionary<LogColor, Color> Colors {
            get
            {
                if (_colors == null) {
                    _colors = new Dictionary<LogColor, Color>();
                    _colors[LogColor.Black] = Color.Black;
                    _colors[LogColor.White] = Color.White;
                    _colors[LogColor.Red] = new Color(1, 0, 0, 1);
                    _colors[LogColor.Blue] = new Color(0, 0, 1, 1);
                    _colors[LogColor.Green] = new Color(0, 1, 0, 1);
                    _colors[LogColor.Magenta] = new Color(1, 0, 1, 1);
                    _colors[LogColor.Yellow] = new Color(1, 1, 0, 1);
                    _colors[LogColor.Cyan] = new Color(0, 1, 1, 1);
                }
                return _colors;
            }
        }


        public static void Debug(string text)
        {
            if (!_enabled || (GlobalState.Instance.LoggingEnabled.HasValue && GlobalState.Instance.LoggingEnabled.Value == false))
                return;
            try
            {
                Directory.CreateDirectory(LogPath);
                using (var writer = File.AppendText(Path.Combine(LogPath, "Debug.log")))
                    writer.WriteLine(DateTime.Now.ToString("o") + ": " + text?.Trim() ?? "");
            }
            catch
            {
                _enabled = false;
            }
        }

        public static void Info(string text, LogColor color = LogColor.Red)
        {
            InformationManager.DisplayMessage(new InformationMessage(text, Colors[color]));
            Debug(text);
            System.Windows.Forms.Application.DoEvents();
        }
    }
}

