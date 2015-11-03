using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VertexPositionNormalTexture
    {
        public Vector3 Position;
        public Vector3 Normal;
        public Vector2 TexCoords;

        public const int Stride = sizeof(float) * 8;

        public VertexPositionNormalTexture(Vector3 position, Vector3 normal, Vector2 texCoords)
        {
            Position = position;
            Normal = normal;
            TexCoords = texCoords;
        }

        public static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration
        (
            new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
            new VertexElement(12, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0),
            new VertexElement(24, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0)
        );
    }
}
