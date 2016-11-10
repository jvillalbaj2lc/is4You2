using ExitGames.Client.Photon.Chat;
using ExitGames.Client.Photon;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Com.Afrodita.isForYou2
{
    public class ChatManagerNetwork : MonoBehaviour, IChatClientListener
    {
        public string appIdChat = "6c0a7c87-5329-4312-b940-26d91378aa9c";
        public InputField _inputSendChat;
        public InputField _inputGetChat;
        public Canvas namePlayer;
        private ExitGames.Client.Photon.ConnectionProtocol connectProtocol;
        ChatClient chatClient;

        void Start() {

            connectProtocol = ExitGames.Client.Photon.ConnectionProtocol.Udp;
            chatClient = new ChatClient(this, connectProtocol);
            chatClient.ChatRegion = "US";

            ExitGames.Client.Photon.Chat.AuthenticationValues authValues = new ExitGames.Client.Photon.Chat.AuthenticationValues();
            authValues.UserId = namePlayer.GetComponent<Text>().text;
            authValues.AuthType = ExitGames.Client.Photon.Chat.CustomAuthenticationType.None;

            chatClient.Connect(appIdChat, "1", authValues);
        }

        void Update() {
            if (chatClient != null) {
                chatClient.Service();
            }
        }

        public void OnInputSendChat() {
            chatClient.PublishMessage("Public", _inputSendChat.text);
            _inputSendChat.text = string.Empty;
        }

        #region Photon Chat Callbacks

        
        public void DebugReturn(DebugLevel level, string message)
        {
        }
        public void OnChatStateChange(ChatState state)
        {
        }
        public void OnConnected()
        {
            chatClient.Subscribe(new string[] { "Public" }); //subscribe to chat channel once connected to server
        }

        public void OnDisconnected()
        {
        }
        public void OnGetMessages(string channelName, string[] senders, object[] messages)
        {
            int msgCount = messages.Length;
            for (int i = 0; i < msgCount; i++)
            { //go through each received msg
                string msg = messages[i].ToString();
                _inputGetChat.text = _inputGetChat.text + namePlayer + ":" + msg + "\n";
                Debug.Log(namePlayer + ": " + msg);
            }
        }
        public void OnPrivateMessage(string sender, object message, string channelName)
        {
        }
        public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
        {
        }

        public void OnSubscribed(string[] channels, bool[] results)
        {
            Debug.Log("Subscribed to a new channel!");
        }
        public void OnUnsubscribed(string[] channels)
        {
        }
        void OnApplicationQuit()
        {
            if (chatClient != null) { chatClient.Disconnect(); }
        }
        #endregion
    }
}