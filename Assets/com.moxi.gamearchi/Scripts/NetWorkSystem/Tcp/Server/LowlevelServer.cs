using System;

namespace GameArchi.NetWorkSystem
{

    public class LowLevelServer
    {
        Telepathy.Server server;
        public Telepathy.Server Server => server;
        NetState state;

        public LowLevelServer(int maxMessageSize = 1024)
        {
            state = NetState.Disconnected;
            server = new Telepathy.Server(maxMessageSize);
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