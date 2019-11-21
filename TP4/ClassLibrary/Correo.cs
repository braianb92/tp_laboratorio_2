using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get { return paquetes; }
            set { paquetes = value; }
        }

        public Correo()
        {
            paquetes = new List<Paquete>();
        }

        public void FinEntregas()
        {
            foreach (Thread thread in mockPaquetes)
            {
                if (thread.IsAlive)
                    thread.Abort();
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string retorno = string.Empty;
            List<Paquete> paquetes = (List<Paquete>)elementos;
            foreach (Paquete paquete in paquetes)
            {
                retorno += string.Format("{0} para {1} ({2})", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString());
            }

            return retorno;
        }

        public static Correo operator + (Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if (paquete == p)
                    throw new TrackingIdRepetidoException("El paquete ya se encuentra en la lista");
            }
            c.Paquetes.Add(p);

            Thread thread = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(thread);
            thread.Start();

            return c;
        }
    }
}
