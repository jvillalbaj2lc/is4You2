using UnityEngine;
using UnityEngine.UI;

namespace Com.Afrodita.isForYou2
{
    public class GameActionsNetwork : Photon.PunBehaviour
    {
        #region Variables públicas.
        public PhotonLogLevel Loglevel = PhotonLogLevel.Informational;
        public InputField _consola;
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
            Commons.Traza(_consola, Commons.MENSAJE_CONECTANDO_SERVIDOR);

            // 01. Comprobamos si está abierta previamente una conexión, si no abrimos una nueva.
            if (PhotonNetwork.connected)
            {
                Commons.Traza(_consola, Commons.MENSAJE_CONEXION_YA_ESTABLECIDA);

                // 02. Si ya está abierta la conexión, entramos a un Room de lo contrario se lanzará la Excepción OnPhotonRandomJoinFailed() y se creará uno.
                PhotonNetwork.JoinRandomRoom();
                Commons.Traza(_consola, Commons.MENSAJE_CONECTAR_SALA_ALEATORIA);
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
            Commons.Traza(_consola, Commons.MENSAJE_INICO_LOGS);

            // 02. Obvia la entrada al Lobby ya que vamos directamente a un room.
            PhotonNetwork.autoJoinLobby = false;
            Commons.Traza(_consola, Commons.MENSAJE_NO_ENTRAR_LOBBY);

            // 03. Sincroniza automáticamente la carga de las escenas para todos los jugadores.
            PhotonNetwork.automaticallySyncScene = true;
            Commons.Traza(_consola, Commons.MENSAJE_SINCRONIZACION_ESCENAS);
        }
        #endregion

        #region Photon CallBacks
        public override void OnConnectedToMaster()
        {
            Commons.Traza(_consola, Commons.MENSAJE_CONEXION_SERVIDOR_MAESTRO);
            PhotonNetwork.JoinRandomRoom();
        }
        public override void OnConnectedToPhoton()
        {
            Commons.Traza(_consola, Commons.MENSAJE_CONEXION_SERVIDOR_CORRECTAMENTE);
        }
        public override void OnJoinedRoom()
        {
            if (PhotonNetwork.room.playerCount == 1)
            {
                Commons.Traza(_consola, Commons.MENSAJE_CONEXION_SALA);
                PhotonNetwork.LoadLevel(Commons.Escenas.Apartment.ToString());
            }
            #endregion
        }
        public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
        {
            Commons.Traza(_consola, Commons.MENSAJE_CONEXION_FAIL);
            Commons.Traza(_consola, Commons.MENSAJE_CONECTAR_SALA_ALEATORIA);
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