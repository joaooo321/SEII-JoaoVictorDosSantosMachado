using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
namespace Sever
{
    class Program
    {
        static byte[] Buffer { get; set; }
        static Socket sck;
        static void Main(string[] args)
        {
            // Inicializando o socket
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(0, 1234));
        sck.Listen(100);

            Socket accepted = sck.Accept();
            Buffer = new byte[accepted.SendBufferSize]; // Certificando-se que o ponto e vírgula está correto
            int bytesRead = accepted.Receive(Buffer);
            byte[] formatted = new byte[bytesRead];
            for (int i = 0; i < bytesRead; i++)
            {
                formatted[i] = Buffer[i]; // Corrigido o índice e os colchetes
            }
            String strData = Encoding.ASCII.GetString(formatted);
        Console.Write(strData + "\r\n");
        Console.Read();
        sck.Close();
        accepted.Close();

        }
    }
}
