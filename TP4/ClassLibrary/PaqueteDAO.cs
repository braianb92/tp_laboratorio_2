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
            bool retorno = false;
            if (paquete is null) return retorno;

            try
            {         
                    // LE PASO LA INSTRUCCION SQL
                    comando.CommandText =  String.Format($"INSERT INTO dbo.Paquetes(direccionEntrega, trackingID, alumno) VALUES('{paquete.DireccionEntrega}', '{paquete.TrackingID}', 'Braian Baldino')");
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
                {
                    conexion.Close();
                    retorno = true;
                }
                    
                
            }
            return retorno;
        }

    }
}
