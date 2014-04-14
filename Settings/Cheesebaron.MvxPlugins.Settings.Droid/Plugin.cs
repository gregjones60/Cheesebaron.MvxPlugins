using Cheesebaron.MvxPlugins.Settings.Interfaces;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Exceptions;
using Cirrious.CrossCore.Plugins;

namespace Cheesebaron.MvxPlugins.Settings.Droid
{
    public class Plugin 
        : IMvxConfigurablePlugin
    {
        private DroidCheeseSettingsConfiguration _config;
        private bool _loaded;

        public void Load()
        {
            if (_loaded) return;

            var fileName = "";
            if(_config != null)
                fileName = _config.SettingsFileName;

            var instance = new Settings(fileName);
            Mvx.RegisterSingleton<ISettings>(instance);

            _loaded = true;
        }

        public void Configure(IMvxPluginConfiguration configuration)
        {
            if (configuration != null && !(configuration is DroidCheeseSettingsConfiguration))
                throw new MvxException(
                    "Plugin configuration only supports instances of DroidCheeseSettingsConfiguration, you provided {0}",
                    configuration.GetType().Name);

            _config = (DroidCheeseSettingsConfiguration)configuration;
        }
    }

    public class DroidCheeseSettingsConfiguration
        : IMvxPluginConfiguration
    {
        public string SettingsFileName { get; set; }
    }
}