
namespace Client.Ultima
{
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 1)]
    public struct HuedTile
    {
        internal short _id;
        internal short _hue;
        internal sbyte _z;

        public int ID
        {
            get { return _id; }
        }

        public int Hue
        {
            get { return _hue; }
        }

        public int Z
        {
            get { return _z; }
            set { _z = (sbyte)value; }
        }

        public HuedTile(short id, short hue, sbyte z)
        {
            _id = id;
            _hue = hue;
            _z = z;
        }

        public void Set(short id, short hue, sbyte z)
        {
            _id = id;
            _hue = hue;
            _z = z;
        }
    }
}
