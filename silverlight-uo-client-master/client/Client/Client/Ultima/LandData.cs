
namespace Client.Ultima
{
    public struct LandData
    {
        private readonly string _name;
        private readonly TileFlag _flags;

        public LandData(string name, TileFlag flags)
        {
            _name = name;
            _flags = flags;
        }

        public string Name
        {
            get { return _name; }
        }

        public TileFlag Flags
        {
            get { return _flags; }
        }
    }
}
