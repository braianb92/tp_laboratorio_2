using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {
        #region Extension Methods
        /// <summary>
        /// Metodo de extension para el tipo "string".
        /// Toma la cadena de texto de la instancia string actual y recibe el nombre de un archivo (.txt)
        /// por parametro donde consecuentemente escribira los datos.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            if (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(texto))
            {
                try
                {
                    string desktop = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), archivo);
                    StreamWriter sw = new StreamWriter(desktop);
                    sw.WriteLine(texto);
                    sw.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return true;
        }
        #endregion
    }

}
