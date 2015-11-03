using System.Windows;
using Microsoft.Xna.Framework;

namespace Client.Input
{
    public sealed class MouseStateEventArgs : RoutedEventArgs
    {
        public bool Handled { get; set; }

        public Vector2 Position { get; private set; }
        public Vector2 PositionDelta { get; private set; }
        public MouseButton Button { get; private set; }
        public int WheelDelta { get; private set; }
        public int ClickCount { get; private set; }

        public MouseStateEventArgs(Vector2 position, Vector2 positionDelta, MouseButton button, int clickCount, int wheelDelta)
        {
            Position = position;
            PositionDelta = positionDelta;
            Button = button;
            ClickCount = clickCount;
            WheelDelta = wheelDelta;
        }
    }
}
