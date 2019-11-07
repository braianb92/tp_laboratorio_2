using System;
using Clases_Instanciables;
using EntidadesAbstractas = Clases_Abstractas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;

namespace Test_Unitarios
{
    [TestClass]
    public class ExcepcionesTest
    {
        [TestMethod]
        [ExpectedException (typeof(AlumnoRepetidoException))]
        public void AlumnoRepetido()
        {
            //Arrange
            Universidad universidad = new Universidad();
            Alumno alumno1 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            Alumno alumno2 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);

            //Act
            universidad += alumno1;
            universidad += alumno2;

            //Assert handled by exception.
        }

        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void SinProfesor()
        {
            //Arrange
            Universidad universidad = new Universidad();
            Profesor profesor = new Profesor(2, "Roberto", "Juarez", "32234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino);

            //Act
            universidad += profesor;
            universidad += Universidad.EClases.Programacion;

            //Assert handled by exception.
        }
    }
}
