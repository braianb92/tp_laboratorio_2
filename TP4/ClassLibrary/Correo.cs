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
        #region Atributes
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Properties
        public List<Paquete> Paquetes
        {
            get { return paquetes; }
            set { paquetes = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor que inicializa las listas.
        /// </summary>
        public Correo()
        {
            paquetes = new List<Paquete>();
            mockPaquetes = new List<Thread>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Recorre la lista de threads y finaliza los que esten activos.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread thread in mockPaquetes)
            {
                if (thread.IsAlive)
                    thread.Abort();
            }
        }

        /// <summary>
        /// Metodo implementado de la interfaz "IMostrar<T>."
        /// Recorre la lista de paquetes y devuelve toda su informacion.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
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
        #endregion

        #region Operator Overloads
        /// <summary>
        /// Añade un paquete al correo solo si este no se encuentra en ella.
        /// Una vez agregado, inicia un hilo con el metodo "MockCicloDeVida".
        /// Tamien añade este hilo a la lista de hilos de la instancia actual del correo.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
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
        #endregion
    }
}
