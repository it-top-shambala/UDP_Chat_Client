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

        public static byte[] ReceiveBinary(int port)
        {
            var receiver = new UdpClient(port);
            IPEndPoint ip = null;
            return receiver.Receive(ref ip);
        }
    }
}