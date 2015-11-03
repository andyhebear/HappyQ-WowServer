using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Client
{
    public class UpdateState
    {
        private TimeSpan _totalGameTime;
        private TimeSpan _elapsedGameTime;
        private bool _isRunningSlowly;

        public TimeSpan TotalGameTime
        {
            get { return _totalGameTime; }
            internal set { _totalGameTime = value; }
        }

        public TimeSpan ElapsedGameTime
        {
            get { return _elapsedGameTime; }
            internal set { _elapsedGameTime = value; }
        }

        public bool IsRunningSlowly
        {
            get { return _isRunningSlowly; }
            internal set { _isRunningSlowly = value; }
        }
    }
}
