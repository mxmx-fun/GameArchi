using System;
using System.Net;
using System.Net.Sockets;

namespace GameArchi.NetWorkSystem.Udp
{
    public class LowLevelClient
    {
        UdpClient udpClient;
        IPEndPoint serverEndPoint;

        int maxMessageSize;
        string serverIP;
        int serverPort;

        public event Action OnSendCompleteHandler;
        public event Action OnSendErrorHandler;
        public event Action<ArraySegment<byte>> OnDataHandler;

        public LowLevelClient(int maxMessageSize = 1024)
        {
            this.maxMessageSize = maxMessageSize;
            udpClient = new UdpClient();
        }

        public void SetReciver(string ip, int port)
        {
            serverEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
        }

        public void Send(ArraySegment<byte> data)
        {
            var count = udpClient.Send(data.Array, data.Array.Length, serverEndPoint);
            if (count == data.Array.Length)
            {
                OnSendCompleteHandler?.Invoke();
            }
            else
            {
                OnSendErrorHandler?.Invoke();
            }
        }

        public void Ondata()
        {
            if (serverEndPoint == null) return;
            ArraySegment<byte> datas = udpClient.Receive(ref serverEndPoint);
            if (datas.Array.Length > maxMessageSize) return;

            if (datas.Count > 0)
            {
                OnDataHandler?.Invoke(datas);
            }
        }

        public void Tick(int processLimit = 100)
        {
            for (int i = 0; i < processLimit; i++)
            {
                Ondata();
            }
        }

    }
}