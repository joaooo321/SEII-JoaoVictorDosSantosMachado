using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Aula06
{
    public partial class Form1 : Form1
    {
        public Form1()
        {
            initializeComponet();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sck.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8));
            }
            catch
            {
                MessageBox.Show("Unable to Connect");
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.Default.GetBytes(texteBox.Text);
            sck.Send(BitConverter.GetBytes(data.Length), 0,4,0);
            sck.Send(data);
        }
    }
}
