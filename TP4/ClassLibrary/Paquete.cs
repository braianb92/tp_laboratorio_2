using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Delegates
        public delegate void DelegadoEstado(object sender,EventArgs args);
        #endregion

        #region Nested Enum
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion

        #region Atributes
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region Events
        public event DelegadoEstado InformaEstado;
        #endregion

        #region Properties
        public string DireccionEntrega
        {
            get { return direccionEntrega; }
            set { direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string TrackingID
        {
            get { return trackingID; }
            set { trackingID = value; }
        }
        #endregion

        #region Constructors
        public Paquete() { }

        /// <summary>
        /// Constructor que recibe dos parametros e inicializa por defecto el estado en "Ingresado".
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega,string trackingID)
        {        
            this.estado = EEstado.Ingresado;
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Devuelve en string.format el trackingID y la direccion de entrega.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete paquete = (Paquete)elemento;
            return string.Format("{0} para {1}", paquete.TrackingID, paquete.DireccionEntrega);
        }

        /// <summary>
        /// Cambia el estado de entrega de los paquetes cada 4 segundos.
        /// Utiliza evento. Al llegar al estado de "Entregado", el paquete
        /// se guarda en la base de datos.
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(4000);
                this.estado++;
                this.InformaEstado.Invoke(this, new EventArgs());

            } while (this.Estado != EEstado.Entregado);

            PaqueteDAO.Insertar(this);
           
        }
        

        /// <summary>
        /// Devuelve los datos del paquete.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        #endregion

        #region Operator Overloads
        /// <summary>
        /// Los paquetes seran iguales si y solo si sus trackingID son iguales.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator == (Paquete p1,Paquete p2)
        {
            return (p1.trackingID == p2.trackingID);
        }

        /// <summary>
        /// Seran distintos si y solo si sus trackingID son distintos.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1==p2);
        }
        #endregion
    }
}
