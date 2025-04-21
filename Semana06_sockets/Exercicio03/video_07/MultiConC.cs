using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Aula07
{
   class Listener
    {
        static void Main(string[] args)
        {
            Socket s= new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect("127.0.0.1", 8);
            s.Close();
            s.Dispose();
        }
    }
}
