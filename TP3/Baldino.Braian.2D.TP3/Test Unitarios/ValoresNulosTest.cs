using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Clases_Instanciables;
using Clases_Abstractas;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Unitarios
{
    [TestClass]
    public class ValoresNulosTest
    {
        [TestMethod]
        public void ValoresNoNulos()
        {
            //Arrange           
            Alumno alumnoNoNull = new Alumno(1, "Juan", "Lopez", "12234456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,Alumno.EEstadoCuenta.Becado);

            //Assert
            Assert.IsNotNull(alumnoNoNull.Nombre);
            Assert.IsNotNull(alumnoNoNull.Apellido);
            Assert.IsNotNull(alumnoNoNull.DNI);
            Assert.IsNotNull(alumnoNoNull.Nacionalidad);
        }
    }
}
