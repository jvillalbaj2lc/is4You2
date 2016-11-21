using UnityEngine;
using System.Data;
using System.Data.SqlClient;

namespace Com.Afrodita.isForYou2
{
    public class Datos : MonoBehaviour
    {
        /// <summary>
        /// Método que ejecuta un procedimiento y obtiene la información representada en DataSet.
        /// </summary>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string dataBase, string procedimiento, SqlParameter[] parametros)
        {
            string connectionString = Commons.CO_SE + Commons.CO_DB + Commons.CO_ID + Commons.CO_PA;
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(procedimiento, conn);
                foreach (SqlParameter parametro in parametros)
                    command.Parameters.Add(parametro);

                conn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
                conn.Close();
            }
            return ds;
        }
        /// <summary>
        /// Método sobre escrito que ejecuta un procedimiento y obtiene la información representada en DataSet.
        /// </summary>
        /// <param name="dataBase"></param>
        /// <param name="procedimiento"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string dataBase, string procedimiento)
        {
            string connectionString = Commons.CO_SE + Commons.CO_DB + Commons.CO_ID + Commons.CO_PA;
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(procedimiento, conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
                conn.Close();
            }
            return ds;
        }
        /// <summary>
        /// Método que ejecuta un procedimiento almacenado sin devolver registro.
        /// </summary>
        /// <returns></returns>
        public static DataSet ExecuteDataSetNonQuery(string dataBase, string procedimiento, SqlParameter[] parametros)
        {

            string connectionString = Commons.CO_SE + Commons.CO_DB + Commons.CO_ID + Commons.CO_PA;
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(procedimiento, conn);
                foreach (SqlParameter parametro in parametros)
                    command.Parameters.Add(parametro);

                conn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                conn.Close();
            }
            return ds;
        }
    }
}