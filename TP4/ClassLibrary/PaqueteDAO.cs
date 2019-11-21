using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static PaqueteDAO()
        {
            // CREO UN OBJETO SQLCONECTION
            conexion = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True");
            // CREO UN OBJETO SQLCOMMAND
            comando = new SqlCommand();
            // INDICO EL TIPO DE COMANDO
            comando.CommandType = System.Data.CommandType.Text;
            // ESTABLEZCO LA CONEXION
            comando.Connection = conexion;
        }

        public static bool Insertar(Paquete paquete)
        {
            string sql = "INSERT INTO " + "Paquetes" + " (direccionEntrega,trackingID,alumno) ";

            sql = sql + "SELECT '" + paquete.DireccionEntrega + "','" + paquete.TrackingID + "','" + "Baldino Braian" + "' UNION ALL' ";

            try
            {
                sql = sql.Substring(0, sql.Length - 11);
                // LE PASO LA INSTRUCCION SQL
                comando.CommandText = sql;
                // ABRO LA CONEXION A LA BD
                conexion.Open();
                // EJECUTO EL COMMAND
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                
            }
            return true;
        }

    }
}
