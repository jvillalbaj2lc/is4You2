using UnityEngine;
using System;

namespace Com.Afrodita.isForYou2
{
    public class Entidades : MonoBehaviour
    {
        /// <summary>
        /// Entidad que representa la cuenta del usuario.
        /// </summary>
        public struct Cuenta {
            public int IdCuenta;
            public string Nombre;
            public string Password;
            public string Email;
            public int Pais;
            public DateTime FechaNacimiento;
        }
        /// <summary>
        /// Entidad que representa los paises activos del juego.
        /// </summary>
        public struct Paises {
            public int IdPais;
            public string Pais;
        }
    }
}