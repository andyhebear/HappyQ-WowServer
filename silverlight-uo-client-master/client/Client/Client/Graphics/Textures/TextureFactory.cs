using System;
using Client.Collections;
using Client.Ultima;
using Microsoft.Xna.Framework.Graphics;

namespace Client.Graphics
{
    public enum TextureType
    {
        Land,
        Static
    }

    public class TextureFactory : ITexturFactory, IUpdate
    {
        private readonly TimeSpan _cleanInterval = TimeSpan.FromMinutes(1);
        private readonly Texture2D _missingTexture;
        private readonly Cache<int, Texture2D> _landCache;
        private readonly Textures _textures;
        private DateTime _lastCacheClean;

        public Cache<int, Texture2D> LandCache
        {
            get { return _landCache; }
        }

        public TextureFactory(Engine engine)
        {
            _missingTexture = engine.Content.Load<Texture2D>("Textures\\missing-texture");
            _landCache = new Cache<int, Texture2D>(TimeSpan.FromMinutes(5), 0x1000);
            _lastCacheClean = DateTime.MinValue;
            _textures = new Textures(engine);
        }

        public Texture2D CreateLand(int index)
        {
            Texture2D texture = _landCache[index];

            if (texture != null)
                return texture;

            texture = _textures.CreateTexture(index);

            if (texture == null)
                return _missingTexture;

            return _landCache[index] = texture;
        }

        public Texture2D CreateStatic(int index)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateState state)
        {
            DateTime now = DateTime.Now;

            if (_lastCacheClean + _cleanInterval >= now)
                return;

            _landCache.Clean();
            _lastCacheClean = now;
        }
    }
}
