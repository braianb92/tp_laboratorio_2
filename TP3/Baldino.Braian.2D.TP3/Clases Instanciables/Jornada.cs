using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributes
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Properties
        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return clase; }
            set { clase = value; }
        }

        public Profesor Instructor
        {
            get { return instructor; }
            set { instructor = value; }
        }
        #endregion

        #region Constructors
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            Clase = clase;
            Instructor = instructor;
        }
        #endregion

        #region Operator Overloads
        public static bool operator == (Jornada j, Alumno a)
        {
            if (a == j.Clase)
                return true;
            else
                return false;
        }

        public static bool operator != (Jornada j, Alumno a)
        {
            return !(j==a);
        }

        public static Jornada operator + (Jornada j, Alumno a)
        {
            if(j != a)
                j.Alumnos.Add(a);

            return j;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();           
            sb.AppendLine($"CLASE DE {Clase.ToString()} POR NOMBRE COMPLETO: {Instructor}");
            sb.AppendLine("");
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno alumno in Alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }
            
            return sb.ToString();
        }

        public bool Guardar(Jornada jornada)
        {
            return true;
        }

        public string Leer()
        {
            return "";
        }
        #endregion
    }
}
