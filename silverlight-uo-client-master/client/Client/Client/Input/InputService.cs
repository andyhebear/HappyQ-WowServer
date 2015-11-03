using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Client.Input
{
    public sealed class InputService : IInputService
    {
        private readonly Control _rootControl;
        private readonly List<Key> _pressedKeys;
        private readonly List<int> _pressedPlatformKeyCodes;

        private bool _capturedFirstMouseMove;
        private Vector2 _mousePosition;
        private ButtonState _leftMouseButtonState;
        private ButtonState _rightMouseButtonState;

        public event EventHandler<KeyStateEventArgs> KeyUp;
        public event EventHandler<KeyStateEventArgs> KeyDown;
        public event EventHandler<MouseStateEventArgs> MouseLeftDown;
        public event EventHandler<MouseStateEventArgs> MouseLeftUp;
        public event EventHandler<MouseStateEventArgs> MouseRightDown;
        public event EventHandler<MouseStateEventArgs> MouseRightUp;
        public event EventHandler<MouseStateEventArgs> MouseWheel;
        public event EventHandler<MouseStateEventArgs> MouseMove;

        public Key[] PressedKeys
        {
            get { return _pressedKeys.ToArray(); }
        }

        public int[] PressedPlatformKeyCodes
        {
            get { return _pressedPlatformKeyCodes.ToArray(); }
        }

        public Vector2 MousePosition
        {
            get { return _mousePosition; }
        }

        public ButtonState LeftMouseButtonState
        {
            get { return _leftMouseButtonState; }
        }

        public ButtonState RightMouseButtonState
        {
            get { return _rightMouseButtonState; }
        }

        public InputService(Engine engine)
        {
            _pressedKeys = new List<Key>();
            _pressedPlatformKeyCodes = new List<int>();

            _rootControl = engine.RootControl;

            _rootControl.KeyDown += OnRootControlKeyDown;
            _rootControl.KeyUp += OnRootControlKeyUp;

            _rootControl.MouseLeftButtonDown += OnRootControlMouseLeftButtonDown;
            _rootControl.MouseLeftButtonUp += OnRootControlMouseLeftButtonUp;
            _rootControl.MouseRightButtonDown += OnRootControlMouseRightButtonDown;
            _rootControl.MouseRightButtonUp += OnRootControlMouseRightButtonUp;
            _rootControl.MouseMove += OnRootControlMouseMove;
            _rootControl.MouseWheel += OnRootControlMouseWheel;
        }

        private void OnRootControlMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var handler = MouseWheel;

            if (handler != null)
                handler(e, new MouseStateEventArgs(_mousePosition, Vector2.Zero, MouseButton.None, 0, e.Delta));
        }

        private void OnRootControlMouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point point = e.GetPosition(_rootControl);

            Vector2 previousPosition = _mousePosition;

            _mousePosition.X = (int)point.X;
            _mousePosition.Y = (int)point.Y;

            if (!_capturedFirstMouseMove)
            {
                _capturedFirstMouseMove = true;
                return;
            }

            Vector2 delta;

            delta.X = _mousePosition.X - previousPosition.X;
            delta.Y = -(_mousePosition.Y - previousPosition.Y);

            var handler = MouseMove;

            if (handler != null)
                handler(e, new MouseStateEventArgs(_mousePosition, delta, MouseButton.None, 0, 0));

        }

        private void OnRootControlMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            _rightMouseButtonState = ButtonState.Pressed;

            var handler = MouseRightDown;

            if (handler != null)
                handler(e, new MouseStateEventArgs(_mousePosition, Vector2.Zero, MouseButton.Right, e.ClickCount, 0));
        }

        private void OnRootControlMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            _rightMouseButtonState = ButtonState.Released;

            var handler = MouseRightUp;

            if (handler != null)
                handler(e, new MouseStateEventArgs(_mousePosition, Vector2.Zero, MouseButton.Right, e.ClickCount, 0));
        }

        private void OnRootControlMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _leftMouseButtonState = ButtonState.Pressed;

            var handler = MouseLeftDown;

            if (handler != null)
                handler(e, new MouseStateEventArgs(_mousePosition, Vector2.Zero, MouseButton.Left, e.ClickCount, 0));
        }

        private void OnRootControlMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _leftMouseButtonState = ButtonState.Released;

            var handler = MouseLeftUp;

            if (handler != null)
                handler(e, new MouseStateEventArgs(_mousePosition, Vector2.Zero, MouseButton.Left, e.ClickCount, 0));
        }

        private void OnRootControlKeyUp(object sender, KeyEventArgs e)
        {
            _pressedKeys.Remove(e.Key);
            _pressedPlatformKeyCodes.Remove(e.PlatformKeyCode);

            var handler = KeyUp;

            if (handler != null)
                handler(sender, new KeyStateEventArgs(e.Key, e.PlatformKeyCode));
        }

        private void OnRootControlKeyDown(object sender, KeyEventArgs e)
        {
            _pressedKeys.Add(e.Key);
            _pressedPlatformKeyCodes.Add(e.PlatformKeyCode);

            var handler = KeyDown;

            if (handler != null)
                handler(sender, new KeyStateEventArgs(e.Key, e.PlatformKeyCode));
        }

        public bool IsMouseUp(MouseButton button)
        {
            return !IsMouseDown(button);
        }

        public bool IsMouseDown(MouseButton button)
        {
            Asserter.Assert(button != MouseButton.None, "button cannot equal MouseButton.None");

            if (button == MouseButton.Left)
                return _leftMouseButtonState == ButtonState.Pressed;

            return _rightMouseButtonState == ButtonState.Pressed;
        }

        public bool IsKeyUp(Key key)
        {
            return !IsKeyDown(key);
        }

        public bool IsKeyDown(Key key)
        {
            return _pressedKeys.Contains(key);
        }

        public bool IsPlatformKeyCodeUp(int code)
        {
            return !IsPlatformKeyCodeDown(code);
        }

        public bool IsPlatformKeyCodeDown(int code)
        {
            return _pressedPlatformKeyCodes.Contains(code);
        }
    }
}
