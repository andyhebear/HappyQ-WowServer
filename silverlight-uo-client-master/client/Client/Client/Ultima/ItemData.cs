
namespace Client.Ultima
{
    public struct ItemData
    {
        internal string _name;
        internal TileFlag _flags;
        internal byte _weight;
        internal byte _quality;
        internal byte _quantity;
        internal byte _value;
        internal byte _height;
        internal short _animation;

        public ItemData(string name, TileFlag flags, int weight, int quality, int quantity, int value, int height, int anim)
        {
            _name = name;
            _flags = flags;
            _weight = (byte)weight;
            _quality = (byte)quality;
            _quantity = (byte)quantity;
            _value = (byte)value;
            _height = (byte)height;
            _animation = (short)anim;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Animation
        {
            get { return _animation; }
        }

        public TileFlag Flags
        {
            get { return _flags; }
        }

        public bool Background
        {
            get { return ((_flags & TileFlag.Background) != 0); }
        }

        public bool Bridge
        {
            get { return ((_flags & TileFlag.Bridge) != 0); }
        }

        public bool Impassable
        {
            get { return ((_flags & TileFlag.Impassable) != 0); }
        }

        public bool Surface
        {
            get { return ((_flags & TileFlag.Surface) != 0); }
        }

        public int Weight
        {
            get { return _weight; }
        }

        public int Quality
        {
            get { return _quality; }
        }

        public int Quantity
        {
            get { return _quantity; }
        }

        public int Value
        {
            get { return _value; }
        }

        public int Height
        {
            get { return _height; }
        }

        public int CalcHeight
        {
            get
            {
                if ((_flags & TileFlag.Bridge) != 0)
                    return _height / 2;

                return _height;
            }
        }
    }
}
