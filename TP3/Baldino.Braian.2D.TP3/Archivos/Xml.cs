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
            if (!string.IsNullOrEmpty(archivo) && datos != null)
            {
                try
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    XmlTextWriter xmlWriter = new XmlTextWriter(path + "/" + archivo, Encoding.ASCII);
                    XmlSerializer serializer = new XmlSerializer(typeof(T));

                    serializer.Serialize(xmlWriter, datos);
                    xmlWriter.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
            return false;
        }

        public bool Leer(string archivo, out T datos)
        {          
            datos = default(T);
            if (!string.IsNullOrEmpty(archivo) && datos != null)
            {
                try
                {
                    string file = string.Empty;
                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    foreach (string item in Directory.GetFiles(desktop))
                    {
                        if (item == archivo)
                            file = item;
                    } 

                    XmlTextReader xmlReader = new XmlTextReader(file);
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    datos = (T)serializer.Deserialize(xmlReader);
                    xmlReader.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
            return false;
        }
    }
}
