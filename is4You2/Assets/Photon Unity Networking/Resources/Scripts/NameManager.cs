using UnityEngine;
using UnityEngine.UI;

namespace Com.Afrodita.isForYou2
{
    public class NameManager : MonoBehaviour
    {
        public TextMesh _namePlayer;
        public Camera _camara;
        // Se usa para instanciar.
        Vector2 boxPosition;
        void Start(){
            boxPosition = Camera.main.WorldToScreenPoint(transform.position);
        }

        void OnGUI() {
            _namePlayer.transform.LookAt(_camara.transform);
        }
    }
}