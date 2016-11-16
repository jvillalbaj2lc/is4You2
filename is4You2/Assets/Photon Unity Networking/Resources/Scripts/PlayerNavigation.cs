using UnityEngine;

namespace Com.Afrodita.isForYou2
{
    public class PlayerNavigation : Photon.PunBehaviour
    {
        private Camera cam;
        private NavMeshAgent agent;
        private PhotonView myPhotonView;

        void Start(){
            cam = GetComponentInChildren<Camera>();
            agent = this.GetComponent<NavMeshAgent>();
            myPhotonView = this.GetComponent<PhotonView>();
            Debug.Log("Inicializada las variables para el Navigation");
        }

        void Update(){

            if (PhotonNetwork.connected) {
                if (myPhotonView.isMine)
                    Walk();
            }
            else {
                Walk();
            }
        }

        void Walk() {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit)){
                    agent.SetDestination(hit.point);
                }
            }
        }
    }
}