using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda todos los datos que se le pasen como parametro en un archivo en el escritorio con el nombre que recibe como parametro
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="datos">Info que contiene el archivo</param>
        /// <returns>true si lo pudo crear, false si no pudo</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool aux = false;
            if (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(datos))
            {
                try
                {
                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    StreamWriter sw = new StreamWriter(Path.Combine(desktop, archivo));
                    sw.WriteLine(datos);
                    sw.Close();
                    aux = true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }

            return aux;
        }

        /// <summary>
        /// Lee todos los datos dentro del archivo que se le pase y lo pega en el puntero a string que recibe como parametro
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="datos">Donde se guarda la informacion del archivo</param>
        /// <returns>Devuelve la info del archivo o vacio si no pudo</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool aux = false;
            datos = "";
            if (!string.IsNullOrEmpty(archivo))
            {
                try
                {
                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    StreamReader sw = new StreamReader(Path.Combine(desktop, archivo));
                    datos = sw.ReadToEnd();
                    sw.Close();
                    aux = true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
            return aux;
        }


    }
}
