using UnityEngine;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Com.Afrodita.isForYou2
{
    public class Cuenta : MonoBehaviour
    {
        /// <summary>
        /// Método que inserta una cuenta nueva del usuario en el juego.
        /// </summary>
        /// <param name="cuenta"></param>
        public static void InsertarCuenta(Entidades.Cuenta cuenta)
        {
            SqlParameter[] parametros = new SqlParameter[5];

            parametros[0] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            parametros[0].Value = cuenta.Nombre;

            parametros[1] = new SqlParameter("@password", SqlDbType.NVarChar);
            parametros[1].Value = cuenta.Password;

            parametros[2] = new SqlParameter("@email", SqlDbType.NVarChar);
            parametros[2].Value = cuenta.Email;

            parametros[3] = new SqlParameter("@pais", SqlDbType.Int);
            parametros[3].Value = cuenta.Pais;

            parametros[4] = new SqlParameter("@fechaNacimiento", SqlDbType.DateTime);
            parametros[4].Value = cuenta.FechaNacimiento;

            Datos.ExecuteDataSetNonQuery(Commons.BBDD, Commons.SSPP_INSERTAR_CUENTA, parametros);
        }

        /// <summary>
        /// Método que devuelve la lista de paises activos del juego.
        /// </summary>
        /// <returns></returns>
        public static List<Entidades.Paises> ObtenerPaises()
        {
            List<Entidades.Paises> paises = new List<Entidades.Paises>();
            DataSet dsPaises = new DataSet();

            dsPaises = Datos.ExecuteDataSet(Commons.BBDD, Commons.SSPP_OBTENER_PAISES);
            if (dsPaises.Tables.Count > 0 && dsPaises.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow registro in dsPaises.Tables[0].Rows)
                {
                    Entidades.Paises pais = new Entidades.Paises();
                    pais.IdPais = Convert.ToInt32(registro["ID_PAIS"].ToString());
                    pais.Pais = registro["PAIS"].ToString();
                    paises.Add(pais);
                }
            }
            return paises;
        }
    }
}