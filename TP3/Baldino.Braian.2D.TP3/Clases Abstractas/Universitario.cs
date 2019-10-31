using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributes
        private int legajo;
        #endregion

        #region Constructors
        public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad)
            : base (nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Operator Overloads
        public static bool operator == (Universitario pg1,Universitario pg2)
        {
            if (pg1.Equals(pg2) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
                return true;
            else
                return false;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        #endregion

        #region Methods
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"{this.legajo}");
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();
        #endregion
    }
}
