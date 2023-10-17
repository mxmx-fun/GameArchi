using System;

namespace GameArchi.NetWorkSystem
{

    public class Client
    {

        LowLevelClient client;

        public NetState State => client.State();


        public Client(int maxMessageSize = 1024)
        {
            client = new LowLevelClient(maxMessageSize);
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