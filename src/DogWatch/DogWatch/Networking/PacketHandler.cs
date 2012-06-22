using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DogWatch.Networking
{
    public delegate void OnPacketReceive(byte[] buffer, Client c);

    public class PacketHandler
    {

        private int m_packetID;
        private int m_length;
        private OnPacketReceive m_OnReceive;        

        public int packetID { get { return m_packetID; } }
        public int length { get { return m_length; } }
        public OnPacketReceive onReceieve { get { return m_OnReceive; } }

        public PacketHandler(int packetID, int length, OnPacketReceive onReceieve)
        {
            m_packetID = packetID;
            m_length = length;
            m_OnReceive = onReceieve;
        }

    }
}
