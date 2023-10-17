using System;

namespace GameArchi.NetWorkSystem
{

    public class Server
    {
        LowLevelServer server;
        public NetState State => server.State();

        public Telepathy.Server GetServer()
        {
            return server.Server;
        }

        public Server(int maxMessageSize = 1024)
        {
            server = new LowLevelServer(maxMessageSize);
        }

        public void Test(int A, ArraySegment<byte> B) {
            UnityEngine.Debug.Log("Server OnDateHandler2");
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