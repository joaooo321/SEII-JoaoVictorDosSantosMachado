using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Text_Serve
{
    public partial class Form1 : Form
    {
        Socket sck;
        Socket acc;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnListen_Click(object sender, EventArgs e)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(0,8));
            sck.Listen(0);
            acc = sck.Accept();
            sck.Close();
            new Thread(() => 
            {
                while (true) 
                {
                    byte[] buffer = new byte[4];
                    acc.Receive(sizeBuf,0,sizeBuf.Length,0);
                    int size = BitConverter.ToInt32(sizebuffer,0);
                    MemoryStream ms = new MemoryStream();
                    while (size > 0) 
                    {
                        if (size < acc.ReceiveBufferSize)
                        {
                            buffer = new byte[size];
                        }
                        else
                            buffer = new byte[acc.ReceiveBufferSize];
                        int rec = acc.Receive(buffer,0,buffer.Length,0);
                        size -= rec;
                        ms.Write(buffer,0, buffer.Length);
                    }
                    ms.Close();
                    byte[] data = ms.ToArray();
                    ms.Dispose();
                    Invoke((MethodInvoker)delegate
                    {
                        textBox.Text = Encoding.Default.GetString(data);
                    });
                }
            }).Start();
        }
    }
}