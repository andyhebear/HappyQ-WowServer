using System.Windows;
using System.Windows.Controls;
using System.Windows.Graphics;

using Client.Configuration;
using Client.Diagnostics;
using Client.Input;
using System;

namespace Client
{
    public partial class GameHost
    {
        private Engine _game;
        private bool _exception;

        public GameHost()
        {
            InitializeComponent();
        }

        private void OnDraw(object sender, DrawEventArgs e)
        {
            try
            {
                if (!_exception)
                {
                    _game.Tick(e.DeltaTime, e.TotalTime);
                    e.InvalidateSurface();
                }
            }
            catch (Exception ex)
            {
                if (!_exception)
                {
                    _exception = true;

                    Dispatcher.BeginInvoke(() =>
                    {
                        throw new EngineException(ex);
                    });
                }
            }
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            if (GraphicsDeviceManager.Current.RenderMode != RenderMode.Hardware)
            {
                MessageBox.Show("Please activate enableGPUAcceleration=true on your Silverlight plugin page.", "Warning", MessageBoxButton.OK);
                return;
            }

            IConfigurationService configurationService = new ConfigurationService();

            Tracer.TraceLevel = configurationService.GetValue<TraceLevels>(ConfigSections.Debug, ConfigKeys.DebugLogLevel);
            Tracer.Info("Checking for updates...");

            //Application.Current.CheckAndDownloadUpdateCompleted += Current_CheckAndDownloadUpdateCompleted;
            //Application.Current.CheckAndDownloadUpdateAsync();

            _game = new Engine(DrawingSurface);

            IInputService inputService = new InputService(_game);

            _game.Services.AddService(typeof(IConfigurationService), configurationService);
            _game.Services.AddService(typeof(IInputService), inputService);

            _game.Run();
        }
    }
}