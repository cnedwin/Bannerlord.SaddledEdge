namespace SaddledEdgeModule
{
    using System;
    using System.IO;

    public static class Log
    {
        public static string LogPath = (Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Mount and Blade II Bannerlord\SaddledEdgeEditor");
        public static bool _enabled = true;

        public static void Debug(string text)
        {
            if (!_enabled) return;
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
    }
}

