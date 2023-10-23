using System;

namespace GameArchi.NetWorkSystem.Udp
{

    public class Client
    {
        LowLevelClient client;

        public event Action OnSendCompleteHandler;
        public event Action OnSendErrorHandler;
        public event Action<ArraySegment<byte>> OnDataHandler;

        public void Send(ArraySegment<byte> date) => client.Send(date);
        public void Tick(int processLimit = 100) => client.Tick(processLimit);
        public void SetReciver(string ip, int port) => client.SetReciver(ip, port);
        

        public Client(int maxMessageSize = 1024)
        {
            client = new LowLevelClient(maxMessageSize);
        }

        public void Init() {
            client.OnSendCompleteHandler += OnSendCompleteHandler;
            client.OnSendErrorHandler += OnSendErrorHandler;
            client.OnDataHandler += OnDataHandler;
        }
    }
}