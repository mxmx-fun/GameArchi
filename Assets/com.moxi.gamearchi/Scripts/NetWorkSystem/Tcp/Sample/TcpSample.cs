using GameArchi.Utils;
using UnityEngine;
using UnityEngine.UI;
using BufferIO.Helper;

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
            client.OnConnectedHandler += () =>
            {
                messageClientText.text += "Client Connected\n";
            };

            client.OnDisconnectedHandler += () =>
            {
                messageClientText.text += "Client Disconnected\n";
            };

            client.OnDataHandler += (data) =>
            {
                var message = GetStringDate(data.Array);
                messageClientText.text += "Server:" + message + "\n";
            };

            server.OnConnectedHandler += (connectionId) =>
            {
                messageServerText.text += "Server Connected:" + connectionId + "\n";
            };

            server.OnDisconnectedHandler += (connectionId) =>
            {
                messageServerText.text += "Server Disconnected:" + connectionId + "\n";
            };

            server.OnDataHandler += (connectionId, data) =>
            {
                var message = GetStringDate(data.Array);
                messageServerText.text += "Client:" + message + "\n"; ;
            };

            //Init
            client.Init();
            server.Init();
            InitBtn();
        }

        public void InitBtn()
        {
            openServerBtn.onClick.AddListener(() =>
            {
                server.Start(8888);
            });
            closeServerBtn.onClick.AddListener(() =>
            {
                server.Stop();
            });
            sendServerBtn.onClick.AddListener(() =>
            {
                var message = WriteStringData(inputServerField.text);
                server.Send(1, message);
            });

            connectClientBtn.onClick.AddListener(() =>
            {
                client.Connect("localhost", 8888);
            });
            disconnectClientBtn.onClick.AddListener(() =>
            {
                client.Disconnect();
            });
            sendClientBtn.onClick.AddListener(() =>
            {
                var message = WriteStringData(inputClientField.text);
                client.Send(message);
            });
        }

        public byte[] WriteStringData(string message)
        {
            int index = 0;
            byte[] data = new byte[1024];
            BufferWriter.WriteUTF8String(data, message, ref index);
            return data;
        }

        public string GetStringDate(byte[] data)
        {
            int index = 0;
            string content = BufferReader.ReadUTF8String(data, ref index);
            return content;
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