using System.IO;
using Client.Diagnostics;
using Client.IO;

namespace Client.Configuration
{
    public sealed class ConfigurationService : IConfigurationService
    {
        private readonly ConfigFile _configFile;

        public ConfigurationService()
        {
            string file = Paths.ConfigFile;
            _configFile = new ConfigFile(file);

            if (!File.Exists(file))
                RestoreDefaults();
        }

        public void RestoreDefaults()
        {
            SetValue(ConfigSections.Graphics, ConfigKeys.GraphicsWidth, 1024);
            SetValue(ConfigSections.Graphics, ConfigKeys.GraphicsHeight, 768);

#if DEBUG
            SetValue(ConfigSections.Debug, ConfigKeys.DebugLogLevel, TraceLevels.Verbose);
#else
            SetValue(ConfigSections.Debug, ConfigKeys.LogLevel, TraceLevels.Warning);
#endif
        }

        public T GetValue<T>(string section, string key)
        {
            return _configFile.GetValue<T>(section, key);
        }

        public T GetValue<T>(string section, string key, T defaultValue)
        {
            return _configFile.GetValue<T>(section, key, defaultValue);
        }

        public void SetValue<T>(string section, string key, T value)
        {
            _configFile.SetValue(section, key, value);
        }
    }
}
