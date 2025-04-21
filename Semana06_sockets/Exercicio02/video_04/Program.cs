using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

class Program
{
    public class ObjectState
    {
        public const int BufferSize = 256;
        public Socket? socket = null;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();
    }
    public class AsyncSocketClient
    {
        private const int Port = 4343;
        private static ManualResetEvent connectCompleted = new ManualResetEvent(false);
        private static ManualResetEvent sendCompleted = new ManualResetEvent(false);
        private static ManualResetEvent receiveCompleted = new ManualResetEvent(false);
        private static string response = String.Empty;

        public static void StartClient()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ip = ipHost.AddressList[0];
                IPEndPoint remoteEndPoint = new IPEndPoint(ip, Port);

                Socket client = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                client.BeginConnect(remoteEndPoint, new AsyncCallback(ConnectionCallback),client);
                Send(client, "this is a socket messagem <EOF>");
                sendCompleted.WaitOne();

                Receive(client);
                receiveCompleted.WaitOne();
                Console.WriteLine($"Respost recive{response}");
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void Receive(Socket client)
        {
            try
            {
                ObjectState state = new ObjectState();
                state.socket = client;
                client.BeginReceive(state.buffer, 0, ObjectState.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void Send(Socket client, string data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);

        }

        private static void SendCallback(IAsyncResult ar)
        {
            try 
            {
                Socket socket = (Socket)ar.AsyncState;
                int byteSend = client.EndSend(ar);
                Console.WriteLine($"Sent{byteSend}");
                sendCompleted.Set();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
        }

        private static void ConnectionCallback(IAsyncResult ar)
        {
            try
            {
                ObjectState state = (ObjectState) ar.AsyncState;
                var client = state.wSocket;
                int byteRead = client.EndReceive(ar);
                if (byteRead > 0)
                {
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, byteRead));
                    client.BeginReceive(state.buffer, 0, ObjectState, BufferSize, 0, new AsyncCallback(ReceiveCallback), state);

                }
                else
                {
                    if(state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    receiveCompleted.Set();
                }

            }
            catch(Exception e) 
            {
                Console.WriteLine(e);
            }
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("press any key to cont....");
        Console.ReadLine();
    }
}
