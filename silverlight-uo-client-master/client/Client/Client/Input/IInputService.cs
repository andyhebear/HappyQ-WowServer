using System;
using System.Windows.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Client.Input
{
    interface IInputService
    {
        Key[] PressedKeys { get; }
        int[] PressedPlatformKeyCodes { get; }
        ButtonState RightMouseButtonState { get; }
        ButtonState LeftMouseButtonState { get; }
        Vector2 MousePosition { get; }
        event EventHandler<KeyStateEventArgs> KeyDown;
        event EventHandler<KeyStateEventArgs> KeyUp;
        event EventHandler<MouseStateEventArgs> MouseLeftDown;
        event EventHandler<MouseStateEventArgs> MouseLeftUp;
        event EventHandler<MouseStateEventArgs> MouseMove;
        event EventHandler<MouseStateEventArgs> MouseRightDown;
        event EventHandler<MouseStateEventArgs> MouseRightUp;
        event EventHandler<MouseStateEventArgs> MouseWheel;
        bool IsKeyDown(Key key);
        bool IsKeyUp(Key key);
        bool IsMouseDown(MouseButton button);
        bool IsMouseUp(MouseButton button);
        bool IsPlatformKeyCodeDown(int code);
        bool IsPlatformKeyCodeUp(int code);
    }
}
