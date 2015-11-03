using Microsoft.Xna.Framework.Graphics;

namespace Client.Graphics.Shaders
{
    public abstract class ShaderBase
    {
        private readonly SilverlightEffect _effect;

        public SilverlightEffect Effect
        {
            get { return _effect; }
        }

        protected ShaderBase(Engine engine, string assetName)
        {
            _effect = engine.Content.Load<SilverlightEffect>(assetName);
        }

        protected abstract void BindOverride(DrawState state);

        public virtual void Bind(DrawState state)
        {
            BindOverride(state);

            _effect.CurrentTechnique.Passes[0].Apply();
        }
    }
}
