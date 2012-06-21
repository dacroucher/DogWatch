using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DogWatch.Networking
{
    public static class Network
    {
        private static Listener m_listener;
        public static Listener listener { get { return m_listener; } }


        public static void Init(int listenPort)
        {
            m_listener = new Listener(listenPort);
            m_listener.NewConnection += new NewConnectionHandler(m_listener_NewConnection);
        }

        private static void m_listener_NewConnection(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


    }
}
