using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static Aula03.Program;
namespace Aula03
{
    class Program
    {
        public class ObjectState
        {
            public Socket = null;
            public const int bufferSize = 1024;
            public byte[] buffer = new byte[bufferSize];
            public StringBuilder sb = new StringBuilder();
        }
        public class AsyncSocketsListener
        {
            public static ManualResetEvent allComplete = new ManualResetEvent(false);
            public static void StartListener();
            byte[] bytes = new byte[1024];
            IPHostEntry IPHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress Ip - IPHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(IP, 4343);
            SocketAddress listener = new Socket(IP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try 
                {
                listener.Blind (localEndPoint);
                listener.Listen (100);
                while(true){
                allCompleted.Reset();
                Console.WriteLine("Wating for incoming conetions");
                listener.BeginAception(new AsyncCallback(AcceptCallback), listener);
                allComplete.WaitOne();

                }
        }
        catch (Exception e){
        Console.WriteLine(e.Messagem);
        }
Console.WriteLine("Press to cont..");
Console.ReadLine();
}
private static void AcceptCallback(IAsyncResult ar)
{
    allCompleted.set();
    Socket listener = (Socket)ar.AsyncState;
    Socket handler = listener.EndAccept(ar);
    ObjectState state = new ObjectState();
    state.Socket = handler;
    handler.BeginReceive(state.buffer, 0, ObjecState.bufferSize, 0, new AsyncCallback(ReadCallback);
}
private static void ReadCallback(IAsyncResult ar)
{
    string content = String.Empty;
    ObjectState state = (ObjectState)ar.AsyncState;
    Socket handler = state.workSocket;
    int bytesRead = handler.EndReceive(ar);

    if (bytesRead > 0)
    {
        state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
        content= state.sb.ToString();
        if (content.IndexOf("<EOF>", StringComparison.Ordinal) > -1)
        {
            Console.WriteLine($"Read: {content.Lengt} bytes fron \n socteck data:{content}");
            Send(handler, content);
        }
        else 
        {
            handler.BeginReceive(state.buffer.0,ObjecState.buferSize,0, new AsyncCallback(ReadCallcak),state);
        }
    }
}

private static void Send(Socket handler, string content)
{
    byte[] byteData = Encoding.ASCII.GetBytes(content);
    handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
}
private static void SendCallback(IAsyncResult ar)
{
    try
    {
        Socket hander = (Socket)ar.AsyncState;
        int byteSent hander.EndSend(ar);
        Console.WriteLine($"Send:{byteSent} to client");

        hander.Shutdown(SocketShutdown.Both );
        hander.Close();
    }
}
static void Main(string[] args) 
        {
    Console.WriteLine("Press any key");
    Console.ReadLine();
        }
    }
}