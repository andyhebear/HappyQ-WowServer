using Microsoft.Xna.Framework.Graphics;

namespace Client.Graphics
{
    public interface ITexturFactory
    {
        Texture2D CreateLand(int index);
        Texture2D CreateStatic(int index);
    }
}
