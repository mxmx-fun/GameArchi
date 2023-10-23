using System;

namespace GameArchi.NetWorkSystem
{
    public class LowLevelClient
    {
        Telepathy.Client client;
        public Telepathy.Client Client => client;

        NetState state;

        public event Action OnConnectedHandler;
        public event Action OnDisconnectedHandler;
        public event Action<ArraySegment<byte>> OnDataHandler;


        public LowLevelClient(int maxMessageSize = 1024)
        {
            state = NetState.Disconnected;
            client = new Telepathy.Client(maxMessageSize);
        }

        public void Init() {
            client.OnConnected += OnConnected;
            client.OnDisconnected += OnDisconnected;
            client.OnData += OnData;
        }


        public void Connect(string ip, int port)
        {
            client.Connect(ip, port);
        }

        public void Send(ArraySegment<byte> date)
        {
            client.Send(date);
        }

        public void OnConnected() {
            OnConnectedHandler?.Invoke();
        }

        public void OnDisconnected() {
            OnDisconnectedHandler?.Invoke();
        }

        public void OnData(ArraySegment<byte> data) {
            OnDataHandler?.Invoke(data);
        }

        public NetState State()
        {
            if (client.Connected)
            {
                state = NetState.Connected;
            }

            if (client.Connecting)
            {
                state = NetState.Connecting;
            }

            if (!client.Connected && !client.Connecting)
            {
                state = NetState.Disconnected;
            }

            return state;
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