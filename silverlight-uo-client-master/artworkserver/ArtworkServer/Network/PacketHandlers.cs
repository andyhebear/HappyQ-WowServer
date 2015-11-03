/***************************************************************************
 *                             PacketHandlers.cs
 *                            -------------------
 *   begin                : May 1, 2002
 *   copyright            : (C) The RunUO Software Team
 *   email                : info@runuo.com
 *
 *   $Id: PacketHandlers.cs 698 2011-07-31 04:05:09Z mark $
 *
 ***************************************************************************/

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/


namespace ArtworkServer.Network
{
    public static class PacketHandlers
    {
        private static PacketHandler[] m_Handlers;

        public static PacketHandler[] Handlers
        {
            get { return m_Handlers; }
        }

        static PacketHandlers()
        {
            m_Handlers = new PacketHandler[0x100];
        }

        public static void Register(int packetID, int length, bool ingame, OnPacketReceive onReceive)
        {
            m_Handlers[packetID] = new PacketHandler(packetID, length, ingame, onReceive);
        }

        public static PacketHandler GetHandler(int packetID)
        {
            return m_Handlers[packetID];
        }
    }
}