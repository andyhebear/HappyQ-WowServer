using System;
using Microsoft.Xna.Framework.Graphics;

namespace Client.Graphics
{
    public static class GraphicsDeviceExtensions
    {
        public static int PrimitiveVertexCount(PrimitiveType primitiveType, int primitiveCount)
        {
            if (primitiveCount == 0)
                return 0;
            switch (primitiveType)
            {
                case PrimitiveType.LineList: return primitiveCount * 2;
                case PrimitiveType.LineStrip: return primitiveCount + 1;
                case PrimitiveType.TriangleList: return primitiveCount * 3;
                case PrimitiveType.TriangleStrip: return primitiveCount + 2;
                default: throw new ArgumentException("primitiveType");
            }
        }

        public static void DrawUserIndexedPrimitives<T>(
            this GraphicsDevice device,
            PrimitiveType primitiveType,
            T[] vertexData,
            int vertexOffset,
            int numVertices,
            ushort[] indexData,
            int indexOffset,
            int primitiveCount)
            where T : struct, IVertexType
        {
            DrawUserIndexedPrimitives(device, primitiveType,
                vertexData, vertexOffset, numVertices,
                indexData, indexOffset,
                primitiveCount, default(T).VertexDeclaration);
        }

        public static void DrawUserIndexedPrimitives<T>(
            this GraphicsDevice device,
            PrimitiveType primitiveType,
            T[] vertexData,
            int vertexOffset,
            int numVertices,
            ushort[] indexData,
            int indexOffset,
            int primitiveCount,
            VertexDeclaration vertexDeclaration)
            where T : struct
        {
            int indexCount = PrimitiveVertexCount(primitiveType, primitiveCount);

            using (var vertexBuffer = new VertexBuffer(device, vertexDeclaration, numVertices, BufferUsage.None))
            {
                using (var indexBuffer = new IndexBuffer(device, IndexElementSize.SixteenBits, indexCount, BufferUsage.None))
                {
                    vertexBuffer.SetData(vertexData, vertexOffset, numVertices);
                    indexBuffer.SetData(indexData, indexOffset, indexCount);

                    device.Indices = indexBuffer;
                    device.SetVertexBuffer(vertexBuffer);
                    device.DrawIndexedPrimitives(primitiveType, 0, 0, numVertices, 0, primitiveCount);

                    device.SetVertexBuffer(null);
                    device.Indices = null;
                }
            }
        }
    }
}
