using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace DogWatch.Networking
{
    public class PacketBuffer
    {              
        private Queue<byte> m_inputQueue;
        private Queue<byte[]> m_outputQueue;
        private ArrayList m_currentPacket;
        private Client m_owner;
        public bool Available { get { return m_outputQueue.Count > 0; } }
        private int m_currExpected = -1;
        
        public bool working = false;        
        private object key = new object();
        
        public PacketBuffer(Client owner)
        {
            m_owner = owner;
            m_inputQueue = new Queue<byte>();
            m_outputQueue = new Queue<byte[]>();
            m_currentPacket = new ArrayList();            
        }



        /* -- Decode Functions -- */

        private bool ProcessInput()
        {
            if (m_inputQueue.Count <= 0) //no input
                return false;
            
            /* New Packet */            
            if (m_currentPacket.Count == 0)
                {
                    m_currentPacket.Add(m_inputQueue.Dequeue());
                    m_currExpected = GetPacketLength((byte)m_currentPacket[0]);

                    /* Variable Length */
                    if (m_currExpected == 0)
                    {
                        if (m_inputQueue.Count < 2)//Not enough data
                            return false;
                        else
                            for (int x = 0; x < 2; x++)
                                m_currentPacket.Add(m_inputQueue.Dequeue());
                        m_currExpected = ConvertCurrentLength();

                        if (m_inputQueue.Count < m_currExpected - m_currentPacket.Count) //Not enough data
                            return false;
                        else
                        {
                            int target = m_currExpected - m_currentPacket.Count;
                            for (int x = 0; x < target; x++)
                                m_currentPacket.Add(m_inputQueue.Dequeue());
                            QueueCurrentPacket();
                            return true;
                        }
                    }
                    /* Fixed Length */
                    else
                    {
                        if (m_inputQueue.Count < m_currExpected - m_currentPacket.Count) //Not enough data
                            return false;
                        else
                        {
                            int target = m_currExpected - m_currentPacket.Count;
                            for (int x = 0; x < target; x++)
                                m_currentPacket.Add(m_inputQueue.Dequeue());
                            QueueCurrentPacket();
                            return true;
                        }
                    }
                }
                /* Partial Packet */
                else
                {
                    if (m_currExpected == -1)
                        throw new Exception("This shouldn't happen!!");

                    /* Variable Length */
                    if (m_currExpected == 0)
                    {
                        if (m_inputQueue.Count < 2)//Not enough data
                            return false;
                        else
                            for (int x = 0; x < 2; x++)
                                m_currentPacket.Add(m_inputQueue.Dequeue());
                        m_currExpected = ConvertCurrentLength();

                        if (m_inputQueue.Count < m_currExpected - m_currentPacket.Count) //Not enough data
                            return false;
                        else
                        {
                            int target = m_currExpected - m_currentPacket.Count;
                            for (int x = 0; x < target; x++)
                                m_currentPacket.Add(m_inputQueue.Dequeue());
                            QueueCurrentPacket();
                            return true;
                        }
                    }
                    /* Already Know Length */
                    else
                    {
                        if (m_inputQueue.Count < m_currExpected - m_currentPacket.Count) //Not enough data
                            return false;
                        else
                        {
                            int target = m_currExpected - m_currentPacket.Count;
                            for (int x = 0; x < target; x++)
                                m_currentPacket.Add(m_inputQueue.Dequeue());
                            QueueCurrentPacket();
                            return true;
                        }
                    }
                }

            }                   


        /* Continue Processing Input until unfinished packet is found */
        public bool ProcessQueue()
        {
            lock (key)
            {
                bool complete = false;
                while (ProcessInput())
                {
                    complete = true;
                }

                return complete;
            }
        }
            
        private int GetPacketLength(byte packetID)
        {
            return Packets.GetPacketLength(packetID);
        }

        private int ConvertCurrentLength()
        {
            byte[] var = new byte[2];
            var[1] = (byte)m_currentPacket[1];
            var[0] = (byte)m_currentPacket[2];
            return BitConverter.ToUInt16(var, 0);
        }

        private void QueueCurrentPacket()
        {
            byte[] toQ = new byte[m_currentPacket.Count];
            m_currentPacket.CopyTo(toQ);
            m_outputQueue.Enqueue(toQ);
            m_currentPacket.Clear();
            m_currExpected = -1;
        }

        /* -- End of Decode Functions -- */


        /* -- OUtput Functions -- */
        public byte[] Dequeue()
        {
            if (Available)            
                return m_outputQueue.Dequeue();                        
            else
                return null;            
        }

        /* -- End of Output Functions -- */


        /* -- Input Functions -- */
        public void Enqueue(byte[] input, int offset, int length)
        {
            lock (m_inputQueue)
            {
                for (int x = 0; x < length; x++)
                {
                    m_inputQueue.Enqueue(input[offset+x]);
                }
            }
        }

        public void Enqueue(byte input)
        {
            lock (m_inputQueue)
            {
                m_inputQueue.Enqueue(input);
            }
        }

        /* -- End of Input Functions -- */

        public void Dispose()
        {
            m_inputQueue.Clear();
            m_outputQueue.Clear();
            m_currentPacket.Clear();
            m_inputQueue = null;
            m_outputQueue = null;
            m_currentPacket = null;
        }
    }
}
