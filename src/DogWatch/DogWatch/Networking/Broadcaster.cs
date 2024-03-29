﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace DogWatch.Networking
{
    public class Broadcaster
    {
        private Dictionary<int, Client> m_dictionary;
        private AsyncCallback m_OnSend;

        public Broadcaster()
        {
            m_dictionary = new Dictionary<int, Client>();
            m_OnSend = new AsyncCallback(OnSend);
        }

        public void AddClient(Client client)
        {
            lock (m_dictionary)
            {
                m_dictionary.Add(client.ID,client);
            }
        }

        public void RemoveClient(Client client)
        {
            if (m_dictionary.ContainsKey(client.ID))
            {
                lock (m_dictionary)
                    m_dictionary.Remove(client.ID);
            }
        }

        public void Broadcast(byte[] buffer)
        {
            lock(m_dictionary)
            {
                foreach (Client c in m_dictionary.Values)
                {
                    c.sock.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, m_OnSend, c.sock);
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
            lock (m_dictionary)
            {
                foreach (Client c in m_dictionary.Values)
                {
                    sb.Append(c.sock.RemoteEndPoint.ToString() + "/n");
                }
            }
            return sb.ToString();
        }

        
    }
}
