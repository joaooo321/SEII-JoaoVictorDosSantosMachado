﻿using Multi_Con_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Con_S {
    class Client {
        public string ID
        {
            get;
            private set;
        }
        public IPEndPoint EndPoint {
            get;
            private set;
        }
        Socket sck;
        public Client(Socket accepted)
        {
            sck = accepted;
            ID=Guid.NewGuid().ToString();
            EndPoint = (IPEndPoint)sck.RemoteEndPoint;
            sck.BeginReceive(new byte[] {0},0,0,0,callback,null);
        }
        void callback(IAsyncResult ar) 
        {
            try 
            {
                sck.EndReceive(ar);
                byte[] buf = new byte[8192];
                int rec = sck.Receive(buf,buf.Length,0);
                if (rec < buf.Length) {
                Array.Resize<byte>(ref buf,rec);
                }
                if (Received != null)
                {
                    Received(this, buf);
                }
                sck.BeginAccept(new byte[] { 0 }, 0, 0, 0, callback, null);
            } 
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                close();
                if (Diconnected != null)
                {
                    Disconnected(this);
                }
            }
        }
        public void close() 
        { 
            sck.Close();
            sck.Dispose();
        }
        public delegate void ClientReceiveHandler(Client sender ,byte[] data);
        public delegate void ClientDisconnectedHandler(Client sender);
        public event ClientReceiveHandler Received;
        public event ClientDisconnectedHandler Disconnected;
    }
}