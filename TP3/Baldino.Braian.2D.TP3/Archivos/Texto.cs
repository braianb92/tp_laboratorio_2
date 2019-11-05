using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<Texto>
    {
        public bool Guardar(string archivo, string datos)
        {
            throw new NotImplementedException();
        }

        public bool Leer(string archivo, out string datos)
        {
            throw new NotImplementedException();
        }
    }
}
