using System.Collections.Generic;

namespace Client
{
    public sealed class World
    {
        private Engine _engine;

        private Dictionary<Serial, Mobile> _mobiles;
        private Dictionary<Serial, Item> _items;

        public Dictionary<Serial, Mobile> Mobiles
        {
            get { return _mobiles; }
        }

        public Dictionary<Serial, Item> Items
        {
            get { return _items; }
        }

        public World(Engine engine)
        {
            _engine = engine;

            _mobiles = new Dictionary<Serial, Mobile>();
            _items = new Dictionary<Serial, Item>();
        }
    }
}
