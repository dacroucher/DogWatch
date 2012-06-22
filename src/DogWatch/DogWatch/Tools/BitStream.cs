using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DogWatch.Tools
{
    public class BitStream
    {
        private Queue<byte> m_buffer;
        private int m_current;
        private byte m_bitCount;
        private int m_byteCount;
        public int byteCount { get{return m_byteCount;} }

        public int count
        {
            get { return m_buffer.Count; }
        }

        public BitStream()
        {
            m_buffer = new Queue<byte>();
            m_bitCount = 8;
            m_byteCount = 0;
        }

        public void Enqueue(byte input)
        {
            lock(m_buffer)
                m_buffer.Enqueue(input);
        }

        public void Enqueue(byte[] input)
        {
            lock (m_buffer)
            {
                foreach (byte b in input)
                {
                    m_buffer.Enqueue(b);
                }
            }
        }

        public void Enqueue(byte[] input, int offset, int length)
        {
            lock (m_buffer)
            {
                for (int x=0; x<length; x++)
                {
                    m_buffer.Enqueue(input[offset + x]);
                }
            }
        }


        /*
        public bool NextBitLowest()
        {
            bool result;
            if ((current & 0x01) == 0x01)
                result = true;
            else
                result = false;
            current = (byte)(current >> 1);
            return result;
        }*/


        /* Returns the next MSB and shifts upward */
        [DebuggerStepThrough()]
        public bool NextBit()
        {
            if (m_bitCount == 8)
            {                
                lock(m_buffer)
                    m_current = m_buffer.Dequeue();
                m_bitCount = 0;
                m_byteCount++;
            }            

            bool result;
            if ((m_current & 0x80) == 0x80)
                result = true;
            else
                result = false;

            m_current = m_current << 1;
            m_bitCount++;
            return result;
        }

        /* Flushes the current byte */
        public void FlushByte()
        {
            lock (m_buffer)
            {
                if(m_buffer.Count >0)
                    m_current = m_buffer.Dequeue();
            }
            m_byteCount++;
            m_bitCount = 0;
        }

        public void ClearCount()
        {
            m_byteCount = 0;
        }

        public void Clear()
        {
            m_buffer.Clear();
            m_bitCount = 8;
            m_byteCount = 0;
        }
    }
}
