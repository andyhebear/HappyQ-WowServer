using System.Collections.Generic;

namespace Client.Network
{
    public class PacketRegistry
    {
        private PacketHandler[] _handlers;

        private PacketHandler[] _extendedHandlersLow;
        private Dictionary<int, PacketHandler> _extendedHandlersHigh;

        public PacketHandler[] Handlers
        {
            get { return _handlers; }
        }

        public PacketRegistry()
        {
            _handlers = new PacketHandler[0x100];
            _extendedHandlersLow = new PacketHandler[0x100];
            _extendedHandlersHigh = new Dictionary<int, PacketHandler>();
        }

        public void Register(int packetID, int length, bool ingame, OnPacketReceive onReceive)
        {
            _handlers[packetID] = new PacketHandler(packetID, length, onReceive);
        }

        public PacketHandler GetHandler(int packetID)
        {
            return _handlers[packetID];
        }

        public void RegisterExtended(int packetID, OnPacketReceive onReceive)
        {
            if (packetID >= 0 && packetID < 0x100)
                _extendedHandlersLow[packetID] = new PacketHandler(packetID, 0, onReceive);
            else
                _extendedHandlersHigh[packetID] = new PacketHandler(packetID, 0, onReceive);
        }

        public PacketHandler GetExtendedHandler(int packetID)
        {
            if (packetID >= 0 && packetID < 0x100)
                return _extendedHandlersLow[packetID];

            PacketHandler handler;
            _extendedHandlersHigh.TryGetValue(packetID, out handler);
            return handler;
        }

        public void RemoveExtendedHandler(int packetID)
        {
            if (packetID >= 0 && packetID < 0x100)
                _extendedHandlersLow[packetID] = null;
            else
                _extendedHandlersHigh.Remove(packetID);
        }
    }
}
