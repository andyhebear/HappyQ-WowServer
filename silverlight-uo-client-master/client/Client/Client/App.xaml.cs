using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using Client.Diagnostics;
using Client.IO;

namespace Client
{
    public partial class App
    {
        private static ContentHost _gameHost;
        private static GameHost _clientControl;

        public App()
        {
            Startup += Application_Startup;
            Exit += Application_Exit;
            UnhandledException += Application_UnhandledException;

            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //CheckAndDownloadUpdateCompleted += Current_CheckAndDownloadUpdateCompleted;
            //CheckAndDownloadUpdateAsync();

            Host.Settings.EnableFrameRateCounter = true;
            Host.Settings.MaxFrameRate = int.MaxValue;

            if (Debugger.IsAttached)
                new DebugTraceListener { TraceLevel = TraceLevels.Verbose };

            if (IsRunningOutOfBrowser)
                new DebugLogTraceListener(Path.Combine(Paths.LogsDirectory, "debug.txt"));

            _gameHost = new ContentHost();

            if (IsRunningOutOfBrowser)
            {
                _clientControl = new GameHost();
                _gameHost.LayoutRoot.Children.Add(_clientControl);
            }
            else
            {
                _gameHost.LayoutRoot.Children.Add(new InstallPrompt());
            }

            RootVisual = _gameHost;
        }

        //void Current_CheckAndDownloadUpdateCompleted(object sender, CheckAndDownloadUpdateCompletedEventArgs e)
        //{
        //    if (e.Error != null)
        //    {
        //        MessageBox.Show(e.Error.ToString());
        //    }
        //}

        private static void Application_Exit(object sender, EventArgs e)
        {
            Tracer.Info("Exiting...\n\n");
        }

        private static void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                Tracer.Error(errorMsg);
                e.Handled = true;

                var control = new ExceptionControl();
                var viewModel = new ExceptionViewModel();

                viewModel.Exception = GenerateCrashReport(e.ExceptionObject);
                control.DataContext = viewModel;

                _gameHost.LayoutRoot.Children.Clear();
                _gameHost.LayoutRoot.Children.Add(control);
            }
            catch
            {
                try
                {
                    MessageBox.Show(e.ExceptionObject.ToString());
                }
                catch
                {
                    ReportErrorToDOM(e.ExceptionObject);
                }
            }
        }

        private static void ReportErrorToDOM(Exception e)
        {
            try
            {
                string errorMsg = e.Message + e.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception ex)
            {
                Tracer.Error(ex);
            }
        }

        private static string GenerateCrashReport(Exception e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();


                sb.AppendLine("Server Crash Report");
                sb.AppendLine("===================");
                sb.AppendLine();
                //sb.AppendFormat("Silverlight UO Client Version {0}.{1}, Build {2}.{3}\n", version.Major, version.Minor, version.Build, version.Revision);
                sb.AppendFormat("Operating System: {0}\n", Environment.OSVersion);
                sb.AppendFormat("Silverlight Framework: {0}\n", Environment.Version);
                sb.AppendFormat("Time: {0}\n", DateTime.Now);
                sb.AppendFormat("HasElevatedPermissions: {0}", Current.HasElevatedPermissions);
                sb.AppendFormat("IsRunningOutOfBrowser: {0}", Current.IsRunningOutOfBrowser);
                sb.AppendLine("Exception:");
                sb.AppendLine(e.ToString());
                sb.AppendLine();

                return sb.ToString();
            }
            catch
            {
                return e.ToString();
            }
        }
    }
}