using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region Enum Nested Type
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Atributes
        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornadas;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor por defecto que inicializa la lista de profesores, alumnos y jornadas.
        /// </summary>
        public Universidad()
        {
            Alumnos = new List<Alumno>();
            Profesores = new List<Profesor>();
            Jornadas = new List<Jornada>();
        }
        #endregion

        #region Properties
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { alumnos = value; }
        }

        public List<Profesor> Profesores
        {
            get { return this.profesores; }
            set { profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornadas; }
            set { jornadas = value; }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornadas[i];
            }
            set
            {
                this.jornadas[i] = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Metedodo estatico que guarda los datos de una universidad en un archivo XML.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            try
            {
                if (xml.Guardar("Universidad.xml", uni))
                    return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return false;
        }

        /// <summary>
        /// Metodo estatico que lee los datos de una universidad desde un archivo XML.
        /// </summary>
        /// <returns></returns>
        public static bool Leer()
        {
            Universidad aux;
            Xml<Universidad> xml = new Xml<Universidad>();
            try
            {
                if (xml.Leer("Universidad.xml", out aux))
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return false;
        }

        /// <summary>
        /// Muestra los datos de las Jornadas
        /// </summary>
        /// <returns></returns>
        private string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            foreach (Jornada j in Jornadas)
            {
                sb.AppendLine(j.ToString());
                sb.AppendLine("<---------------------------->:");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Muestra los datos de la universidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
        #endregion

        #region Operator Overloads
        /// <summary>
        /// Universidad y alumno seran iguales cuando el alumno este incripto en el listado de la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.Alumnos)
            {
                if (item.DNI == a.DNI)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Alumno no esta inscripto en el listado de la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Universidad es igual a profesor cuando el profesor participe de alguna jornada.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor p)
        {
            foreach (Jornada jornada in g.Jornadas)
            {
                if (p == jornada.Instructor)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// El profesor no participa de ninguna jornada.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }

        /// <summary>
        /// Devuelve el primer profesor capaz de dar la clase pasada por parametro.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Profesores)
            {
                if (profesor == clase)
                    return profesor;
            }

            throw new SinProfesorException();

        }

        /// <summary>
        /// Devuelve el primer profesor que no puede dar la clase pasada por parametro.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesor = null;

            foreach (Profesor p in u.Profesores)
            {
                if (p != clase)
                    return p;
            }

            return profesor;
        }

        /// <summary>
        /// Agrega una jornada a la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator + (Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, (g == clase));

            foreach (Alumno alumno in g.Alumnos)
            {
                if(alumno == clase)
                    jornada.Alumnos.Add(alumno);
            }

            g.Jornadas.Add(jornada);
            return g;
        }

        /// <summary>
        /// Agrega un alumno al listado siempre y cuando este no este inscripto. Si esta inscripto lanza una excepcion.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator + (Universidad u, Alumno a)
        {
           if(u!=a)
           {
                u.Alumnos.Add(a);
                return u;
           }

            throw new AlumnoRepetidoException();

        }

        /// <summary>
        /// Agrega un profesor al listado de la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator + (Universidad u,Profesor i)
        {
            foreach (Profesor profesor in u.Profesores)
            {
                if (profesor == i)
                    return u;
            }
            u.Profesores.Add(i);
            return u;
        }
        #endregion

    }

}
