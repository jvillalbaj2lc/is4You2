using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Com.Afrodita.isForYou2
{
    public class PlayerManagerNetwork : Photon.PunBehaviour
    {
        public InputField _consola;
        public GameObject playerPrefab;
        // Se usa para instanciar.
        void Start(){
            InicializarJugadorEnEscena();
        }

        // Update se invoca cada frame.
        void Update(){
        }

        void InicializarJugadorEnEscena() {
            if (PhotonNetwork.connected)
                Commons.Traza(_consola, Commons.MENSAJE_INICIANDO_ESCENA_ONLINE + SceneManager.GetActiveScene().name + "...\n");
            else
                Commons.Traza(_consola, Commons.MENSAJE_INICIANDO_ESCENA_OFFLINE + SceneManager.GetActiveScene().name + "...\n");
        }
    }
}