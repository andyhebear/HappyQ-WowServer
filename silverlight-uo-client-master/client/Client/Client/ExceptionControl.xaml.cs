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
using System.Windows.Browser;

namespace Client
{
    public partial class ExceptionControl : UserControl
    {
        public ExceptionControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenURL.OpenBrowserWithURL(new Uri("http://code.google.com/p/silverlight-uo-client/issues/entry"));
        }

        public class OpenURL : HyperlinkButton
        {
            public static void OpenBrowserWithURL(Uri u)
            {
                var hlb = new OpenURL();
                hlb.TargetName = "_blank";
                hlb.NavigateUri = u;
                hlb.OnClick();
            }
        }
    }
}
