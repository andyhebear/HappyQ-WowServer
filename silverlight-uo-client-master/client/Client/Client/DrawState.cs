using System;
using System.Collections.Generic;
using Client.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client
{
    public class DrawState
    {
        private TimeSpan _totalGameTime;
        private TimeSpan _elapsedGameTime;
        private bool _isRunningSlowly;
        private GraphicsDevice _graphicsDevice;
        private ICamera _camera;
        private Stack<Matrix> _worldMatrixStack;
        private Stack<Matrix> _viewMatrixStack;
        private Stack<Matrix> _projectionMatrixStack;

        public GraphicsDevice GraphicsDevice
        {
            get { return _graphicsDevice; }
            internal set { _graphicsDevice = value; }
        }

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

        public ICamera Camera
        {
            get { return _camera; }
            internal set { _camera = value; }
        }

        public Matrix World
        {
            get { return _worldMatrixStack.Peek(); }
        }

        public Matrix WorldView
        {
            get { return World * View; }
        }

        public Matrix WorldViewProjection
        {
            get { return World * View * Projection; }
        }

        public Matrix ViewProjection
        {
            get { return View * Projection; }
        }

        public Matrix View
        {
            get { return _viewMatrixStack.Peek(); }
        }

        public Matrix Projection
        {
            get { return _projectionMatrixStack.Peek(); }
        }

        public PresentationParameters PresentationParameters
        {
            get { return _graphicsDevice.PresentationParameters; }
        }

        public DrawState()
        {
            _worldMatrixStack = new Stack<Matrix>();
            _viewMatrixStack = new Stack<Matrix>();
            _projectionMatrixStack = new Stack<Matrix>();

            _worldMatrixStack.Push(Matrix.Identity);
            _viewMatrixStack.Push(Matrix.Identity);
            _projectionMatrixStack.Push(Matrix.Identity);
        }

        internal void Reset()
        {
            _worldMatrixStack.Clear();
            _viewMatrixStack.Clear();
            _projectionMatrixStack.Clear();

            _worldMatrixStack.Push(Matrix.Identity);
            _viewMatrixStack.Push(Matrix.Identity);
            _projectionMatrixStack.Push(Matrix.Identity);
        }

        internal void PushWorld(Matrix world)
        {
            _worldMatrixStack.Push(world);
        }

        internal void PushView(Matrix view)
        {
            _viewMatrixStack.Push(view);
        }

        internal void PushProjection(Matrix projection)
        {
            _projectionMatrixStack.Push(projection);
        }

        internal void PopWorld()
        {
            _worldMatrixStack.Pop();
        }

        internal void PopProjection()
        {
            _projectionMatrixStack.Pop();
        }

        internal void PopView()
        {
            _viewMatrixStack.Pop();
        }
    }
}
