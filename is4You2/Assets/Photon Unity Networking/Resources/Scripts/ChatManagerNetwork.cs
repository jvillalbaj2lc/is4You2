using ExitGames.Client.Photon.Chat;
using ExitGames.Client.Photon;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Com.Afrodita.isForYou2
{
    public class ChatManagerNetwork : Photon.PunBehaviour, IChatClientListener
    {
        public string appIdChat = "6c0a7c87-5329-4312-b940-26d91378aa9c";
        public InputField _inputSendChat;
        public Text _inputGetChat;
        public Transform listGetChats;

        private ExitGames.Client.Photon.ConnectionProtocol connectProtocol;
        private string namePlayer = "Invitado";
        private Scrollbar _scrollBar;
        ChatClient chatClient;

        public void Start() {

            _scrollBar = this.gameObject.GetComponentInChildren<Scrollbar>();
            _inputSendChat.text = String.Empty;
            if (PhotonNetwork.connected)
                namePlayer = PhotonNetwork.AuthValues.UserId;

            connectProtocol = ExitGames.Client.Photon.ConnectionProtocol.Udp;
            chatClient = new ChatClient(this, connectProtocol);
            chatClient.ChatRegion = "US";

            ExitGames.Client.Photon.Chat.AuthenticationValues authValues = new ExitGames.Client.Photon.Chat.AuthenticationValues();

            authValues.UserId = namePlayer;
            authValues.AuthType = ExitGames.Client.Photon.Chat.CustomAuthenticationType.None;

            chatClient.Connect(appIdChat, "1", authValues);
        }

        void Update() {
            if (chatClient != null) {
                chatClient.Service();
            }
        }

        #region Photon Chat Callbacks

        public void OnInputSendChat()
        {
            if (!string.IsNullOrEmpty(_inputSendChat.text))
            {
                chatClient.PublishMessage("Public", namePlayer + ":" + _inputSendChat.text);
                _inputSendChat.ActivateInputField();
                _inputSendChat.Select();
            }
            _inputSendChat.text = string.Empty;
        }
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
            Text clone = (Text)Instantiate(_inputGetChat, listGetChats);

            int msgCount = messages.Length;
            for (int i = 0; i < msgCount; i++)
            { //go through each received msg
                string msg = messages[i].ToString();
                _inputGetChat.text = msg;
            }
            clone.transform.SetParent(listGetChats);
            clone.transform.SetSiblingIndex(listGetChats.childCount - 1);
            clone.text = _inputGetChat.text;
            _scrollBar.value = 0f;
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
        void showMessage() {

        }
        #endregion
    }
}