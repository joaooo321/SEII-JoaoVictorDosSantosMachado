using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Criando o socket
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Bind do socket ao endereço IP e porta
            sck.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1994));

            // Coloca o socket em modo de escuta
            sck.Listen(0);

            // Aceitando conexão
            Socket acc = sck.Accept();

            // Enviando a mensagem "Hello World!" para o cliente conectado
            byte[] buffer = Encoding.Default.GetBytes("Hello World!");
            acc.Send(buffer, 0, buffer.Length, SocketFlags.None);

            // Preparando o buffer para receber dados
            buffer = new byte[255];

            // Recebendo dados do cliente
            int rec = acc.Receive(buffer, 0, buffer.Length, SocketFlags.None);

            // Redimensionando o buffer para o tamanho exato dos dados recebidos
            Array.Resize(ref buffer, rec);

            // Exibindo os dados recebidos
            Console.WriteLine("Received: " + Encoding.Default.GetString(buffer));

            // Fechando os sockets
            acc.Close();
            sck.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
        }
    }
}
