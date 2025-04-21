using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criação do socket do servidor
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Bind o socket ao endereço IP e porta
            sck.Bind(new IPEndPoint(IPAddress.Any, 1994));

            // Coloca o socket em modo de escuta
            sck.Listen(0);


            // Aceitando a conexão
            Socket acc = sck.Accept();

            // Enviando a mensagem "Hello Client!"
            byte[] buffer = Encoding.Default.GetBytes("Hello Client!");
            acc.Send(buffer, 0, buffer.Length, SocketFlags.None);

            // Preparando o buffer para receber dados
            buffer = new byte[255];

            // Recebendo dados do cliente
            int rec = acc.Receive(buffer, 0, buffer.Length, SocketFlags.None);

            // Redimensionando o buffer para o tamanho exato dos dados recebidos
            Array.Resize(ref buffer, rec);

            // Exibindo os dados recebidos
            Console.WriteLine("Received: " + Encoding.Default.GetString(buffer));

            // Fechando o socket
            acc.Close();
            sck.Close();
        }
    }
}
