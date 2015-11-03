/***************************************************************************
 *                                NetState.cs
 *                            -------------------
 *   begin                : May 1, 2002
 *   copyright            : (C) The RunUO Software Team
 *   email                : info@runuo.com
 *
 *   $Id: NetState.cs 698 2011-07-31 04:05:09Z mark $
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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ArtworkServer.Network
{
    public interface IPacketEncoder
    {
        void EncodeOutgoingPacket(NetState to, ref byte[] buffer, ref int length);
        void DecodeIncomingPacket(NetState from, ref byte[] buffer, ref int length);
    }

    public delegate void NetStateCreatedCallback(NetState ns);

    public class NetState
    {
        private Socket m_Socket;
        private IPAddress m_Address;
        private ByteQueue m_Buffer;
        private byte[] m_RecvBuffer;
        private SendQueue m_SendQueue;
        private bool m_Seeded;
        private bool m_Running;

#if Framework_4_0
        private SocketAsyncEventArgs m_ReceiveEventArgs, m_SendEventArgs;
#else
		private AsyncCallback m_OnReceive, m_OnSend;
#endif

        private MessagePump m_MessagePump;
        private int m_Sequence;
        private bool m_CompressionEnabled;
        private string m_ToString;
        private bool m_SentFirstPacket;
        private bool m_BlockAllPackets;

        private DateTime m_ConnectedOn;

        public DateTime ConnectedOn
        {
            get
            {
                return m_ConnectedOn;
            }
        }

        public TimeSpan ConnectedFor
        {
            get
            {
                return (DateTime.Now - m_ConnectedOn);
            }
        }

        internal int m_Seed;
        internal int m_AuthID;

        public IPAddress Address
        {
            get
            {
                return m_Address;
            }
        }

        private static bool m_Paused;

        [Flags]
        private enum AsyncState
        {
            Pending = 0x01,
            Paused = 0x02
        }

        private AsyncState m_AsyncState;
        private object m_AsyncLock = new object();

        private IPacketEncoder m_Encoder = null;

        public IPacketEncoder PacketEncoder
        {
            get
            {
                return m_Encoder;
            }
            set
            {
                m_Encoder = value;
            }
        }

        private static NetStateCreatedCallback m_CreatedCallback;

        public static NetStateCreatedCallback CreatedCallback
        {
            get
            {
                return m_CreatedCallback;
            }
            set
            {
                m_CreatedCallback = value;
            }
        }

        public bool SentFirstPacket
        {
            get
            {
                return m_SentFirstPacket;
            }
            set
            {
                m_SentFirstPacket = value;
            }
        }

        public bool BlockAllPackets
        {
            get
            {
                return m_BlockAllPackets;
            }
            set
            {
                m_BlockAllPackets = value;
            }
        }

        public bool CompressionEnabled
        {
            get
            {
                return m_CompressionEnabled;
            }
            set
            {
                m_CompressionEnabled = value;
            }
        }

        public int Sequence
        {
            get
            {
                return m_Sequence;
            }
            set
            {
                m_Sequence = value;
            }
        }

        public void WriteConsole(string text)
        {
            Console.WriteLine("Client: {0}: {1}", this, text);
        }

        public void WriteConsole(string format, params object[] args)
        {
            WriteConsole(String.Format(format, args));
        }

        public override string ToString()
        {
            return m_ToString;
        }

        private static List<NetState> m_Instances = new List<NetState>();

        public static List<NetState> Instances
        {
            get
            {
                return m_Instances;
            }
        }

        private static BufferPool m_ReceiveBufferPool = new BufferPool("Receive", 2048, 2048);

        public NetState(Socket socket, MessagePump messagePump)
        {
            m_Socket = socket;
            m_Buffer = new ByteQueue();
            m_Seeded = false;
            m_Running = false;
            m_RecvBuffer = m_ReceiveBufferPool.AcquireBuffer();
            m_MessagePump = messagePump;

            m_SendQueue = new SendQueue();

            m_NextCheckActivity = DateTime.Now + TimeSpan.FromMinutes(0.5);

            m_Instances.Add(this);

            try
            {
                m_Address = Utility.Intern(((IPEndPoint)m_Socket.RemoteEndPoint).Address);
                m_ToString = m_Address.ToString();
            }
            catch (Exception ex)
            {
                TraceException(ex);
                m_Address = IPAddress.None;
                m_ToString = "(error)";
            }

            m_ConnectedOn = DateTime.Now;

            if (m_CreatedCallback != null)
            {
                m_CreatedCallback(this);
            }
        }

        public virtual void Send(Packet p)
        {
            if (m_Socket == null || m_BlockAllPackets)
            {
                p.OnSend();
                return;
            }

            int length;
            byte[] buffer = p.Compile(m_CompressionEnabled, out length);

            if (buffer != null)
            {
                if (buffer.Length <= 0 || length <= 0)
                {
                    p.OnSend();
                    return;
                }

                if (m_Encoder != null)
                {
                    m_Encoder.EncodeOutgoingPacket(this, ref buffer, ref length);
                }

                try
                {
                    SendQueue.Gram gram;

                    lock (m_SendQueue)
                    {
                        gram = m_SendQueue.Enqueue(buffer, length);
                    }

                    if (gram != null)
                    {
#if Framework_4_0
                        m_SendEventArgs.SetBuffer(gram.Buffer, 0, gram.Length);
                        Send_Start();
#else
						try {
							m_Socket.BeginSend( gram.Buffer, 0, gram.Length, SocketFlags.None, m_OnSend, m_Socket );
						} catch ( Exception ex ) {
							TraceException( ex );
							Dispose( false );
						}
#endif
                    }
                }
                catch (CapacityExceededException)
                {
                    Console.WriteLine("Client: {0}: Too much data pending, disconnecting...", this);
                    Dispose(false);
                }

                p.OnSend();
            }
            else
            {
                Console.WriteLine("Client: {0}: null buffer send, disconnecting...", this);
                using (StreamWriter op = new StreamWriter("null_send.log", true))
                {
                    op.WriteLine("{0} Client: {1}: null buffer send, disconnecting...", DateTime.Now, this);
                    op.WriteLine(new System.Diagnostics.StackTrace());
                }
                Dispose();
            }
        }

#if Framework_4_0
        public void Start()
        {
            m_ReceiveEventArgs = new SocketAsyncEventArgs();
            m_ReceiveEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(Receive_Completion);
            m_ReceiveEventArgs.SetBuffer(m_RecvBuffer, 0, m_RecvBuffer.Length);

            m_SendEventArgs = new SocketAsyncEventArgs();
            m_SendEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(Send_Completion);

            m_Running = true;

            if (m_Socket == null || m_Paused)
            {
                return;
            }

            Receive_Start();
        }

        private void Receive_Start()
        {
            try
            {
                bool result = false;

                do
                {
                    lock (m_AsyncLock)
                    {
                        if ((m_AsyncState & (AsyncState.Pending | AsyncState.Paused)) == 0)
                        {
                            m_AsyncState |= AsyncState.Pending;
                            result = !m_Socket.ReceiveAsync(m_ReceiveEventArgs);

                            if (result)
                                Receive_Process(m_ReceiveEventArgs);
                        }
                    }
                } while (result);
            }
            catch (Exception ex)
            {
                TraceException(ex);
                Dispose(false);
            }
        }

        private void Receive_Completion(object sender, SocketAsyncEventArgs e)
        {
            Receive_Process(e);

            if (!m_Disposing)
                Receive_Start();
        }

        private void Receive_Process(SocketAsyncEventArgs e)
        {
            int byteCount = e.BytesTransferred;

            if (e.SocketError != SocketError.Success || byteCount <= 0)
            {
                Dispose(false);
                return;
            }

            m_NextCheckActivity = DateTime.Now + TimeSpan.FromMinutes(1.2);

            byte[] buffer = m_RecvBuffer;

            if (m_Encoder != null)
                m_Encoder.DecodeIncomingPacket(this, ref buffer, ref byteCount);

            lock (m_Buffer)
                m_Buffer.Enqueue(buffer, 0, byteCount);

            m_MessagePump.OnReceive(this);

            lock (m_AsyncLock)
            {
                m_AsyncState &= ~AsyncState.Pending;
            }
        }

        private void Send_Start()
        {
            try
            {
                bool result = false;

                do
                {
                    result = !m_Socket.SendAsync(m_SendEventArgs);

                    if (result)
                        Send_Process(m_SendEventArgs);
                } while (result);
            }
            catch (Exception ex)
            {
                TraceException(ex);
                Dispose(false);
            }
        }

        private void Send_Completion(object sender, SocketAsyncEventArgs e)
        {
            Send_Process(e);

            if (m_Disposing)
                return;

            if (m_CoalesceSleep >= 0)
            {
                Thread.Sleep(m_CoalesceSleep);
            }

            SendQueue.Gram gram;

            lock (m_SendQueue)
            {
                gram = m_SendQueue.Dequeue();
            }

            if (gram != null)
            {
                m_SendEventArgs.SetBuffer(gram.Buffer, 0, gram.Length);
                Send_Start();
            }
        }

        private void Send_Process(SocketAsyncEventArgs e)
        {
            int bytes = e.BytesTransferred;

            if (e.SocketError != SocketError.Success || bytes <= 0)
            {
                Dispose(false);
                return;
            }

            m_NextCheckActivity = DateTime.Now + TimeSpan.FromMinutes(1.2);
        }

        public static void Pause()
        {
            m_Paused = true;

            for (int i = 0; i < m_Instances.Count; ++i)
            {
                NetState ns = m_Instances[i];

                lock (ns.m_AsyncLock)
                {
                    ns.m_AsyncState |= AsyncState.Paused;
                }
            }
        }

        public static void Resume()
        {
            m_Paused = false;

            for (int i = 0; i < m_Instances.Count; ++i)
            {
                NetState ns = m_Instances[i];

                if (ns.m_Socket == null)
                {
                    continue;
                }

                lock (ns.m_AsyncLock)
                {
                    ns.m_AsyncState &= ~AsyncState.Paused;

                    if ((ns.m_AsyncState & AsyncState.Pending) == 0)
                        ns.Receive_Start();
                }
            }
        }

        public bool Flush()
        {
            if (m_Socket == null || !m_SendQueue.IsFlushReady)
            {
                return false;
            }

            SendQueue.Gram gram;

            lock (m_SendQueue)
            {
                gram = m_SendQueue.CheckFlushReady();
            }

            if (gram != null)
            {
                m_SendEventArgs.SetBuffer(gram.Buffer, 0, gram.Length);
                Send_Start();
            }

            return false;
        }

#else

		public void Start() {
			m_OnReceive = new AsyncCallback( OnReceive );
			m_OnSend = new AsyncCallback( OnSend );

			m_Running = true;

			if ( m_Socket == null || m_Paused ) {
				return;
			}

			try {
				lock ( m_AsyncLock ) {
					if ( ( m_AsyncState & ( AsyncState.Pending | AsyncState.Paused ) ) == 0 ) {
						InternalBeginReceive();
					}
				}
			} catch ( Exception ex ) {
				TraceException( ex );
				Dispose( false );
			}
		}

		private void InternalBeginReceive() {
			m_AsyncState |= AsyncState.Pending;

			m_Socket.BeginReceive( m_RecvBuffer, 0, m_RecvBuffer.Length, SocketFlags.None, m_OnReceive, m_Socket );
		}

		private void OnReceive( IAsyncResult asyncResult ) {
			Socket s = (Socket)asyncResult.AsyncState;

			try {
				int byteCount = s.EndReceive( asyncResult );

				if ( byteCount > 0 ) {
					m_NextCheckActivity = DateTime.Now + TimeSpan.FromMinutes( 1.2 );

					byte[] buffer = m_RecvBuffer;

					if ( m_Encoder != null )
						m_Encoder.DecodeIncomingPacket( this, ref buffer, ref byteCount );

					lock ( m_Buffer )
						m_Buffer.Enqueue( buffer, 0, byteCount );

					m_MessagePump.OnReceive( this );

					lock ( m_AsyncLock ) {
						m_AsyncState &= ~AsyncState.Pending;

						if ( ( m_AsyncState & AsyncState.Paused ) == 0 ) {
							try {
								InternalBeginReceive();
							} catch ( Exception ex ) {
								TraceException( ex );
								Dispose( false );
							}
						}
					}
				} else {
					Dispose( false );
				}
			} catch {
				Dispose( false );
			}
		}

		private void OnSend( IAsyncResult asyncResult ) {
			Socket s = (Socket)asyncResult.AsyncState;

			try {
				int bytes = s.EndSend( asyncResult );

				if ( bytes <= 0 ) {
					Dispose( false );
					return;
				}

				m_NextCheckActivity = DateTime.Now + TimeSpan.FromMinutes( 1.2 );

				if ( m_CoalesceSleep >= 0 ) {
					Thread.Sleep( m_CoalesceSleep );
				}

				SendQueue.Gram gram;

				lock ( m_SendQueue ) {
					gram = m_SendQueue.Dequeue();
				}

				if ( gram != null ) {
					try {
						s.BeginSend( gram.Buffer, 0, gram.Length, SocketFlags.None, m_OnSend, s );
					} catch ( Exception ex ) {
						TraceException( ex );
						Dispose( false );
					}
				}
			} catch ( Exception ){
				Dispose( false );
			}
		}

		public static void Pause() {
			m_Paused = true;

			for ( int i = 0; i < m_Instances.Count; ++i ) {
				NetState ns = m_Instances[i];

				lock ( ns.m_AsyncLock ) {
					ns.m_AsyncState |= AsyncState.Paused;
				}
			}
		}

		public static void Resume() {
			m_Paused = false;

			for ( int i = 0; i < m_Instances.Count; ++i ) {
				NetState ns = m_Instances[i];

				if ( ns.m_Socket == null ) {
					continue;
				}

				lock ( ns.m_AsyncLock ) {
					ns.m_AsyncState &= ~AsyncState.Paused;

					try {
						if ( ( ns.m_AsyncState & AsyncState.Pending ) == 0 )
							ns.InternalBeginReceive();
					} catch ( Exception ex ) {
						TraceException( ex );
						ns.Dispose( false );
					}
				}
			}
		}

		public bool Flush() {
			if ( m_Socket == null || !m_SendQueue.IsFlushReady ) {
				return false;
			}

			SendQueue.Gram gram;

			lock ( m_SendQueue ) {
				gram = m_SendQueue.CheckFlushReady();
			}

			if ( gram != null ) {
				try {
					m_Socket.BeginSend( gram.Buffer, 0, gram.Length, SocketFlags.None, m_OnSend, m_Socket );
					return true;
				} catch ( Exception ex ) {
					TraceException( ex );
					Dispose( false );
				}
			}

			return false;
		}
#endif

        public PacketHandler GetHandler(int packetID)
        {
            return PacketHandlers.GetHandler(packetID);
        }

        public static void FlushAll()
        {
            for (int i = 0; i < m_Instances.Count; ++i)
            {
                NetState ns = m_Instances[i];

                ns.Flush();
            }
        }

        private static int m_CoalesceSleep = -1;

        public static int CoalesceSleep
        {
            get
            {
                return m_CoalesceSleep;
            }
            set
            {
                m_CoalesceSleep = value;
            }
        }

        private DateTime m_NextCheckActivity;

        public bool CheckAlive()
        {
            if (m_Socket == null)
                return false;

            if (DateTime.Now < m_NextCheckActivity)
            {
                return true;
            }

            Console.WriteLine("Client: {0}: Disconnecting due to inactivity...", this);

            Dispose();
            return false;
        }

        public static void TraceException(Exception ex)
        {
            try
            {
                using (StreamWriter op = new StreamWriter("network-errors.log", true))
                {
                    op.WriteLine("# {0}", DateTime.Now);

                    op.WriteLine(ex);

                    op.WriteLine();
                    op.WriteLine();
                }
            }
            catch
            {
            }

            try
            {
                Console.WriteLine(ex);
            }
            catch
            {
            }
        }

        private bool m_Disposing;

        public void Dispose()
        {
            Dispose(true);
        }

        public virtual void Dispose(bool flush)
        {
            if (m_Socket == null || m_Disposing)
            {
                return;
            }

            m_Disposing = true;

            if (flush)
                flush = Flush();

            try
            {
                m_Socket.Shutdown(SocketShutdown.Both);
            }
            catch (SocketException ex)
            {
                TraceException(ex);
            }

            try
            {
                m_Socket.Close();
            }
            catch (SocketException ex)
            {
                TraceException(ex);
            }

            if (m_RecvBuffer != null)
                m_ReceiveBufferPool.ReleaseBuffer(m_RecvBuffer);

            m_Socket = null;

            m_Buffer = null;
            m_RecvBuffer = null;

#if Framework_4_0
            m_ReceiveEventArgs = null;
            m_SendEventArgs = null;
#else
			m_OnReceive = null;
			m_OnSend = null;
#endif

            m_Running = false;

            m_Disposed.Enqueue(this);

            if ( /*!flush &&*/ !m_SendQueue.IsEmpty)
            {
                lock (m_SendQueue)
                    m_SendQueue.Clear();
            }
        }

        public static void Initialize()
        {
            Timer.DelayCall(TimeSpan.FromMinutes(1.0), TimeSpan.FromMinutes(1.5), new TimerCallback(CheckAllAlive));
        }

        public static void CheckAllAlive()
        {
            try
            {
                for (int i = 0; i < m_Instances.Count; ++i)
                {
                    m_Instances[i].CheckAlive();
                }
            }
            catch (Exception ex)
            {
                TraceException(ex);
            }
        }

        private static Queue m_Disposed = Queue.Synchronized(new Queue());

        public static void ProcessDisposedQueue()
        {
            int breakout = 0;

            while (breakout < 200 && m_Disposed.Count > 0)
            {
                ++breakout;

                NetState ns = (NetState)m_Disposed.Dequeue();

                m_Instances.Remove(ns);
            }
        }

        public bool Running
        {
            get
            {
                return m_Running;
            }
        }

        public bool Seeded
        {
            get
            {
                return m_Seeded;
            }
            set
            {
                m_Seeded = value;
            }
        }

        public Socket Socket
        {
            get
            {
                return m_Socket;
            }
        }

        public ByteQueue Buffer
        {
            get
            {
                return m_Buffer;
            }
        }
    }
}