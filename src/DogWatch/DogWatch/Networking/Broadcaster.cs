using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace DogWatch.Networking
{
    public class Broadcaster
    {
        private List<Socket> m_list;
        private AsyncCallback m_OnSend;

        public Broadcaster()
        {
            m_list = new List<Socket>();
        }

        public void AddSocket(Socket socket)
        {
            lock (m_list)
            {
                m_list.Add(socket);
            }
        }

        public void RemoveSocket(Socket s)
        {
            if (m_list.Contains(s))
            {
                lock (m_list)
                    m_list.Remove(s);
            }
        }

        public void Broadcast(byte[] buffer)
        {
            lock(m_list)
            {
                foreach (Socket s in m_list)
                {
                    s.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, m_OnSend, s);
                }
            }
        }

        private void OnSend(IAsyncResult iar)
        {
            ((Socket)iar.AsyncState).EndSend(iar);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            lock (m_list)
            {
                foreach (Socket s in m_list)
                {
                    sb.Append(s.RemoteEndPoint.ToString() + "/n");
                }
            }
            return sb.ToString();
        }

        
    }
}
