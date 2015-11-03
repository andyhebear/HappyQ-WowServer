using System.Windows;
using Microsoft.Xna.Framework.Graphics;

namespace Client.Graphics
{
    public sealed class GBuffer
    {
        private readonly Engine _engine;

        private RenderTarget2D _diffuseTarget;
        private RenderTarget2D _normalTarget;
        private RenderTarget2D _lightingTarget;
        private RenderTarget2D _combineTarget;

        private bool _drawSurfaceSizeChanged;
        private bool _isDeferredLightingEnabled;

        public bool IsDeferredLightingEnabled
        {
            get { return _isDeferredLightingEnabled; }
            set { _isDeferredLightingEnabled = value; }
        }

        public Texture2D DiffuseTexture
        {
            get { return _diffuseTarget; }
        }

        public Texture2D NormalTexture
        {
            get { return _normalTarget; }
        }

        public Texture2D LightingTexture
        {
            get { return _lightingTarget; }
        }

        public Texture2D FinalTexture
        {
            get { return _combineTarget; }
        }

        public GBuffer(Engine engine)
        {
            _engine = engine;
            _engine.DrawingSurface.SizeChanged += new SizeChangedEventHandler(OnDrawingSurfaceSizeChanged);

            _drawSurfaceSizeChanged = true;
        }

        private void InitializeTargets()
        {
            PresentationParameters pp = _engine.GraphicsDevice.PresentationParameters;

            _diffuseTarget = new RenderTarget2D(_engine.GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None);
            _normalTarget = new RenderTarget2D(_engine.GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None);
            _lightingTarget = new RenderTarget2D(_engine.GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None);
            _combineTarget = new RenderTarget2D(_engine.GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None);
        }

        public void BeginDraw()
        {
            if (_drawSurfaceSizeChanged)
            {
                _drawSurfaceSizeChanged = false;
                InitializeTargets();
            }
        }

        public void BeginClear()
        {
            _engine.GraphicsDevice.SetRenderTargets(_diffuseTarget, _normalTarget, _lightingTarget, _combineTarget);
        }

        public void End()
        {
            _engine.GraphicsDevice.SetRenderTargets(null);
        }

        public void BeginRenderPass()
        {
            _engine.GraphicsDevice.SetRenderTargets(_diffuseTarget, _normalTarget);
        }

        public void BeginLightingPass()
        {
            _engine.GraphicsDevice.SetRenderTargets(_lightingTarget);
        }

        public void BeginCombine()
        {

        }

        private void OnDrawingSurfaceSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _drawSurfaceSizeChanged = true;
        }
    }
}
