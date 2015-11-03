using System.IO;
using Client.Configuration;

namespace Client.Ultima
{
    public class TileMatrix
    {
        private static HuedTileList[][] _lists;

        private readonly HuedTile[][][][][] _staticTiles;
        private readonly Tile[][][] _landTiles;

        private readonly Tile[] _invalidLandBlock;
        private readonly HuedTile[][][] _emptyStaticBlock;

        private readonly FileStream _mapStream;

        private readonly FileStream _indexStream;
        private readonly BinaryReader _indexReader;

        private readonly FileStream _staticsStream;

        private readonly int _blockWidth, _blockHeight;
        private readonly int _width, _height;

        public int BlockWidth
        {
            get { return _blockWidth; }
        }

        public int BlockHeight
        {
            get { return _blockHeight; }
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public HuedTile[][][] EmptyStaticBlock
        {
            get { return _emptyStaticBlock; }
        }

        public TileMatrix(Engine engine, int fileIndex, int mapID, int width, int height)
        {
            IConfigurationService configurationService = engine.Services.GetService<IConfigurationService>();

            _width = width;
            _height = height;
            _blockWidth = width >> 3;
            _blockHeight = height >> 3;

            if (fileIndex != 0x7F)
            {
                string ultimaOnlineDirectory = configurationService.GetValue<string>(ConfigSections.UltimaOnline, ConfigKeys.UltimaOnlineDirectory);

                if (Directory.Exists(ultimaOnlineDirectory))
                {
                    string mapPath = Path.Combine(ultimaOnlineDirectory, string.Format("map{0}.mul", fileIndex));

                    if (mapPath != null)
                        _mapStream = new FileStream(mapPath, FileMode.Open, FileAccess.Read, FileShare.Read);

                    string indexPath = Path.Combine(ultimaOnlineDirectory, string.Format("staidx{0}.mul", fileIndex));

                    if (File.Exists(indexPath))
                    {
                        _indexStream = new FileStream(indexPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                        _indexReader = new BinaryReader(_indexStream);
                    }

                    string staticsPath = Path.Combine(ultimaOnlineDirectory, string.Format("statics{0}.mul", fileIndex));

                    if (File.Exists(staticsPath))
                        _staticsStream = new FileStream(staticsPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                }
            }

            _emptyStaticBlock = new HuedTile[8][][];

            for (int i = 0; i < 8; ++i)
            {
                _emptyStaticBlock[i] = new HuedTile[8][];

                for (int j = 0; j < 8; ++j)
                {
                    _emptyStaticBlock[i][j] = new HuedTile[0];
                }
            }

            _invalidLandBlock = new Tile[196];

            _landTiles = new Tile[_blockWidth][][];
            _staticTiles = new HuedTile[_blockWidth][][][][];
        }

        public HuedTile[][][] GetStaticBlock(int x, int y)
        {
            if (x < 0 || y < 0 || x >= _blockWidth || y >= _blockHeight || _staticsStream == null || _indexStream == null)
                return _emptyStaticBlock;

            if (_staticTiles[x] == null)
                _staticTiles[x] = new HuedTile[_blockHeight][][][];

            HuedTile[][][] tiles = _staticTiles[x][y] ?? (_staticTiles[x][y] = ReadStaticBlock(x, y));

            return tiles;
        }

        public HuedTile[] GetStaticTiles(int x, int y)
        {
            HuedTile[][][] tiles = GetStaticBlock(x >> 3, y >> 3);

            return tiles[x & 0x7][y & 0x7];
        }

        public Tile[] GetLandBlock(int x, int y)
        {
            if (x < 0 || y < 0 || x >= _blockWidth || y >= _blockHeight || _mapStream == null) return _invalidLandBlock;

            if (_landTiles[x] == null)
                _landTiles[x] = new Tile[_blockHeight][];

            Tile[] tiles = _landTiles[x][y] ?? (_landTiles[x][y] = ReadLandBlock(x, y));

            return tiles;
        }

        public Tile GetLandTile(int x, int y)
        {
            Tile[] tiles = GetLandBlock(x >> 3, y >> 3);

            return tiles[((y & 0x7) << 3) + (x & 0x7)];
        }

        private unsafe HuedTile[][][] ReadStaticBlock(int x, int y)
        {
            if (_indexReader == null)
                return _emptyStaticBlock;

            _indexReader.BaseStream.Seek(((x * _blockHeight) + y) * 12, SeekOrigin.Begin);

            int lookup = _indexReader.ReadInt32();
            int length = _indexReader.ReadInt32();

            if (lookup < 0 || length <= 0)
            {
                return _emptyStaticBlock;
            }

            int count = length / 7;

            _staticsStream.Seek(lookup, SeekOrigin.Begin);

            StaticTile[] staTiles = new StaticTile[count];

            fixed (StaticTile* pTiles = staTiles)
            {
                byte[] buffer = new byte[length];
                _staticsStream.Read(buffer, 0, buffer.Length);

                using (MemoryStream stream = new MemoryStream(buffer))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    StaticTile* ptr = pTiles;
                    for (int i = 0; i < 64; i++)
                    {
                        ptr->ID = reader.ReadInt16();
                        ptr->X = reader.ReadByte();
                        ptr->Y = reader.ReadByte();
                        ptr->Z = reader.ReadSByte();
                        ptr->Hue = reader.ReadInt16();
                    }
                }

                if (_lists == null)
                {
                    _lists = new HuedTileList[8][];

                    for (int i = 0; i < 8; ++i)
                    {
                        _lists[i] = new HuedTileList[8];

                        for (int j = 0; j < 8; ++j)
                            _lists[i][j] = new HuedTileList();
                    }
                }

                HuedTileList[][] lists = _lists;

                StaticTile* pCur = pTiles, pEnd = pTiles + count;

                while (pCur < pEnd)
                {
                    lists[pCur->X & 0x7][pCur->Y & 0x7].Add((short)((pCur->ID & 0x3FFF) + 0x4000), pCur->Hue, pCur->Z);
                    ++pCur;
                }

                HuedTile[][][] tiles = new HuedTile[8][][];

                for (int i = 0; i < 8; ++i)
                {
                    tiles[i] = new HuedTile[8][];

                    for (int j = 0; j < 8; ++j)
                        tiles[i][j] = lists[i][j].ToArray();
                }

                return tiles;
            }
        }

        private unsafe Tile[] ReadLandBlock(int x, int y)
        {
            if (_mapStream == null)
                return _invalidLandBlock;

            _mapStream.Seek(((x * _blockHeight) + y) * 196 + 4, SeekOrigin.Begin);

            Tile[] tiles = new Tile[64];

            fixed (Tile* pTiles = tiles)
            {
                byte[] buffer = new byte[192];
                _mapStream.Read(buffer, 0, buffer.Length);

                using (MemoryStream stream = new MemoryStream(buffer))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    Tile* ptr = pTiles;
                    for (int i = 0; i < 64; i++)
                    {
                        ptr->_id = reader.ReadInt16();
                        ptr->_z = reader.ReadSByte();

                        ptr++;
                    }
                }
            }

            return tiles;
        }

        public void Dispose()
        {
            if (_mapStream != null)
                _mapStream.Close();

            if (_staticsStream != null)
                _staticsStream.Close();

            if (_indexReader != null)
                _indexReader.Close();
        }
    }
}
