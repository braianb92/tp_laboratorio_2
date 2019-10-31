using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        #region Enum Nested Type
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Atributes
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
        #endregion

        #region Constructors
        public Persona (string nombre,string apellido,ENacionalidad nacionalidad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {         
            DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad)
        {           
            StringToDni = dni;
        }
        #endregion

        #region Properties
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = ValidarNombreApellido(value); }
        }

        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = ValidarNombreApellido(value); ; }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        public int DNI
        {
            get { return this.dni; }
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        public string StringToDni
        {
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Private Methods (Validations)
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                    {
                        dato = 0;
                        throw new NacionalidadInvalidaException("DNI no valido para Argentina");
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000 || dato > 99999999)
                    {
                        dato = 0;
                        throw new NacionalidadInvalidaException("DNI no valido para Extranjero");
                    }
                    break;
            }
            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (!string.IsNullOrEmpty(dato) && int.TryParse(dato, out int datoInt))
            {
                return ValidarDni(nacionalidad, datoInt);
            }
            else
            {
                throw new DniInvalidoException();
            }
        }

        private string ValidarNombreApellido(string dato)
        {
            if (!string.IsNullOrEmpty(dato) && !string.IsNullOrWhiteSpace(dato))
                return dato;
            else
                return "Unknown";
        }
        #endregion

        #region Override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Nombre);
            sb.AppendLine(Apellido);
            sb.AppendLine(DNI.ToString());
            sb.AppendLine(Nacionalidad.ToString());
            return sb.ToString();
        }
        #endregion

    }
}
