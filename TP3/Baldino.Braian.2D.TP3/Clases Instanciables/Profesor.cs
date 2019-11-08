using Clases_Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributes
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor estatico que inicializa el atributo 'random'.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        public Profesor() : base () { }

        /// <summary>
        /// Constructor que recibe 5 parametros, inicializa la cola de clases y asigna clases random a la cola.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base (id,nombre,apellido,dni,nacionalidad)
        {

            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Methods & Overrides
        /// <summary>
        /// Metodo privado que asigna clases aleatorias a la cola.
        /// </summary>
        private void _randomClases()
        {
            int length = Enum.GetNames(typeof(Universidad.EClases)).Length;
            int random = Profesor.random.Next(1, length);

            this.clasesDelDia.Enqueue((Universidad.EClases)random);

            random = Profesor.random.Next(1, length);
            this.clasesDelDia.Enqueue((Universidad.EClases)random);
        }

        /// <summary>
        /// Muestra las clases del dia del profesor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clases del Dia:");
            foreach (Universidad.EClases clase in clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return sb.ToString();
            
        }

        /// <summary>
        /// Muestra los datos del profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Muestra todos los datos del profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operator Overloads
        /// <summary>
        /// Son iguales si el profesor da la clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator == (Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Son distintos si el profesor no da la clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator != (Profesor i, Universidad.EClases clase)
        {
            return !(i==clase);
        }
        #endregion

    }
}
