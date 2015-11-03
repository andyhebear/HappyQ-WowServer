
using System.IO;
using System.Text;

namespace Client
{
    public static class ByteArrayExtensions
    {
        public static string ToFormattedString(this byte[] buffer)
        {
            return buffer.ToFormattedString(buffer.Length);
        }

        public static string ToFormattedString(this byte[] buffer, int length)
        {
            MemoryStream stream = new MemoryStream(buffer);
            return stream.ToFormattedString();
        }

        public static void ToFormattedString(this byte[] buffer, int length, StringBuilder builder)
        {
            MemoryStream stream = new MemoryStream(buffer);
            stream.ToFormattedString(length, builder);
        }

        public static void ToFormattedString(this byte[] buffer, int length, StreamWriter writer)
        {
            MemoryStream stream = new MemoryStream(buffer);
            stream.ToFormattedString(length, writer);
        }
    }
}
