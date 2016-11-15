using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Com.Afrodita.isForYou2
{
    public class ScenesManagerNetwork : MonoBehaviour
    {
        public GameObject playerPrefab;
        // Se usa para instanciar.
        void Start(){
            InicializarEscena();
        }

        void InicializarEscena()
        {
            if (PhotonNetwork.connected) {
                InicializarPlayer(true);
            }
            else {
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