/***************************************************************************
 *                                Packets.cs
 *                            -------------------
 *   begin                : May 1, 2002
 *   copyright            : (C) The RunUO Software Team
 *   email                : info@runuo.com
 *
 *   $Id: Packets.cs 675 2011-06-29 03:29:14Z mark $
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

using System;
using System.IO;

namespace ArtworkServer.Network
{
    public abstract class Packet
    {
        [Flags]
        private enum State
        {
            Inactive = 0x00,
            Static = 0x01,
            Acquired = 0x02,
            Accessed = 0x04,
            Buffered = 0x08,
            Warned = 0x10
        }

        protected PacketWriter m_Stream;
        private int m_PacketID;
        private int m_Length;
        private State m_State;

        public int PacketID
        {
            get { return m_PacketID; }
        }

        protected Packet(int packetID)
        {
            m_PacketID = packetID;
        }

        public void EnsureCapacity(int length)
        {
            m_Stream = PacketWriter.CreateInstance(length);// new PacketWriter( length );
            m_Stream.Write((byte)m_PacketID);
            m_Stream.Write((short)0);
        }

        protected Packet(int packetID, int length)
        {
            m_PacketID = packetID;
            m_Length = length;

            m_Stream = PacketWriter.CreateInstance(length);// new PacketWriter( length );
            m_Stream.Write((byte)packetID);
        }

        public PacketWriter UnderlyingStream
        {
            get
            {
                return m_Stream;
            }
        }

        private const int BufferSize = 4096;
        private static BufferPool m_Buffers = new BufferPool("Compressed", 16, BufferSize);

        public static Packet SetStatic(Packet p)
        {
            p.SetStatic();
            return p;
        }

        public static Packet Acquire(Packet p)
        {
            p.Acquire();
            return p;
        }

        public static void Release(ref Packet p)
        {
            if (p != null)
                p.Release();

            p = null;
        }

        public static void Release(Packet p)
        {
            if (p != null)
                p.Release();
        }

        public void SetStatic()
        {
            m_State |= State.Static | State.Acquired;
        }

        public void Acquire()
        {
            m_State |= State.Acquired;
        }

        public void OnSend()
        {
            if ((m_State & (State.Acquired | State.Static)) == 0)
                Free();
        }

        private void Free()
        {
            if (m_CompiledBuffer == null)
                return;

            if ((m_State & State.Buffered) != 0)
                m_Buffers.ReleaseBuffer(m_CompiledBuffer);

            m_State &= ~(State.Static | State.Acquired | State.Buffered);

            m_CompiledBuffer = null;
        }

        public void Release()
        {
            if ((m_State & State.Acquired) != 0)
                Free();
        }

        private byte[] m_CompiledBuffer;
        private int m_CompiledLength;

        public byte[] Compile(bool compress, out int length)
        {
            if (m_CompiledBuffer == null)
            {
                if ((m_State & State.Accessed) == 0)
                {
                    m_State |= State.Accessed;
                }
                else
                {
                    if ((m_State & State.Warned) == 0)
                    {
                        m_State |= State.Warned;

                        try
                        {
                            using (StreamWriter op = new StreamWriter("net_opt.log", true))
                            {
                                op.WriteLine("Redundant compile for packet {0}, use Acquire() and Release()", this.GetType());
                                op.WriteLine(new System.Diagnostics.StackTrace());
                            }
                        }
                        catch
                        {
                        }
                    }

                    m_CompiledBuffer = new byte[0];
                    m_CompiledLength = 0;

                    length = m_CompiledLength;
                    return m_CompiledBuffer;
                }

                InternalCompile(compress);
            }

            length = m_CompiledLength;
            return m_CompiledBuffer;
        }

        private void InternalCompile(bool compress)
        {
            if (m_Length == 0)
            {
                long streamLen = m_Stream.Length;

                m_Stream.Seek(1, SeekOrigin.Begin);
                m_Stream.Write((ushort)streamLen);
            }
            else if (m_Stream.Length != m_Length)
            {
                int diff = (int)m_Stream.Length - m_Length;

                Console.WriteLine("Packet: 0x{0:X2}: Bad packet length! ({1}{2} bytes)", m_PacketID, diff >= 0 ? "+" : "", diff);
            }

            MemoryStream ms = m_Stream.UnderlyingStream;

            m_CompiledBuffer = ms.GetBuffer();
            int length = (int)ms.Length;

            if (compress)
            {
                m_CompiledBuffer = Compression.Compress(
                    m_CompiledBuffer, 0, length,
                    ref length
                );

                if (m_CompiledBuffer == null)
                {
                    Console.WriteLine("Warning: Compression buffer overflowed on packet 0x{0:X2} ('{1}') (length={2})", m_PacketID, GetType().Name, length);
                    using (StreamWriter op = new StreamWriter("compression_overflow.log", true))
                    {
                        op.WriteLine("{0} Warning: Compression buffer overflowed on packet 0x{1:X2} ('{2}') (length={3})", DateTime.Now, m_PacketID, GetType().Name, length);
                        op.WriteLine(new System.Diagnostics.StackTrace());
                    }
                }
            }

            if (m_CompiledBuffer != null)
            {
                m_CompiledLength = length;

                byte[] old = m_CompiledBuffer;

                if (length > BufferSize || (m_State & State.Static) != 0)
                {
                    m_CompiledBuffer = new byte[length];
                }
                else
                {
                    m_CompiledBuffer = m_Buffers.AcquireBuffer();
                    m_State |= State.Buffered;
                }

                Buffer.BlockCopy(old, 0, m_CompiledBuffer, 0, length);
            }

            PacketWriter.ReleaseInstance(m_Stream);
            m_Stream = null;
        }
    }
}
