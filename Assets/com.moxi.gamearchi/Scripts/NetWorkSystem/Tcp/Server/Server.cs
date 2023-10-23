using System;

namespace GameArchi.NetWorkSystem.Tcp
{

    public class Server
    {
        LowLevelServer server;
        public NetState State => server.State();

        public event Action<int> OnConnectedHandler;
        public event Action<int> OnDisconnectedHandler;
        public event Action<int, ArraySegment<byte>> OnDataHandler;

        public Server(int maxMessageSize = 1024)
        {
            server = new LowLevelServer(maxMessageSize);
        }

        public void Init()
        {
            server.Init();
            server.OnConnectedHandler += OnConnectedHandler;
            server.OnDisconnectedHandler += OnDisconnectedHandler;
            server.OnDataHandler += OnDataHandler;
        }

        public Telepathy.Server GetServer()
        {
            return server.Server;
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