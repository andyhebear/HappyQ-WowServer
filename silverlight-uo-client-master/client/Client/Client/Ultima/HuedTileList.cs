
namespace Client.Ultima
{
    public class HuedTileList
    {
        private HuedTile[] _tiles;
        private int _count;

        public int Count
        {
            get { return _count; }
        }

        public HuedTileList()
        {
            _tiles = new HuedTile[8];
            _count = 0;
        }

        public void Add(short id, short hue, sbyte z)
        {
            if ((_count + 1) > _tiles.Length)
            {
                HuedTile[] old = _tiles;
                _tiles = new HuedTile[old.Length * 2];

                for (int i = 0; i < old.Length; ++i)
                    _tiles[i] = old[i];
            }

            _tiles[_count++].Set(id, hue, z);
        }

        public HuedTile[] ToArray()
        {
            HuedTile[] tiles = new HuedTile[_count];

            for (int i = 0; i < _count; ++i)
                tiles[i] = _tiles[i];

            _count = 0;

            return tiles;
        }
    }
}
