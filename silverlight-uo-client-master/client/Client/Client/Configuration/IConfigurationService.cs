
namespace Client.Configuration
{
    public interface IConfigurationService
    {
        T GetValue<T>(string section, string key);
        T GetValue<T>(string section, string key, T defaultValue);

        void SetValue<T>(string section, string key, T value);
    }
}
