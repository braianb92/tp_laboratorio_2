using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool aux = false;
            if (!string.IsNullOrEmpty(archivo) && datos != null)
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                try
                {
                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    StreamWriter sw = new StreamWriter(Path.Combine(desktop, archivo));
                    xs.Serialize(sw, datos);
                    aux = true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
            return aux;

        }

        public bool Leer(string archivo, out T datos)
        {
            bool aux = false;
            datos = default(T);
            if (!string.IsNullOrEmpty(archivo) && datos != null)
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                try
                {
                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    StreamReader sr = new StreamReader(Path.Combine(desktop, archivo));
                    datos = (T)xs.Deserialize(sr);
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
