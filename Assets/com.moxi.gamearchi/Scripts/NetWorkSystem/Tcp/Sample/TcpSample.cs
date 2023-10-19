using GameArchi.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace GameArchi.NetWorkSystem.Sample
{

    public class TcpSample : MonoBehaviour
    {
        [Header("server")]
        public Button openServerBtn;
        public Button closeServerBtn; 
        public Button sendServerBtn;
        public InputField inputServerField;
        public Text messageServerText;


        [Header("client")]
        public Button connectClientBtn;
        public Button disconnectClientBtn;
        public Button sendClientBtn;
        public InputField inputClientField;
        public Text messageClientText;

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
                messageClientText.text += "Client Connected\n";
            };

            client.OnDisconnectedHandler += ()=>
            {
                messageClientText.text += "Client Disconnected\n";
            };

            client.OnDataHandler += (data)=>
            {
                messageClientText.text += "Server:" + System.Text.Encoding.UTF8.GetString(data.Array).ToString();
            };

            server.OnConnectedHandler += (connectionId)=>
            {
                messageServerText.text += "Server Connected:" + connectionId + "\n";
            };

            server.OnDisconnectedHandler += (connectionId)=>
            {
                messageServerText.text += "Server Disconnected:" + connectionId + "\n";
            };

            server.OnDataHandler += (connectionId, data)=>
            {
                messageServerText.text += "Client:" + System.Text.Encoding.UTF8.GetString(data.Array).ToString();
            };

            //Init
            client.Init();
            server.Init();
            InitBtn();
        }

        public void InitBtn()
        {
            openServerBtn.onClick.AddListener(()=>{
                server.Start(8888);
            });
            closeServerBtn.onClick.AddListener(()=>{
                server.Stop();
            });
            sendServerBtn.onClick.AddListener(()=>{
                server.Send(1, new System.ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(inputServerField.text)));
            });

            connectClientBtn.onClick.AddListener(()=>{
                client.Connect("localhost", 8888);
            });
            disconnectClientBtn.onClick.AddListener(()=>{
                client.Disconnect();
            });
            sendClientBtn.onClick.AddListener(()=>{
                client.Send(new System.ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(inputClientField.text)));
            });
        }

        public void Update()
        {

            if (server.State == NetState.Connected)
            {
                server.Tick(100);
            }

            client.Tick(100);
        }
    }
}