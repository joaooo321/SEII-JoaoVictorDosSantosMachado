using Multi_Con_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aula07
{
    public partial class Main : Form
    {
        Listener listener;
        public Main()
        {
            InitializeComponet();
            listener = new Listener(8);
            listener.SocketAccepted += new Listener.SocketAcceptedHandler(listener_SocketAccepted);

        }
        void listener_SocketAccepted(System.Net.Sockets.Socket e)
        {
            Client client = new Client(e);
            client.Received += new Client.ClientReceivedHandler(client_Received);
            client.Disconnected += new Client.ClientDisconnectedHandler(client_Disconnected);


            Invoke((MethodInvoker)delegate
            {
                ListViewItem i = new ListViewItem();
                i.Text = client.EndPoint.ToString();
                i.SubItems.Add(client.ID);
                i.SubItems.Add("XX");
                i.SubItems.Add("XX");
                lstClients.Items.Add(i);
            });
        }
        void client_Disconnected(Client sender)
        {

            Invoke((MethodInvoker)delegate
            {
            for (int i = 0; i < 1stClients.Items.Count; i++) {
                {
                    Client client = 1stClients.Items[i].Tag as Client;
                    if (client.ID == sender.ID)
                    {
                        1stClients.Items.RemoveAt(i);
                        break;
                    }
                }
            });
        }

        void client_Received(Client sender, byte[] data)
        {
            Invoke((MethodInvoker)delegate
            {
            for (int i = 0; i < 1stClients.Items.Count; i++)
                {
                Client client = 1stClients.Items[i].Tag as Client;
                if (client.ID == sender.ID)
                {
                    1stClients.Items[i].SubItems[2].Text = Encoding.Default.GetString(data);
                    1stClients.Items[i].SubItems[3].Text = DateTime.Now.ToString();
                    break;
                }
                }
        });
    }
}

