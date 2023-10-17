using UnityEngine;

namespace GameArchi.NetWorkSystem.Sample
{

    public class TcpSample : MonoBehaviour
    {

        Client client;
        Server server;

        public void Awake()
        {
            Application.runInBackground = true;

            client = new Client();
            server = new Server();

            var lowLevelClient = client.GetClient();
            var lowLevelServer = server.GetServer();

            lowLevelClient.OnConnected += () =>
            {
                Debug.Log("lowLevelClient connected");
            };

            lowLevelClient.OnData += (date) =>
            {
                Debug.Log("lowLevelClient received:" + System.Text.Encoding.UTF8.GetString(date.Array, date.Offset, date.Count));
            };

            lowLevelClient.OnDisconnected += () =>
            {
                Debug.Log("client disconnected");
            };

            lowLevelServer.OnConnected += (connectionId) =>
            {
                Debug.Log("lowLevelServer connected:" + connectionId);
            };

            lowLevelServer.OnData += (connectionId, date) =>
            {
                Debug.Log("lowLevelServer received:" + System.Text.Encoding.UTF8.GetString(date.Array, date.Offset, date.Count));
                lowLevelServer.Send(connectionId, date);
            };

            lowLevelServer.OnDisconnected += (connectionId) =>
            {
                Debug.Log("lowLevelServer disconnected:" + connectionId);
            };
        }

        public void Start()
        {
            server.Start(8888);
            client.Connect("localhost", 8888);

        }

        public void Update()
        {

            if (server.State == NetState.Connected)
            {
                server.Tick(100);
            }

            if (client.State == NetState.Connected)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                client.Send(new System.ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes("hello server")));
            }
            client.Tick(100);
        }
    }
}