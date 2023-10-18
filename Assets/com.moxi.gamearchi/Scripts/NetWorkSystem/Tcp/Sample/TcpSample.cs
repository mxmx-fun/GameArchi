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

            //Bind Event
            client.OnConnectedHandler += ()=>
            {
                Debug.Log("Client Connected");
            };

            client.OnDisconnectedHandler += ()=>
            {
                Debug.Log("Client Disconnected");
            };

            client.OnDataHandler += (data)=>
            {
                Debug.Log("Client Receive Data:" + System.Text.Encoding.UTF8.GetString(data.Array));
            };

            server.OnConnectedHandler += (connectionId)=>
            {
                Debug.Log("Server Connected:" + connectionId);
            };

            server.OnDisconnectedHandler += (connectionId)=>
            {
                Debug.Log("Server Disconnected:" + connectionId);
            };

            server.OnDataHandler += (connectionId, data)=>
            {
                Debug.Log("Server Receive Data:" + System.Text.Encoding.UTF8.GetString(data.Array));
            };

            //Init
            client.Init();
            server.Init();
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