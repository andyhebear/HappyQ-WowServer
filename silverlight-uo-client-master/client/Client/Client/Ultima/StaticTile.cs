
namespace Client.Ultima
{
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 1)]
    public struct StaticTile
    {
        public short ID;
        public byte X;
        public byte Y;
        public sbyte Z;
        public short Hue;
    }
}
