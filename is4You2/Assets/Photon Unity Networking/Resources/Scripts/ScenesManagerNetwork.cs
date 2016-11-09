using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Com.Afrodita.isForYou2
{
    public class ScenesManagerNetwork : MonoBehaviour
    {
        public InputField _consola;
        public GameObject playerPrefab;
        // Se usa para instanciar.
        void Start()
        {
            InicializarEscena();
        }

        // Update se invoca cada frame.
        void Update()
        {
        }
        void InicializarEscena()
        {
            if (PhotonNetwork.connected) {
                Commons.Traza(_consola, Commons.MENSAJE_INICIANDO_ESCENA_ONLINE + SceneManager.GetActiveScene().name);
                InicializarPlayer(true);
            }
            else {
                Commons.Traza(_consola, Commons.MENSAJE_INICIANDO_ESCENA_OFFLINE + SceneManager.GetActiveScene().name);
                InicializarPlayer(false);
            }
        }
        void InicializarPlayer(bool online)
        {
            if (online)
                PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0, 5, 0), Quaternion.identity, 0);

            else
                Instantiate(playerPrefab);
        }
    }
}