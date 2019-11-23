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
            mockPaquetes = new List<Thread>();
        }

        public void FinEntregas()
        {
            foreach (Thread thread in mockPaquetes)
            {
                if (thread.IsAlive)
                    thread.Abort();
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            string retorno = string.Empty;
            Correo correo = (Correo)elemento;
            foreach (Paquete paquete in correo.Paquetes)
            {
                retorno += string.Format("{0} para {1} ({2})\n", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString());
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

            try
            {
                thread.Start();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al iniciar Hilo",ex);
            }
            
            return c;
        }
    }
}
