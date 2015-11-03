using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client
{
    public class Cube
    {
        readonly GraphicsDevice graphicsDevice;
        readonly VertexBuffer vertexBuffer;
        readonly IndexBuffer indexBuffer;
        readonly SilverlightEffect mySilverlightEffect;
        readonly SilverlightEffectParameter textureParameter;
        readonly SilverlightEffectParameter worldViewProjectionParameter;
        readonly SilverlightEffectParameter lightDirectionParameter;

        public int VerticesCount { get; private set; }

        public int FaceCount { get; private set; }

        public Matrix WorldViewProjection
        {
            set
            {
                worldViewProjectionParameter.SetValue(value);
            }
        }

        public Vector3 LightDirection
        {
            set
            {
                lightDirectionParameter.SetValue(value);
            }
        }

        public Texture2D Texture
        {
            get;
            set;
        }

        public Cube(Engine engine, float size)
        {
            this.graphicsDevice = engine.GraphicsDevice;
            this.mySilverlightEffect = engine.Content.Load<SilverlightEffect>("CustomEffect");

            // Cache effect parameters
            worldViewProjectionParameter = mySilverlightEffect.Parameters["WorldViewProjection"];
            //lightDirectionParameter = mySilverlightEffect.Parameters["LightDirection"];

            // Init static parameters
            //this.LightDirection = new Vector3(0, 0, 1);

            // Temporary lists
            List<VertexPositionNormalTexture> vertices = new List<VertexPositionNormalTexture>();
            List<ushort> indices = new List<ushort>();

            // A cube has six faces, each one pointing in a different direction.
            Vector3[] normals =
            {
                new Vector3(0, 0, 1),
                new Vector3(0, 0, -1),
                new Vector3(1, 0, 0),
                new Vector3(-1, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(0, -1, 0)
            };

            // Create each face in turn.
            foreach (Vector3 normal in normals)
            {
                // Get two vectors perpendicular to the face normal and to each other.
                Vector3 side1 = new Vector3(normal.Y, normal.Z, normal.X);
                Vector3 side2 = Vector3.Cross(normal, side1);

                // Six indices (two triangles) per face.
                indices.Add((ushort)vertices.Count);
                indices.Add((ushort)(vertices.Count + 1));
                indices.Add((ushort)(vertices.Count + 2));

                indices.Add((ushort)vertices.Count);
                indices.Add((ushort)(vertices.Count + 2));
                indices.Add((ushort)(vertices.Count + 3));

                vertices.Add(new VertexPositionNormalTexture((normal - side1 - side2) * size / 2, normal, new Vector2(0, 0)));
                vertices.Add(new VertexPositionNormalTexture((normal - side1 + side2) * size / 2, normal, new Vector2(1, 0)));
                vertices.Add(new VertexPositionNormalTexture((normal + side1 + side2) * size / 2, normal, new Vector2(1, 1)));
                vertices.Add(new VertexPositionNormalTexture((normal + side1 - side2) * size / 2, normal, new Vector2(0, 1)));
            }

            // Create a vertex buffer, and copy our vertex data into it.
            vertexBuffer = new VertexBuffer(graphicsDevice, VertexPositionNormalTexture.VertexDeclaration, vertices.Count, BufferUsage.None);

            vertexBuffer.SetData(0, vertices.ToArray(), 0, vertices.Count, VertexPositionNormalTexture.Stride);

            // Create an index buffer, and copy our index data into it.
            indexBuffer = new IndexBuffer(graphicsDevice, IndexElementSize.SixteenBits, indices.Count, BufferUsage.None);

            indexBuffer.SetData(0, indices.ToArray(), 0, indices.Count);

            // Statistics
            VerticesCount = vertices.Count;
            FaceCount = indices.Count / 3;
        }

        public void Draw()
        {
            foreach (var pass in mySilverlightEffect.CurrentTechnique.Passes)
            {
                // Apply pass
                pass.Apply();

                // Set vertex buffer and index buffer
                graphicsDevice.SetVertexBuffer(vertexBuffer);
                graphicsDevice.Indices = indexBuffer;
                graphicsDevice.Textures[0] = Texture;

                // The shaders are already set so we can draw primitives
                graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, VerticesCount, 0, FaceCount);
            }
        }
    }
}