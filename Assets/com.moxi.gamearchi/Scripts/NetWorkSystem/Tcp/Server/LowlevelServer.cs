using System;

namespace GameArchi.NetWorkSystem
{

    public class LowLevelServer
    {
        Telepathy.Server server;
        public Telepathy.Server Server => server;
        NetState state;

        public event Action<int> OnConnectedHandler;
        public event Action<int> OnDisconnectedHandler;
        public event Action<int, ArraySegment<byte>> OnDataHandler;

        public LowLevelServer(int maxMessageSize = 1024)
        {
            state = NetState.Disconnected;
            server = new Telepathy.Server(maxMessageSize);
        }

        public void Init() {
            server.OnConnected += OnConnected;
            server.OnDisconnected += OnDisconnected;
            server.OnData += OnData;
        }

        public NetState State()
        {
            if (server.Active)
            {
                state = NetState.Connected;
            }
            else
            {
                state = NetState.Disconnected;
            }

            return state;
        }

        public void OnConnected(int connectionId) {
            OnConnectedHandler?.Invoke(connectionId);
        }

        public void OnDisconnected(int connectionId) {
            OnDisconnectedHandler?.Invoke(connectionId);
        }

        public void OnData(int connectionId, ArraySegment<byte> data) {
            OnDataHandler?.Invoke(connectionId, data);
        }

        public bool Start(int port)
        {
            return server.Start(port);
        }

        public void Stop()
        {
            server.Stop();
        }

        public bool Send(int connectionId, ArraySegment<byte> date)
        {
            return server.Send(connectionId, date);
        }

        public bool Disconnect(int connectionId)
        {
            return server.Disconnect(connectionId);
        }

        public int Tick(int processLimit = 1000)
        {
            return server.Tick(processLimit);
        }
    }
}