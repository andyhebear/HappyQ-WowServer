
namespace Client.Network.Packets
{
    public class LoginPacket : Packet
    {
        public LoginPacket(string username, string password)
            : base(0x80, 62)
        {
            Stream.WriteAsciiFixed(username, 30);
            Stream.WriteAsciiFixed(password, 30);
            Stream.Write((byte)0x5D);
        }
    }
}
