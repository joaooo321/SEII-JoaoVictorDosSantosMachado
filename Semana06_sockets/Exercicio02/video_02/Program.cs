using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Aula02
{
    class Program
    {
        public class SyncServerSocket
        {
            public static string data = null;
            public static void StartListener()
            {
                byte[] buffer = new byte[1024];
                IPHostEntry iphost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = iphost.AddressList[0];
                IPEndPoint localEnpPoint = new IPEndPoint(ipAddress, 43665);
                Socket listner = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                
                try
                {
                    listner.Bind(localEnpPoint);
                    listner.Listen(10);
                    while (true)
                    {
                        Console.WriteLine($"Wating for a connetion...");
                        Socket handler = listener.Accept();
                        data = null;
                        while (true)
                        {
                            int byteRec = handler.Receive(bytes);
                            data += Encoding.ASCII.GetString(bytes, 0, byteRec);
                            if (data.IndexOf("<EoF>") > -1)
                                break;
                        }
                        Console.WriteLine($"text received: {data}");
                        byte[] msg = Encoding.ASCII.GetBytes(data);
                        handler.Send(msg);
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine (e.Message);
                    throw;
                }
                Console.WriteLine ("press any to exit program ");
                Console.ReadLine();
            }
        }
        static void Main(string[] args) {
            Console.WriteLine("press any to cont ...");
            Console.ReadLine();
            SyncServerSocket.StartListener();
            Console.ReadLine ();
        }
    }
}