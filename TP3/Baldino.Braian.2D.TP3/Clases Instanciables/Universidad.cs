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
        public bool Guardar(Universidad uni)
        {
            return true;
        }

        public Universidad Leer()
        {
            return this;
        }

        private string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Alumno a in Alumnos)
            {
                sb.AppendLine(a.ToString());
            }

            foreach (Profesor p in Profesores)
            {
                sb.AppendLine(p.ToString());
            }

            foreach (Jornada j in Jornadas)
            {
                sb.AppendLine(j.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }
        #endregion

        #region Operator Overloads
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor p)
        {
            foreach (Jornada jornada in g.Jornadas)
            {
                if (p == jornada.Instructor)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Profesores)
            {
                if (profesor == clase)
                    return profesor;
            }

            throw new SinProfesorException();

        }

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

        public static Universidad operator + (Universidad u, Alumno a)
        {
           if(u!=a)
           {
                u.Alumnos.Add(a);
                return u;
           }

            throw new AlumnoRepetidoException();

        }

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
