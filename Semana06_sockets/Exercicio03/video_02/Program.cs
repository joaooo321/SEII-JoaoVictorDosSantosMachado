using System.Net.Sockets;
using System.Net;
using System.Text;

namespace client
{
    class Program
    {
        static Socket sck;

        static void Main(string[] args)
        {
            try
            {
                sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

                sck.Connect(localEndPoint);
            }
            catch
            {
                Console.Write("Unable to connect to remote end point!\r\n");
                Main(args);
                return;
            }

            Console.Write("Enter Text: ");

            string text = Console.ReadLine();

            byte[] data = Encoding.ASCII.GetBytes(text);

            sck.Send(data);

            Console.Write("Data Sent! \r\n");

            Console.Write("Press any key to continue...");
            Console.ReadKey();

            sck.Close();
        }
    }
}
