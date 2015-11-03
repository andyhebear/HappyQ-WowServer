using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

using Client.Diagnostics;

namespace Client.Network
{
    public class NetState
    {
        private readonly BufferPool _recvBuffer;
        private readonly MessagePump _messagePump;

        private Socket _socket;
        private IPAddress _address;
        private IPEndPoint _hostEndPoint;
        private ByteQueue _buffer;
        private DateTime _connectedOn;
        private PacketRegistry _packetRegistry;

        private bool _compressionEnabled;
        private bool _isConnected;
        private bool _disposing;

        public ByteQueue Buffer
        {
            get
            {
                return _buffer;
            }
        }

        public bool IsConnected
        {
            get { return _isConnected; }
        }

        public DateTime ConnectedOn
        {
            get { return _connectedOn; }
        }

        public TimeSpan ConnectedFor
        {
            get { return (DateTime.Now - _connectedOn); }
        }

        public IPAddress Address
        {
            get { return _address; }
        }

        public bool CompressionEnabled
        {
            get { return _compressionEnabled; }
            set { _compressionEnabled = value; }
        }

        public event EventHandler Connected;

        public NetState(PacketRegistry packetRegistry)
        {
            Asserter.AssertIsNotNull(packetRegistry, "packetRegistry");

            _packetRegistry = packetRegistry;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _recvBuffer = new BufferPool("Receive Buffer", 16, 4096);
            _messagePump = new MessagePump();
            _buffer = new ByteQueue();
        }

        public void BeginReceive()
        {
            SocketAsyncEventArgs args = new SocketAsyncEventArgs();

            byte[] buffer = _recvBuffer.AcquireBuffer();

            args.SetBuffer(buffer, 0, buffer.Length);
            args.UserToken = this;
            args.RemoteEndPoint = _hostEndPoint;
            args.Completed += OnReceive;

            _socket.ReceiveAsync(args);
        }

        public void Connect(string ip, int port)
        {
            if (!IPAddress.TryParse(ip, out _address))
            {
                throw new Exception("Invalid IP, the ip must be a valid ip address and cannot be a host name.");
            }

            _hostEndPoint = new IPEndPoint(_address, port);

            SocketAsyncEventArgs connectArgs = new SocketAsyncEventArgs();

            connectArgs.UserToken = this;
            connectArgs.RemoteEndPoint = _hostEndPoint;
            connectArgs.Completed += OnConnected;

            _socket.ConnectAsync(connectArgs);
        }

        void OnConnected(object sender, SocketAsyncEventArgs e)
        {
            e.Completed -= OnConnected;

            SocketError errorCode = e.SocketError;

            if (errorCode != SocketError.Success)
            {
                throw new SocketException((Int32)errorCode);
            }

            _isConnected = true;
            _connectedOn = DateTime.Now;

            var handler = Connected;

            if (handler != null)
                handler(this, EventArgs.Empty);

            BeginReceive();
        }

        public virtual void Send(Packet p)
        {
            if (_socket == null)
            {
                p.OnSend();
                return;
            }

            int length;
            byte[] buffer = p.Compile(_compressionEnabled, out length);

            if (buffer != null)
            {
                if (buffer.Length <= 0 || length <= 0)
                {
                    p.OnSend();
                    return;
                }

                try
                {
                    SocketAsyncEventArgs args = new SocketAsyncEventArgs();

                    args.SetBuffer(buffer, 0, length);
                    args.RemoteEndPoint = _hostEndPoint;
                    args.UserToken = this;

                    _socket.SendAsync(args);
                }
                catch (CapacityExceededException)
                {
                    Tracer.Error("Too much data pending, disconnecting...");
                    Dispose();
                }
                catch (Exception ex)
                {
                    Tracer.Error(ex);
                    Dispose();
                }

                p.OnSend();
            }
            else
            {
                Tracer.Error("Null buffer send, disconnecting...");
                Tracer.Error(new StackTrace());

                Dispose();
            }
        }

        private void OnReceive(object sender, SocketAsyncEventArgs e)
        {
            e.Completed -= OnConnected;

            SocketError errorCode = e.SocketError;

            if (errorCode != SocketError.Success)
            {
                throw new SocketException((Int32)errorCode);
            }

            try
            {
                int byteCount = e.BytesTransferred;

                if (byteCount > 0)
                {
                    byte[] buffer = e.Buffer;

                    lock (_buffer)
                        _buffer.Enqueue(buffer, 0, byteCount);

                    _recvBuffer.ReleaseBuffer(buffer);
                    _messagePump.OnReceive(this);

                    try
                    {
                        BeginReceive();
                    }
                    catch (Exception ex)
                    {
                        Tracer.Error(ex);
                        Dispose();
                    }
                }
                else
                {
                    Dispose();
                }
            }
            catch
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            if (_socket == null || _disposing)
            {
                return;
            }

            _disposing = true;

            try
            {
                _socket.Shutdown(SocketShutdown.Both);
            }
            catch (SocketException ex)
            {
                Tracer.Error(ex);
            }

            try
            {
                _socket.Close();
            }
            catch (SocketException ex)
            {
                Tracer.Error(ex);
            }

            _socket = null;
            _buffer = null;
        }

        internal PacketHandler GetHandler(int packetID)
        {
            return _packetRegistry.GetHandler(packetID);
        }
    }
}
