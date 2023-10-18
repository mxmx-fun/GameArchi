using System;

namespace GameArchi.NetWorkSystem
{

    public class Client
    {

        LowLevelClient client;

        public NetState State => client.State();

        public event Action OnConnectedHandler;
        public event Action OnDisconnectedHandler;
        public event Action<ArraySegment<byte>> OnDataHandler;


        public Client(int maxMessageSize = 1024)
        {
            client = new LowLevelClient(maxMessageSize);
        }

        public void Init() {
            client.OnConnectedHandler += OnConnectedHandler;
            client.OnDisconnectedHandler += OnDisconnectedHandler;
            client.OnDataHandler += OnDataHandler;
            client.Init();
        }

        public Telepathy.Client GetClient()
        {
            return client.Client;
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