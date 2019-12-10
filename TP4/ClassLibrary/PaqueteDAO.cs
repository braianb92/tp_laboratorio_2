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
        #region Atributes
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Static Constructor
        /// <summary>
        /// Crea la conexion a la base de datos ya preestablecida y establece el tipo de comando (text).
        /// </summary>
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
        #endregion

        #region Methods
        /// <summary>
        /// Guarda los datos en la base de datos.
        /// </summary>
        /// <param name="paquete"></param>
        /// <returns></returns>
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

        public static bool Modificar(Paquete paquete, string direccion)
        {
            bool retorno = false;

            if (paquete is null) return retorno;

            try
            {
                comando.CommandText = String.Format($"UPDATE dbo.Paquetes SET direccionEntrega = '{direccion}' WHERE trackingID = '{paquete.TrackingID}'");
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Error en base de datos", ex);
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

        public static bool Eliminar(string trackingID)
        {
            bool retorno = false;

            if (string.IsNullOrEmpty(trackingID)) return retorno;

            try
            {
                comando.CommandText = String.Format($"DELETE FROM dbo.Paquetes WHERE trackingID = '{trackingID}'");
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Error en base de datos", ex);
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
        #endregion

    }
}
