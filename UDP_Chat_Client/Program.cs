using System;
using System.Text;
using System.Threading.Tasks;
using UDP_Chat_Lib;

namespace UDP_Chat_Client
{
    class Program
    {
        private static string ip = string.Empty;
        private static int port_remote = 0;
        private static int port_local = 0;
        static void Main()
        {
            Console.Write("Введите удалённый ip-адрес: ");
            ip = Console.ReadLine();
            Console.Write("Введите удалённый порт: ");
            port_remote = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите локальный порт: ");
            port_local = Convert.ToInt32(Console.ReadLine());
            
            Task.Run(Receive);

            while (true)
            {
                Send();
            }
        }

        static void Receive()
        {
            Udp.ReceiveBinary(port_local, out var data);
            Console.WriteLine(Encoding.Unicode.GetString(data));
        }

        static void Send()
        {
            Console.Write("Введите сообщение: ");
            var message = Console.ReadLine();
            var data = Encoding.Unicode.GetBytes(message);
            Udp.SendBinary(data, ip, port_remote);
        }
    }
}