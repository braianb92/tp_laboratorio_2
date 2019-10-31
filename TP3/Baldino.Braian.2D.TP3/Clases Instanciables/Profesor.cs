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
        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base (id,nombre,apellido,dni,nacionalidad)
        {

            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Methods & Overrides
        private void _randomClases()
        {
            int length = Enum.GetNames(typeof(Universidad.EClases)).Length;
            int random = Profesor.random.Next(1, length);

            this.clasesDelDia.Enqueue((Universidad.EClases)random);

            random = Profesor.random.Next(1, length);
            this.clasesDelDia.Enqueue((Universidad.EClases)random);
        }

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

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operator Overloads
        public static bool operator == (Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                    return true;
            }
            return false;
        }

        public static bool operator != (Profesor i, Universidad.EClases clase)
        {
            return !(i==clase);
        }
        #endregion

    }
}
