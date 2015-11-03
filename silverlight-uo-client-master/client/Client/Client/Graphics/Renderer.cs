using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Client.Graphics
{
    public class DeferredRenderer
    {
        private readonly Engine _engine;
        private readonly VertexPositionTexture[] _quadVertices;
        private readonly ushort[] _quadIndices;

        private readonly VertexPositionTexture[] _vertices;
        //private readonly ushort[] _indices;

        private int _currentVertex;

        List<Texture2D> _textures = new List<Texture2D>();

        public GraphicsDevice GraphicsDevice
        {
            get { return _engine.GraphicsDevice; }
        }

        public DeferredRenderer(Engine engine)
        {
            _engine = engine;

            _vertices = new VertexPositionTexture[16384];
            //_indices = new ushort[3072];

            for (int i = 0; i < _vertices.Length; i+=4)
            {
                _vertices[i + 0].TextureCoordinate = new Vector2(1,1);
                _vertices[i + 1].TextureCoordinate = new Vector2(0,1);
                _vertices[i + 2].TextureCoordinate = new Vector2(1,0);
                _vertices[i + 3].TextureCoordinate = new Vector2(0,0);
            }

            //for (int i = 0; i < _indices.Length; i += 6)
            //{
            //    _indices[i + 0] = (ushort)(i + 0);
            //    _indices[i + 1] = (ushort)(i + 1);
            //    _indices[i + 2] = (ushort)(i + 2);
            //    _indices[i + 3] = (ushort)(i + 2);
            //    _indices[i + 4] = (ushort)(i + 1);
            //    _indices[i + 5] = (ushort)(i + 3);
            //}

            _quadVertices = new[]
            {
                new VertexPositionTexture(
                    new Vector3(0,0,1),
                    new Vector2(0,0)),
                new VertexPositionTexture(
                    new Vector3(0,0,1),
                    new Vector2(0,1)),
                new VertexPositionTexture(
                    new Vector3(0,0,1),
                    new Vector2(1,0)),
                new VertexPositionTexture(
                    new Vector3(0,0,1),
                    new Vector2(1,1))
            };

            _quadIndices = new ushort[] { 0, 1, 2, 2, 1, 3 };
        }

        public void DrawQuad(Vector2 v1, Vector2 v2)
        {
            _quadVertices[0].Position.X = v1.X;
            _quadVertices[0].Position.Y = v1.Y;

            _quadVertices[1].Position.X = v1.X;
            _quadVertices[1].Position.Y = v2.Y;

            _quadVertices[2].Position.X = v2.X;
            _quadVertices[2].Position.Y = v1.Y;

            _quadVertices[3].Position.X = v2.X;
            _quadVertices[3].Position.Y = v2.Y;

            GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, _quadVertices, 0, 4, _quadIndices, 0, 2);
        }

        internal void QueueQuad(DrawState state, ref Vector2 tl, ref Vector2 tr, ref Vector2 bl, ref Vector2 br, Texture2D texture)
        {
            if (_currentVertex + 4 >= _vertices.Length)
                Flush(state);

            _vertices[_currentVertex + 0].Position.X = tl.X;
            _vertices[_currentVertex + 0].Position.Y = tl.Y;

            _vertices[_currentVertex + 1].Position.X = bl.X;
            _vertices[_currentVertex + 1].Position.Y = bl.Y;

            _vertices[_currentVertex + 2].Position.X = tr.X;
            _vertices[_currentVertex + 2].Position.Y = tr.Y;

            _vertices[_currentVertex + 3].Position.X = br.X;
            _vertices[_currentVertex + 3].Position.Y = br.Y;

            _currentVertex += 4;
            _textures.Add(texture);
        }

        internal void QueueQuad(DrawState state, Vector2 v1, Vector2 v2, Texture2D texture)
        {
            if (_currentVertex + 4 >= _vertices.Length)
                Flush(state);

            _vertices[_currentVertex + 0].Position.X = v1.X;
            _vertices[_currentVertex + 0].Position.Y = v1.Y;

            _vertices[_currentVertex + 1].Position.X = v1.X;
            _vertices[_currentVertex + 1].Position.Y = v2.Y;

            _vertices[_currentVertex + 2].Position.X = v2.X;
            _vertices[_currentVertex + 2].Position.Y = v1.Y;

            _vertices[_currentVertex + 3].Position.X = v2.X;
            _vertices[_currentVertex + 3].Position.Y = v2.Y;

            _currentVertex += 4;
            _textures.Add(texture);
        }

        internal void Flush(DrawState state)
        {
            if (_currentVertex == 0)
                return;

            GraphicsDevice device = state.GraphicsDevice;

            using (var vertexBuffer = new VertexBuffer(device, VertexPositionTexture.VertexDeclaration, _vertices.Length, BufferUsage.None))
            {
                using (var indexBuffer = new IndexBuffer(device, IndexElementSize.SixteenBits, _quadIndices.Length, BufferUsage.None))
                {
                    vertexBuffer.SetData(_vertices, 0, _vertices.Length);
                    indexBuffer.SetData(_quadIndices, 0, _quadIndices.Length);

                    device.Indices = indexBuffer;
                    device.SetVertexBuffer(vertexBuffer);

                    for (int i = 0; i < _textures.Count; i++)
                    {
                        device.Textures[0] = _textures[i];
                        device.DrawIndexedPrimitives(PrimitiveType.TriangleList, i * 4, 0, 4, 0, 2);
                    }

                    device.SetVertexBuffer(null);
                    device.Indices = null;
                }
            }

            _currentVertex = 0;
            _textures.Clear();
        }
    }
}
