using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            if (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(texto))
            {
                try
                {
                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    StreamWriter sw = new StreamWriter(Path.Combine(desktop, archivo));
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
