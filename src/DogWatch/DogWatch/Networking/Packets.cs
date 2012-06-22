using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DogWatch.Networking
{
    public static class Packets
    {
        private static Dictionary<byte, PacketHandler> m_packetHandlers;

        public static void Init()
        {
            m_packetHandlers = new Dictionary<byte, PacketHandler>();
            Populate();
        }


        private static void Populate()
        {
            Register(0x00, 1, DummyPacket);
        }

        private static void Register(byte packetID, short length, OnPacketReceive receiveAction)
        {
            m_packetHandlers.Add(packetID, new PacketHandler(packetID,length,receiveAction));
        }

        public static int GetPacketLength(byte packetID)
        {
            PacketHandler ph;
            if (m_packetHandlers.TryGetValue(packetID, out ph))
                return ph.length;
            else
                return -1;
        }

        public static PacketHandler GetHandler(byte packetID)
        {
            PacketHandler ph;
            if (m_packetHandlers.TryGetValue(packetID, out ph))
                return ph;
            else
                return null;
        }

        /* Packet Action */

        private static void DummyPacket(byte[] buffer, Client c)
        {
            
        }
    }
}
