using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace DogWatch.Networking
{
    public static class Network
    {
        private static Listener m_listener;
        public static Listener listener { get { return m_listener; } }

        private static PacketProcessor m_packetProcessor;

        private static ClientHandler m_clientHandler;

        public static void Init(int listenPort)
        {
            m_clientHandler = new ClientHandler();
            m_listener = new Listener(listenPort);
            m_listener.NewConnection += new NewConnectionHandler(m_listener_NewConnection);
            m_packetProcessor = new PacketProcessor();
        }

        private static void m_listener_NewConnection(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public static void NewPacket(Client c)
        {
            m_packetProcessor.Enqueue(c);
        }

        public static void NewClient(Socket s)
        {
            m_clientHandler.NewClient(s);
        }

    }
}
