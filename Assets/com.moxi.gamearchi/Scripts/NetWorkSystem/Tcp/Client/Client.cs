using System;

namespace GameArchi.NetWorkSystem
{

    public class Client
    {

        LowLevelClient client;
        public Action OnConnectedHandler;
        public Action<ArraySegment<byte>> OnDateHandler;
        public Action OnDisconnectedHandler;

        public Client(int maxMessageSize = 1024)
        {
            client = new LowLevelClient(maxMessageSize);
            client.OnConnectedHandler += OnConnectedHandler;
            client.OnDateHandler += OnDateHandler;
            client.OnDisconnectedHandler += OnDisconnectedHandler;
        }

        public void Connect(string ip, int port)
        {
            client.Connect(ip, port);
        }

        public void Send(ArraySegment<byte> date)
        {
            client.Send(date);
        }

        public void Disconnect()
        {
            client.Disconnect();
        }

        public void Tick(int processLimit = 1000)
        {
            client.Tick(processLimit);

        }
    }
}