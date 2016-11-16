using UnityEngine;
using System;

namespace Com.Afrodita.isForYou2
{
    public class ThirdPersonCamera : Photon.PunBehaviour
    {
        #region Variables públicas.
        /// <summary>
        /// Representa el objetivo que la camara va a seguir.
        /// </summary>
        public Transform target;
        /// <summary>
        /// Representa la distancia de la camara con respecto al objetivo.
        /// </summary>
        public float distance = 50.0f;
        /// <summary>
        /// Representa el angulo mínimo de la camara con respecto a la parte inferior.
        /// </summary>
        public float Y_ANGLE_MIN = 0.0f;
        /// <summary>
        /// Representa el angulo mínimo de la camara con respecto a la parte superior.
        /// </summary>
        public float Y_ANGLE_MAX = 50.0f;
        /// <summary>
        /// Representa la sensibilidad del ratón al mover la camara.
        /// </summary>
        public float sensibility = 1.0f;
        #endregion

        #region Variables privadas.
        private Transform cameraTransform;
        private float currentX = 0.0f;
        private float currentY = 0.0f;
        private bool zoomForward = false;
        private bool zoombackWarkds = false;
        private Camera cameraPlayer;
        private float zoom = 0.0f;
        #endregion

        #region Eventos Unity.
        void Start()
        {

            if (PhotonNetwork.connected)
            {
                if (target.GetComponent<PhotonView>().isMine)
                {
                    OnStartFollowTarget();
                }
                else {
                    // 01. Se elimina la camara del otro jugador instanciado de nuestro jugador.
                    target.GetComponentInChildren<Camera>().gameObject.SetActive(false);
                }
            }
            else {
                OnStartFollowTarget();
            }
        }
        void OnStartFollowTarget() {
            cameraTransform = this.gameObject.GetComponent<Camera>().transform;
            cameraPlayer = this.gameObject.GetComponentInChildren<Camera>();
            }
        void Update()
        {
            if (Input.GetMouseButton(1)){
                currentX += Input.GetAxis("Mouse X") * sensibility;
                currentY += Input.GetAxis("Mouse Y") * -2;
                currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
            }

            if (Input.GetKey(KeyCode.Mouse2))
            {
                zoom = Input.GetAxis("Mouse Y") * -2;
                distance = distance + zoom;
            }
        }
        void LateUpdate()
        {
            Vector3 direction = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

            cameraTransform.position = target.position + rotation * direction;
            cameraTransform.LookAt(target.position);
        }
        #endregion
    }
}