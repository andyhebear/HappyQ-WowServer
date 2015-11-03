
using System;
using System.Net.Sockets;

namespace ArtworkServer.Network
{
    public class SocketConnectEventArgs : EventArgs
    {
        public Socket Socket { get; private set; }

        public bool AllowConnection { get; set; }

        public SocketConnectEventArgs(Socket socket)
        {
            Socket = socket;
        }
    }
}
