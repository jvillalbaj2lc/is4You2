using UnityEngine;

namespace Com.Afrodita.isForYou2
{
    public class NamePlayerManager : MonoBehaviour
    {
        // Update se invoca cada frame.
        void Update(){
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        }
    }
}