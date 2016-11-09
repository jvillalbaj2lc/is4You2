﻿using UnityEngine;
using UnityEngine.UI;

namespace Com.Afrodita.isForYou2
{
    public class Commons : MonoBehaviour
    {
        public const string MENSAJE_CONECTANDO_SERVIDOR = "1. Conectando con el servidor, por favor espere...\n";
        public const string MENSAJE_CONEXION_YA_ESTABLECIDA = "2. La aplicación ya estaba conectada al servidor de Photon Cloud...\n";
        public const string MENSAJE_CONEXION_SERVIDOR_CONFIGURACION = "2.2 Se ha conectado correctamente la conexión mediante configuración al servidor Photon Cloud...\n";
        public const string MENSAJE_CONEXION_SERVIDOR_MAESTRO = "3. Se ha realizado la conexión al Servidor Maestro...\n";
        public const string MENSAJE_CONEXION_SALA = "4. El jugador ha entrado en una sala del servidor...\n";
        public const string MENSAJE_CONECTAR_SALA_ALEATORIA = "5. El jugador se va a conectar a una sala aleatoria...\n";
        public const string MENSAJE_CARGAR_ESCENA = "6. El jugador va a entrar a la escena de:";
        public const string MENSAJE_DESCONEXION_SERVIDOR = "99. Se ha desconectado del servidor de Photon Cloud...\n";
        public const string MENSAJE_INICO_LOGS = "Se inicia seguimiento de funcionamiento del juego...\n";
        public const string MENSAJE_NO_ENTRAR_LOBBY = "Configuración especifica para no entrar al Lobby...\n";
        public const string MENSAJE_SINCRONIZACION_ESCENAS = "Preparación automática de la sincronización de la escena...\n";

        /// <summary>
        /// Método común para escribir por consola los mensaje de las trazas.
        /// </summary>
        /// <param name="consola"></param>
        /// <param name="traza"></param>
        public static void Traza(InputField consola, string traza) {
            consola.text = consola.text + traza;
        }
    }
}