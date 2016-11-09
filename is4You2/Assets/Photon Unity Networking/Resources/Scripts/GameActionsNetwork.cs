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
        #endregion

        #region Métodos privados.
        /// <summary>
        /// Método que se invoca en la primera fase de carga del juego.
        /// </summary>
        void Awake()
        {
            // 01. Nivel de información que se va a mostrar en el Log.
            PhotonNetwork.logLevel = Loglevel;
            Commons.Traza(_consola, Commons.MENSAJE_INICO_LOGS);

            // 02. Obvia la entrada al Lobby ya que vamos directamente a un room.
            PhotonNetwork.autoJoinLobby = false;
            Commons.Traza(_consola,Commons.MENSAJE_NO_ENTRAR_LOBBY);

            // 03. Sincroniza automáticamente la carga de las escenas para todos los jugadores.
            PhotonNetwork.automaticallySyncScene = true;
            Commons.Traza(_consola, Commons.MENSAJE_SINCRONIZACION_ESCENAS);
        }

        /// <summary>
        /// Método público que realiza la conexión al servidor de Photon.
        /// </summary>
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
                Commons.Traza(_consola, Commons.MENSAJE_CONEXION_SERVIDOR_CONFIGURACION);
                // 03. Se establece la conexión, mediante configuración de la versión del juego.
                PhotonNetwork.ConnectUsingSettings(gameVersion);
            }
        }
        #endregion
    }
}