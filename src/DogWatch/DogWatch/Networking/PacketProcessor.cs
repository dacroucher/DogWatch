using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DogWatch.Networking
{
    public class PacketProcessor
    {
        private Queue<Client> m_processQueue;

        public PacketProcessor()
        {
            m_processQueue = new Queue<Client>();
        }

        public void ProcessQueue()
        {
            if (m_processQueue.Count > 0)
            {
                lock (m_processQueue)
                {
                    foreach (Client c in m_processQueue)
                    {
                        Process(c);
                    }
                }

            }
        }


        private void Process(Client c)
        {
            c.packetBuffer.working = true;
            PacketHandler handler;            
            while (c.packetBuffer.Available)
            {
                byte[] packet = c.packetBuffer.Dequeue();                
                handler = Packets.GetHandler(packet[0]);
                if (handler != null)
                    handler.onReceieve(packet,c);
            }
            c.packetBuffer.working = false;
        }


        public void Enqueue(Client c)
        {
            lock (m_processQueue)
                m_processQueue.Enqueue(c);
        }

    }
}
