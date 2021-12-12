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
        static async Task Main()
        {
            Console.Write("Введите удалённый ip-адрес: ");
            ip = Console.ReadLine();
            Console.Write("Введите удалённый порт: ");
            port_remote = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите локальный порт: ");
            port_local = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
                await Send();
                await Receive();
            }
        }

        static async Task Receive()
        {
            var result = await Udp.ReceiveBinaryAsync(port_local);
            var data = result.Buffer;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Encoding.Unicode.GetString(data));
            Console.ResetColor();
        }

        static async Task Send()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var message = Console.ReadLine();
            var data = Encoding.Unicode.GetBytes(message);
            await Udp.SendBinaryAsync(data, ip, port_remote);
            Console.ResetColor();
        }
    }
}