using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.Graphics.Shaders
{
    public class DiffuseShader : ShaderBase
    {
        private readonly SilverlightEffectParameter _worldViewProjectionParamater;
        private readonly SilverlightEffectParameter _halfVectorParamater;

        public Matrix WorldViewProjection
        {
            set { _worldViewProjectionParamater.SetValue(value); }
        }

        public Vector2 HalfVector
        {
            set { _halfVectorParamater.SetValue(value); }
        }

        public DiffuseShader(Engine engine)
            : base(engine, "Shaders\\DiffuseEffect")
        {
            _worldViewProjectionParamater = Effect.Parameters["WorldViewProjection"];
            _halfVectorParamater = Effect.Parameters["HalfVector"];
        }

        protected override void BindOverride(DrawState state)
        {
            HalfVector = state.Camera.HalfVector;
            WorldViewProjection = state.WorldViewProjection;
        }
    }
}
