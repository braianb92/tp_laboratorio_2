using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region Constructores
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Dulce(EMarca marca, string patente, ConsoleColor color) : base(patente,marca,color){}
        #endregion

        #region Propiedad
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Publica todos los datos del Producto, junto los datos pertinentes a su tipo.
        /// </summary>
        /// <returns></returns>
        public override  string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("");
            sb.AppendLine($"CALORIAS : {this.CantidadCalorias}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
