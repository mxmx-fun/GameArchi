using System;

namespace GameArchi.NetWorkSystem
{

    public class LowLevelServer
    {
        Telepathy.Server server;
        public Action<int> OnConnectedHandler;
        public Action<int, ArraySegment<byte>> OnDateHandler;
        public Action<int> OnDisconnectedHandler;

        public LowLevelServer(int maxMessageSize = 1024)
        {
            server = new Telepathy.Server(maxMessageSize);
            server.OnConnected += OnConnectedHandler;
            server.OnData += OnDateHandler;
            server.OnDisconnected += OnDisconnectedHandler;
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