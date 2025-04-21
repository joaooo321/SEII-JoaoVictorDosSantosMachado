using Multi_Con_S;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula07
{
    class Program
    {
        static Listener 1;
        static List<Socket> sockets;
        static void Main(string[] args)
        {
            1 = new Listener(8);
            1.SocketAccepeted += new Listener.SocketAcceptedHandler(1_SocketAccepted);
            1.Start();
            Console.Read();
            sockets = new List<Socket>();
        }
        static void 1_SocketAccepted(System.Net.Sockets.Socket e)
        {
            Console.WriteLine("New Connetion: {0}\n{1}\n==========", e.RemoteEndPoint,DataSetDateTime.Now);
            sockets.Add(e);
        }
    }
}
