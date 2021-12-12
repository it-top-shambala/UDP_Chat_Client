using System.Net;
using System.Net.Sockets;

namespace UDP_Chat_Lib
{
    public static class Udp
    {
        public static void SendBinary(byte[] message, string ip, int port)
        {
            using var sender = new UdpClient();
            sender.Send(message, message.Length, ip, port);
        }

        public static void ReceiveBinary(int port, out byte[] data)
        {
            var receiver = new UdpClient(port);
            IPEndPoint ip = null;
            data = receiver.Receive(ref ip);
        }
    }
}