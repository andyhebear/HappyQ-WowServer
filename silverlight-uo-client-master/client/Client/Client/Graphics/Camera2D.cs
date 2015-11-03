using System.Windows;
using Microsoft.Xna.Framework;

namespace Client.Graphics
{
    public class Camera2D : ICamera
    {
        private readonly Engine _engine;

        private int _width;
        private int _height;
        private int _nearClip;
        private int _farClip = 1;
        private bool _projectionDirty;
        private bool _transformDirty;
        private bool _boundingFrustumDirty;
        private Vector3 _position;
        private Vector2 _halfVector;
        private Matrix _view;
        private Matrix _projection;
        private BoundingFrustum _boundingFrustum;

        public BoundingFrustum BoundingFrustum
        {
            get
            {
                if (_boundingFrustumDirty)
                {
                    _boundingFrustumDirty = false;
                    _boundingFrustum = new BoundingFrustum(Projection);
                }

                return _boundingFrustum;
            }
        }

        public Matrix Projection
        {
            get
            {
                if (_projectionDirty)
                {
                    _projectionDirty = false;
                    Matrix.CreateOrthographic(_width, _height, _nearClip, _farClip, out _projection);
                }

                return _projection;
            }
        }

        public Vector2 Position
        {
            get { return new Vector2(_position.X, _position.Y); }
            set
            {
                _position.X = value.X;
                _position.Y = value.Y;
                _transformDirty = true;
                _boundingFrustumDirty = true;
            }
        }

        public int NearClip
        {
            get { return _nearClip; }
            set
            {
                _nearClip = value;
                _projectionDirty = true;
                _boundingFrustumDirty = true;
            }
        }

        public int FarClip
        {
            get { return _farClip; }
            set
            {
                _farClip = value;
                _projectionDirty = true;
                _boundingFrustumDirty = true;
            }
        }

        public Vector2 HalfVector
        {
            get { return _halfVector; }
        }

        public Camera2D(Engine engine)
        {
            _projectionDirty = true;
            _transformDirty = true;
            _boundingFrustumDirty = true;

            _engine = engine;
            _engine.DrawingSurface.SizeChanged += OnDrawingSurfaceSizeChanged;

            _width = (int)engine.DrawingSurface.ActualWidth;
            _height = (int)engine.DrawingSurface.ActualHeight;
        }

        void OnDrawingSurfaceSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _width = (int)_engine.DrawingSurface.ActualWidth;
            _height = (int)_engine.DrawingSurface.ActualHeight;
            _halfVector = new Vector2(1f / _width, 1f / _height);
            _projectionDirty = true;
            _boundingFrustumDirty = true;
        }
    }
}
