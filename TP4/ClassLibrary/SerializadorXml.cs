using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ClassLibrary
{
    public static class SerializadorXml<T> where T: class, new ()
    {
        public static bool GuardarXml(string fileName, T datos)
        {
            if (!string.IsNullOrEmpty(fileName) && datos != null)
            {
                try
                {
                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    XmlTextWriter xmlWriter = new XmlTextWriter(Path.Combine(desktop + "/" + fileName), Encoding.UTF8);
                    XmlSerializer serializer = new XmlSerializer(typeof(T));

                    serializer.Serialize(xmlWriter, datos);
                    xmlWriter.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception("Error en serializacion", e);
                }
            }
            return false;
        }

        public static bool LeerXml(string archivo, out T datos)
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
                    throw new Exception("Error en serializacion", e);
                }
            }
            return false;
        }
    }
}
