using System.Windows;
using System.Windows.Input;

namespace Client.Input
{
    public sealed class KeyStateEventArgs : RoutedEventArgs
    {
        public bool Handled { get; set; }
        public Key Key { get; private set; }
        public int PlatformKeyCode { get; private set; }

        public KeyStateEventArgs(Key key, int platformKeyCode)
        {
            Key = key;
            PlatformKeyCode = platformKeyCode;
        }
    }
}
