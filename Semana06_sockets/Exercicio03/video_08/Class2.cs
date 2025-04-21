using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aula07
{

    public partial class Main : Form
    {
        Socket sck;
        public Main()
        {
            InitializeComponent();
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            sck.Connect("127.0.0.1", 8);
            MessageBox.Show("Connected");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            int s =
            sck.Send(Encoding.Default.GetBytes(txtMsg.Text));
            if (s > 0)
            {
                MessageBox.Show("Data Sent");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            sck.Close();
            sck.Dispose(); 
            Close();
        }

    }
}
