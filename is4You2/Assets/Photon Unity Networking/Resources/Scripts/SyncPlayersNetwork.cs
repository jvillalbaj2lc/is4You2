using UnityEngine;
using UnityEngine.UI;

namespace Com.Afrodita.isForYou2
{
    public class SyncPlayersNetwork : Photon.PunBehaviour
    {
        Vector3 trueLoc;
        Quaternion trueRot;
        PhotonView pv;
        public InputField _consola;

        void Start()
        {
            Canvas canvasName = this.gameObject.GetComponentInChildren<Canvas>();
            pv = GetComponent<PhotonView>();
            if (PhotonNetwork.connected) {
                canvasName.GetComponent<Text>().text = photonView.owner.name;
            }
                //_namePlayer.text = photonView.owner.name;
        }

        // Update is called once per frame

        void Update()
        {
            if (PhotonNetwork.connected)
            {
                if (!pv.isMine)
                {
                    transform.position = Vector3.Lerp(transform.position, trueLoc, Time.deltaTime * 5);
                    transform.rotation = Quaternion.Lerp(transform.rotation, trueRot, Time.deltaTime * 5);
                }
            }
        }

        void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {

            //we are reicieving data
            if (stream.isReading)
            {
                //receive the next data from the stream and set it to the truLoc varible
                if (!pv.isMine)
                {//do we own this photonView?????
                    this.trueLoc = (Vector3)stream.ReceiveNext(); //the stream send data types of "object" we must typecast the data into a Vector3 format
                    this.trueRot = (Quaternion)stream.ReceiveNext();
                }
            }
            //we need to send our data
            else
            {
                //send our posistion in the data stream
                if (pv.isMine)
                {
                    stream.SendNext(transform.position);
                    stream.SendNext(transform.rotation);
                }
            }
        }
    }
}