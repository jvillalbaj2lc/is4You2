using UnityEngine;
using UnityEngine.UI;

namespace Com.Afrodita.isForYou2
{
    public class ConsoleManager : MonoBehaviour
    {
        public GameObject panel;
        public bool InicioVisible;

        void Start() {
            panel.SetActive(InicioVisible);
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Tab)) {
                if (InicioVisible){
                    panel.SetActive(false);
                    InicioVisible = false;
                }
                else{
                    panel.SetActive(true);
                    InicioVisible = true;
                }
            }
        }
    }
}