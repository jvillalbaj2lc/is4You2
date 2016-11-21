using UnityEngine;
using UnityEngine.UI;

namespace Com.Afrodita.isForYou2
{
    public class Commons : MonoBehaviour
    {
        #region Propiedades.
        public const string MENSAJE_CONECTANDO_SERVIDOR = "1. Conectando con el servidor, por favor espere...\n";
        public const string MENSAJE_CONEXION_YA_ESTABLECIDA = "2. La aplicación ya estaba conectada al servidor de Photon Cloud...\n";
        public const string MENSAJE_CONEXION_SERVIDOR_CORRECTAMENTE = "2.2 Se ha conectado correctamente al servidor Photon Cloud...\n";
        public const string MENSAJE_CONEXION_SERVIDOR_MAESTRO = "3. Se ha realizado la conexión al Servidor Maestro...\n";
        public const string MENSAJE_CONEXION_SALA = "4. El jugador ha entrado en una sala del servidor...\n";
        public const string MENSAJE_CONEXION_FAIL = "4.1 El juego falló al intentar conectar con la sala...\n";
        public const string MENSAJE_CONECTAR_SALA_ALEATORIA = "5. El jugador se va a conectar a una sala aleatoria...\n";
        public const string MENSAJE_CARGAR_ESCENA = "6. El jugador va a entrar a la escena de:";
        public const string MENSAJE_INICIANDO_ESCENA_ONLINE = "7. Iniciando escena en modo Online: ";
        public const string MENSAJE_INICIANDO_ESCENA_OFFLINE = "7. Iniciando escena en modo Offline: ";
        public const string MENSAJE_INSTANCIANDO_JUGADOR = "8. Instanciado correctamente el jugador en la escena";
        public const string MENSAJE_DESCONEXION_SERVIDOR = "99. Se ha desconectado del servidor de Photon Cloud";

        public const string MENSAJE_INICO_LOGS = "Se inicia seguimiento de funcionamiento del juego";
        public const string MENSAJE_NO_ENTRAR_LOBBY = "Configuración especifica para no entrar al Lobby";
        public const string MENSAJE_SINCRONIZACION_ESCENAS = "Preparación automática de la sincronización de la escena";
        #endregion

        #region Procedimientos almacenados.
        /// <summary>
        /// Procedimiento que inserta en base de datos una nueva cuenta para un usuario.
        /// </summary>
        public const string SSPP_INSERTAR_CUENTA = "InsertarCuenta";
        /// <summary>
        /// Procedimiento que obtiene la lista de todos los paises activos.
        /// </summary>
        public const string SSPP_OBTENER_PAISES = "ObtenerPaises";
        #endregion

        #region Conexiones
        public const string CO_SE = "Server=j2l.net;";
        public const string CO_DB = "Database=is4You2;";
        public const string CO_ID = "User ID=is4YouRoot;";
        public const string CO_PA = "Password=is12345*#";
        public const string CO_IS = "Integrated Security=True";
        public const string BBDD = "is4You2";
        #endregion

        public enum Escenas
        {
            Laboratorio,
            Apartment
        }
        /// <summary>
        /// Método común para escribir por consola los mensaje de las trazas.
        /// </summary>
        /// <param name="consola"></param>
        /// <param name="traza"></param>
        public static void Traza(InputField consola, string traza) {
            consola.text = consola.text + traza + "\n";
            consola.MoveTextEnd(true);
        }
    }
}