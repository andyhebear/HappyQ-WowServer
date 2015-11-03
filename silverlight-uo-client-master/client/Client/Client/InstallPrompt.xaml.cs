using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Client
{
    public partial class InstallPrompt : UserControl
    {
        public InstallPrompt()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.InstallState != InstallState.Installed)
            {
                Application.Current.Install();

                RequiresInstallation.Visibility = Visibility.Collapsed;
                AlreadyInstalled.Visibility = Visibility.Visible;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Application.Current.InstallState == InstallState.Installed)
            {
                RequiresInstallation.Visibility = Visibility.Collapsed;
                AlreadyInstalled.Visibility = Visibility.Visible;
            }
            else
            {
                RequiresInstallation.Visibility = Visibility.Visible;
                AlreadyInstalled.Visibility = Visibility.Collapsed;
            }
        }
    }
}
