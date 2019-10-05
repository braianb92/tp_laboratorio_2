using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        #region Atributos
        private List<Producto> productos;
        private int espacioDisponible;
        #endregion

        #region Nested Type
        public enum ETipo
        {
            Dulce,
            Leche,
            Snacks,
            Todos
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor privado, Inicializa la lista de productos por defecto.
        /// </summary>
        /// <return></return>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <return></return>
        public Changuito(int espacioDisponible ) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Tenemos {c.productos.Count} lugares ocupados de un total de {c.espacioDisponible} disponibles");
            foreach (Producto producto in c.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if(producto is Snacks)
                            sb.AppendLine(producto.Mostrar());
                        break;
                    case ETipo.Dulce:
                        if (producto is Dulce)
                            sb.AppendLine(producto.Mostrar());
                        break;
                    case ETipo.Leche:
                        if (producto is Leche)
                            sb.AppendLine(producto.Mostrar());
                        break;
                    case ETipo.Todos:
                        sb.AppendLine(producto.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            if(c.productos.Count < c.espacioDisponible)
            {
                foreach (Producto producto in c.productos)
                {
                    if (producto == p)
                        return c;
                }

                c.productos.Add(p);
                return c;
            }
            return c;
            
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto producto in c.productos)
            {
                if (producto == p)
                {
                    c.productos.Remove(p);
                    return c;
                }
            }

            return c;
        }
        #endregion
    }
}
