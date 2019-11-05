using Clases_Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region Enum Nested Type
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion

        #region Atributes
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructors
        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma
            ,EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Opearator Overloads
        public static bool operator == (Alumno a,Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            else
                return false;
        }

        public static bool operator != (Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma != clase)
                return true;
            else
                return false;
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"ESTADO DE CUENTA: {estadoCuenta}");
            sb.AppendLine($"TOMA CLASES DE {claseQueToma}");
            sb.AppendLine("<------------------------------>");
            return sb.ToString();
        }
        #endregion

        #region Methods
        protected override string ParticiparEnClase()
        {
            return $"Toma Clase de {claseQueToma}";
        }

        protected override string MostrarDatos()
        {
            return this.ToString();
        }
        #endregion
    }
}
