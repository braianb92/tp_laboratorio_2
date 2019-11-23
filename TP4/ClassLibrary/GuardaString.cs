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
    }

}
