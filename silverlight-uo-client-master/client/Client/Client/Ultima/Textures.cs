using System;
using System.IO;
using System.Windows.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.Ultima
{
    public class Textures
    {
        private readonly FileIndex _fileIndex;

        public Textures(Engine engine)
        {
            _fileIndex = new FileIndex(engine, "texidx.mul", "texmaps.mul", 0x1000, 10);
        }

        public unsafe Texture2D CreateTexture(int index)
        {
            if (!_fileIndex.FilesExist)
                return null;

            int length, extra;
            bool patched;

            Stream stream = _fileIndex.Seek(index, out length, out extra, out patched);

            if (stream == null)
                return null;

            int size = extra == 0 ? 64 : 128;
            int pixelCount = size * size;

            byte[] buffer = new byte[pixelCount * 2];
            ushort[] pixels = new ushort[pixelCount];
            Color[] colors = new Color[pixelCount];

            stream.Read(buffer, 0, buffer.Length);
            Buffer.BlockCopy(buffer, 0, pixels, 0, pixelCount * 2);

            //fixed (ushort* pPtr = pixels)
            //fixed (Color* cPtr = colors)
            //{
            //    ushort* pixelPtr = pPtr;
            //    Color* colorPtr = cPtr;

            //    int count = pixels.Length;

            //    for (int i = 0; i < count; i++)
            //    {
            //        ushort pixel = *pixelPtr;

            //        colorPtr->R = (byte)(pixel & 0x1F);
            //        colorPtr->G = (byte)((pixel >> 5) & 0x1F);
            //        colorPtr->B = (byte)((pixel >> 10) & 0x1F);
            //        colorPtr->A = 255;

            //        colorPtr++;
            //        pixelPtr++;
            //    }
            //}

            Texture2D texture = new Texture2D(GraphicsDeviceManager.Current.GraphicsDevice, size, size, false, SurfaceFormat.Bgra5551);
            texture.SetData(pixels);

            return texture;
        }

        const int multiplier = 0xFF / 0x1F;

        public unsafe void CreateTexture(int index, out Texture2D diffuseTexture, out Texture2D normalTexture)
        {
            diffuseTexture = null;
            normalTexture = null;

            if (!_fileIndex.FilesExist)
                return;

            int length, extra;
            bool patched;

            Stream stream = _fileIndex.Seek(index, out length, out extra, out patched);

            if (stream == null)
                return;

            int size = extra == 0 ? 64 : 128;
            int pixelCount = size * size;

            byte[] buffer = new byte[pixelCount * 2];
            ushort[] pixels = new ushort[pixelCount];
            Color[] colors = new Color[pixelCount];

            stream.Read(buffer, 0, buffer.Length);
            Buffer.BlockCopy(buffer, 0, pixels, 0, pixelCount * 2);

            fixed (ushort* pPtr = pixels)
            fixed (Color* cPtr = colors)
            {
                ushort* pixelPtr = pPtr;
                Color* colorPtr = cPtr;

                int count = pixels.Length;

                for (int i = 0; i < count; i++)
                {
                    colorPtr->R = (byte)((*pixelPtr & 0x1F) & multiplier);
                    colorPtr->G = (byte)(((*pixelPtr >> 5) & 0x1F) & multiplier);
                    colorPtr->B = (byte)(((*pixelPtr >> 10) & 0x1F) & multiplier);
                    colorPtr->A = 255;
                    colorPtr++;
                }
            }

            diffuseTexture = new Texture2D(GraphicsDeviceManager.Current.GraphicsDevice, size, size, false, SurfaceFormat.Color);
            diffuseTexture.SetData(colors);

            float[] heights = GenerateHeightFields(pixels, size);
            Vector3[] normals = GenerateNormalFields(heights, size, false);
            Color[] normalColors = new Color[heights.Length];

            fixed (Vector3* normal = normals)
            fixed (Color* color = normalColors)
            {
                Vector3* nPtr = normal;
                Color* cPtr = color;

                int count = normalColors.Length;

                for (int i = 0; i < count; i++)
                {
                    cPtr->R = (byte)(nPtr->X * 255);
                    cPtr->G = (byte)(nPtr->Y * 255);
                    cPtr->B = (byte)(nPtr->Z * 255);

                    nPtr++;
                    cPtr++;
                }
            }

            normalTexture = new Texture2D(GraphicsDeviceManager.Current.GraphicsDevice, size, size, false, SurfaceFormat.Color);
            normalTexture.SetData(normalColors);
        }

        private static float[] GenerateHeightFields(ushort[] pixels, int size)
        {
            float[] heights = new float[pixels.Length];

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    int c = (y * size) + x;
                    ushort pixel = pixels[c];
                    int b = (pixel >> 10) & 0x1F;
                    int g = (pixel >> 5) & 0x1F;
                    int r = (pixel & 0x1F);

                    heights[c] = ((b + g + r) / 3.0f) / 255.0f;
                }
            }

            return heights;
        }

        private static unsafe Vector3[] GenerateNormalFields(float[] heights, int size, bool wrap)
        {
            Vector3[] normals = new Vector3[heights.Length];

            const float dz = 1f / 8;

            fixed (Vector3* normal = normals)
            {
                Vector3* nPtr = normal;

                for (int y = 0; y < size; y++)
                {
                    for (int x = 0; x < size; x++)
                    {
                        int il;
                        int ir;
                        int it;
                        int ib;
                        int itl;
                        int itr;
                        int ibl;
                        int ibr;

                        if (wrap)
                        {
                            il = (y * size) + WrapU(x - 1, size);
                            ir = (y * size) + WrapU(x + 1, size);
                            it = (WrapV(y - 1, size) * size) + x;
                            ib = (WrapV(y + 1, size) * size) + x;
                            itl = (WrapV(y - 1, size) * size) + WrapU(x - 1, size);
                            itr = (WrapV(y - 1, size) * size) + WrapU(x + 1, size);
                            ibl = (WrapV(y + 1, size) * size) + WrapU(x - 1, size);
                            ibr = (WrapV(y + 1, size) * size) + WrapU(x + 1, size);
                        }
                        else
                        {
                            il = (y * size) + ClampZero(x - 1, size);
                            ir = (y * size) + ClampZero(x + 1, size);
                            it = (ClampZero(y - 1, size) * size) + x;
                            ib = (ClampZero(y + 1, size) * size) + x;
                            itl = (ClampZero(y - 1, size) * size) + ClampZero(x - 1, size);
                            itr = (ClampZero(y - 1, size) * size) + ClampZero(x + 1, size);
                            ibl = (ClampZero(y + 1, size) * size) + ClampZero(x - 1, size);
                            ibr = (ClampZero(y + 1, size) * size) + ClampZero(x + 1, size);
                        }

                        float l = heights[il];
                        float r = heights[ir];
                        float t = heights[it];
                        float b = heights[ib];
                        float tl = heights[itl];
                        float tr = heights[itr];
                        float bl = heights[ibl];
                        float br = heights[ibr];

                        float dx = tr + 2 * r + br - tl - 2 * l - bl;
                        float dy = bl + 2 * b + br - tl - 2 * t - tr;

                        nPtr->X = dx;
                        nPtr->Y = dy;
                        nPtr->Y = dz;
                        nPtr->Normalize();
                        nPtr->X = nPtr->X * 0.5f + 0.5f;
                        nPtr->Y = nPtr->Y * 0.5f + 0.5f;
                        nPtr->Z = nPtr->Z * 0.5f + 0.5f;

                        nPtr++;
                    }
                }
            }

            return normals;
        }

        private static int ClampZero(int i, int size)
        {
            if (i < 0)
                return 0;

            if (i == size)
                return size - 1;

            return i;
        }

        private static int WrapU(int u, int size)
        {
            if (u < 0)
                return size - 1;

            if (u == size)
                return 0;

            return u;
        }

        private static int WrapV(int v, int size)
        {
            if (v < 0)
                return size - 1;

            if (v == size)
                return 0;

            return v;
        }
    }
}
