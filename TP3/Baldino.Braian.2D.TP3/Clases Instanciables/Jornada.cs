using Archivos;
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
        /// <summary>
        /// Constructor privado que inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor que toma 3 parametros e inicializa la lista de alumnos.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            Clase = clase;
            Instructor = instructor;
        }
        #endregion

        #region Operator Overloads
        /// <summary>
        /// Jornada y alumno seran iguales si el alumno participa de ella.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator == (Jornada j, Alumno a)
        {
            if (a == j.Clase)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Jornada y alumno seran distintos si el alumno no participa de la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator != (Jornada j, Alumno a)
        {
            return !(j==a);
        }

        /// <summary>
        /// Añade un alumno a la jornada si es que el alumno no aprticipa de ella.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator + (Jornada j, Alumno a)
        {
            if(j != a)
                j.Alumnos.Add(a);

            return j;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Muestra todos los datos de la jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();           
            sb.AppendLine($"CLASE DE {Clase.ToString()} POR NOMBRE COMPLETO: {Instructor}");
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno alumno in Alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }
            
            return sb.ToString();
        }

        /// <summary>
        /// Guarda la jornada en un archivo de texto alojado en el desktop.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            return txt.Guardar("jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Lee un archivo de texto con la informacion de la jornada.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string aux = "";
            Texto txt = new Texto();
            txt.Leer("jornada.txt", out aux);
            return aux;
        }
        #endregion
    }
}
