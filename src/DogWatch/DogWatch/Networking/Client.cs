using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.Drawing.Imaging;

namespace DogWatch.Networking
{
    public class Client
    {
        private Socket m_sock;
        public Socket sock { get { return m_sock; } }
        
        private int m_ID;
        public int ID { get { return m_ID; } }
        
        private PacketBuffer m_packetBuffer;
        public PacketBuffer packetBuffer { get { return m_packetBuffer; } }

        private byte[] m_buffer = new byte[1024];

        private AsyncCallback m_onReceive;
        private AsyncCallback m_onSend;

        public short strWidth;
        public short strHeight;
        public short strQuality;
        public short strCompression;


        private ImageCodecInfo m_jpgEncoder;
        public ImageCodecInfo jpgEncoder { get { return m_jpgEncoder; } }
        private EncoderParameters m_compressionParam;
        public EncoderParameters compressionParam { get { return m_compressionParam; } }

        public Client(Socket clientSocket)
        {
            m_packetBuffer = new PacketBuffer(this);
            m_sock = clientSocket;
            m_onReceive = new AsyncCallback(OnReceive);
            m_onSend = new AsyncCallback(OnSend);
            strWidth = 640;
            strHeight = 480;
            strQuality = 100;
            strCompression = 100;
            GenerateEncoder();
        }        

        private void GenerateID()
        {
            m_ID = m_sock.GetHashCode();
        }

        private void GenerateEncoder()
        {
            foreach (ImageCodecInfo info in ImageCodecInfo.GetImageEncoders())
            {
                if (info.FormatID == ImageFormat.Jpeg.Guid)
                {
                    m_jpgEncoder = info;
                    m_compressionParam = new EncoderParameters(2);
                    m_compressionParam.Param[0] = new EncoderParameter(Encoder.Compression, strCompression);
                    m_compressionParam.Param[1] = new EncoderParameter(Encoder.Quality, strQuality);
                    return;
                }
            }
        }

        private void UpdateEncoder()
        {
            m_compressionParam.Param[0] = new EncoderParameter(Encoder.Compression, strCompression);
            m_compressionParam.Param[1] = new EncoderParameter(Encoder.Quality, strQuality);
        }

        private void BeginReceive()
        {
            m_sock.BeginReceive(m_buffer, 0, m_buffer.Length, SocketFlags.None, m_onReceive, null);
        }

        private void OnReceive(IAsyncResult iar)
        {            
            int count = 0;
            try
            {
                count = m_sock.EndReceive(iar);
                if (count <= 0)
                {
                    Dispose();
                }
                else
                {
                    packetBuffer.Enqueue(m_buffer, 0, count);                   
                    if (packetBuffer.ProcessQueue())
                        Network.NewPacket(this);
                    m_sock.BeginReceive(m_buffer, 0, m_buffer.Length, SocketFlags.None, OnReceive, null);
                }
            }
            catch (ObjectDisposedException) { }
            catch (Exception)
            {
                Dispose();                       
            }
        }

        public void Send(byte[]data)
        {
            m_sock.BeginSend(data, 0, data.Length, SocketFlags.None, m_onSend, null);
        }

        private void OnSend(IAsyncResult iar)
        {
            m_sock.EndSend(iar);
        }

        public void Dispose()
        {

        }
    }
}
