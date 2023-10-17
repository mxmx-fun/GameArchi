using System;

namespace GameArchi.NetWorkSystem {

    public class Server {
        LowLevelServer server;
        public Action<int> OnConnectedHandler;
        public Action<int, ArraySegment<byte>> OnDateHandler;
        public Action<int> OnDisconnectedHandler;

        public Server(int maxMessageSize = 1024) {
            server = new LowLevelServer(maxMessageSize);
            server.OnConnectedHandler += OnConnectedHandler;
            server.OnDateHandler += OnDateHandler;
            server.OnDisconnectedHandler += OnDisconnectedHandler;
        }

        public bool Start(int port) {
            return server.Start(port);
        }

        public void Stop() {
            server.Stop();
        }

        public bool Send(int connectionId, ArraySegment<byte> date) {
            return server.Send(connectionId, date);
        }

        public bool Disconnect(int connectionId) {
            return server.Disconnect(connectionId);
        }

        public int Tick(int processLimit = 1000) {
            return server.Tick(processLimit);
        }
    }
}