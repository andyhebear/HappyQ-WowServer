
namespace Client.Network.Packets
{
    public class SeedPacket : Packet
    {
        public SeedPacket() :
            base(0x01, 4)
        {
            Stream.Write(new byte[] { 0x02, 0x03, 0x04 }, 0, 3);
        }
    }
}
