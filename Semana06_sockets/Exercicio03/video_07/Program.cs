﻿using System.Net;
using System.Net.Sockets;

namespace Multi_Con_S
{
    class Listener
    {
        Socket s;
        public bool Listenig { get; private set; }
        public int Port { get; private set; }
        public Listener(int port)
        {
            Port = port;
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Start() 
        {
            if (Listenig)
                return;
            s.Bind(new IPEndPoint(0, Port));
            s.Listen(0);
            s.BeginAccept(callback, null);
            Listening=true;
        }
        public void Stop() 
        { 
            if (!Listenig) return;
            s.Close();
            s.Dispose();
            s= new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
        
        }
        void callback(IAsyncResult ar) 
        {
            try 
            {
                Socket s =this.s.EndAccept(ar);
                if (SocketAccepted !=null) 
                    SocketAccepted(s);
                this.s.BeginAccept(callback, null);
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }
        public delegate void SocketAcceptedHandler(Socket e);
        public event SocketAcceptedHandler SocketAccepted;
    }
}