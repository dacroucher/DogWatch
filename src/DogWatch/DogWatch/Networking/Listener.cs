using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace DogWatch.Networking
{
    public delegate void NewConnectionHandler(object sender, EventArgs e);

    public class Listener
    {
        private Socket m_sock;
        private AsyncCallback m_onAccept;
        public event NewConnectionHandler NewConnection;

        public Listener(int port)
        {
            m_onAccept = new AsyncCallback(OnAccept);
            InitListen(port);
        }

        public void Listen()
        {
            m_sock.Listen(3);
            m_sock.BeginAccept(m_onAccept, null);
        }

        private void InitListen(int port)
        {
            m_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);            
            m_sock.Bind(new IPEndPoint(IPAddress.Any, port));            
        }

        private void OnAccept(IAsyncResult iar)
        {
            Socket s = m_sock.EndAccept(iar);

            if (NewConnection != null)
                NewConnection(this,EventArgs.Empty);
            m_sock.BeginAccept(m_onAccept, null);
        }
    }
}
