using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace aula01
{
    class Program
    {
        public static void StartClient()
        {
            byte[] buffer = new byte[1024];
            try
            {
                var hostName = Dns.GetHostName();
                IPHostEntry ipHost = Dns.GetHostEntry(hostName);
                Console.WriteLine($"Host: {hostName}");
                IPAddress ip = ipHost.AddressList[0];
                IPEndPoint remoteEp = new IPEndPoint(ip, 43665);

                Socket sender = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    sender.Connect(remoteEp);
                    Console.WriteLine("socket conected");
                    sender.RemoteEndPoint.ToString();
                    byte[] msg = Encoding.ASCII.GetBytes("Tis is just a test");
                    int byteSent = sender.Send(msg);
                    int byteSent = sender.Receive(bytes);
                    Console.WriteLine($"echoed test{Encoding.ASCII.GetBytes(bytes, 0, byteRec)})";

                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                catch (SocketException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("press any key to cont...");
        Console.ReadLine();
        SyncSocketClient.StartClient();
        Console.ReadLine();

    }
}