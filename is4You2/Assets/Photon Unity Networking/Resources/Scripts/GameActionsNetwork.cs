using UnityEngine;
using UnityEngine.UI;

namespace Com.Afrodita.isForYou2
{
    public class GameActionsNetwork : Photon.PunBehaviour
    {
        #region Variables públicas.
        public PhotonLogLevel Loglevel = PhotonLogLevel.Informational;
        public string gameVersion = "1";
        public InputField _inputNamePlayer;
        #endregion

        #region Variables privadas.
        // Store the PlayerPref Key to avoid typos
        static string playerNamePrefKey = "PlayerName";
        #endregion

        #region Métodos privados.
        public void Connect()
        {

            // 01. Comprobamos si está abierta previamente una conexión, si no abrimos una nueva.
            if (PhotonNetwork.connected)
            {
                // 02. Si ya está abierta la conexión, entramos a un Room de lo contrario se lanzará la Excepción OnPhotonRandomJoinFailed() y se creará uno.
                PhotonNetwork.JoinRandomRoom();
            }
            else {
                // 03. Se establece la conexión, mediante configuración de la versión del juego.
                SetPlayerName(_inputNamePlayer.text);
                PhotonNetwork.ConnectUsingSettings(gameVersion);
            }
        }
        #endregion

        #region Eventos Unity
        void Start() {
            GetNamePlayerPhoton();
        }
        void Awake()
        {
            // 01. Nivel de información que se va a mostrar en el Log.
            PhotonNetwork.logLevel = Loglevel;

            // 02. Obvia la entrada al Lobby ya que vamos directamente a un room.
            PhotonNetwork.autoJoinLobby = false;

            // 03. Sincroniza automáticamente la carga de las escenas para todos los jugadores.
            PhotonNetwork.automaticallySyncScene = true;
        }
        #endregion

        #region Photon CallBacks
        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinRandomRoom();
        }
        public override void OnConnectedToPhoton()
        {
            Debug.Log(Commons.MENSAJE_CONECTANDO_SERVIDOR);
        }
        public override void OnJoinedRoom()
        {
            if (PhotonNetwork.room.playerCount == 1)
            {
                Debug.Log(Commons.MENSAJE_CONEXION_SALA);
                PhotonNetwork.LoadLevel(Commons.Escenas.Apartment.ToString());
            }
            #endregion
        }
        public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
        {
            PhotonNetwork.CreateRoom(null, new RoomOptions(), null);
        }
        void GetNamePlayerPhoton() {

            string defaultName = string.Empty;
            AuthenticationValues autenticacion;

            if (_inputNamePlayer != null)
            {
                if (PlayerPrefs.HasKey(playerNamePrefKey))
                {
                    defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                    _inputNamePlayer.text = defaultName;
                }
            }
            PhotonNetwork.playerName = defaultName;
            autenticacion = new AuthenticationValues(defaultName);
        }
        public void SetPlayerName(string value)
        {
            // #Important
            PhotonNetwork.playerName = value + " "; // force a trailing space string in case value is an empty string, else playerName would not be updated.
            PlayerPrefs.SetString(playerNamePrefKey, value);
        }
    }
}