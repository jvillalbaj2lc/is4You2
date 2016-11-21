using UnityEngine;
using UnityEngine.UI;

namespace Com.Afrodita.isForYou2
{
    public class MenuManager : MonoBehaviour
    {
        public GameObject _menu;

        void Start(){
            _menu.gameObject.SetActive(false);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_menu.gameObject.GetActive())
                    _menu.gameObject.SetActive(false);
                else
                    _menu.gameObject.SetActive(true);
            }
        }
    }
}