using System;
using Telepathy;

namespace GameArchi.NetWorkSystem
{
    public class LowLevelClient
    {
        Telepathy.Client client;
        public Telepathy.Client Client => client;

        public Action OnConnectedHandler;
        public Action<ArraySegment<byte>> OnDateHandler;
        public Action OnDisconnectedHandler;

        public LowLevelClient(int maxMessageSize =  1024)
        {
            client = new Telepathy.Client(maxMessageSize);
            client.OnConnected += OnConnectedHandler;
            client.OnData += OnDateHandler;
            client.OnDisconnected += OnDisconnectedHandler;
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

        public void Tick(int processLimit = 1000) {
            client.Tick(processLimit);
            
        }

    
    }
}