namespace MBEditor
{
    public interface IStateSerializer
    {
        string SettingsName { get; }

        Newtonsoft.Json.Linq.JObject SaveSettings();

        void ReadSettings(Newtonsoft.Json.Linq.JToken jObject);
    }
}