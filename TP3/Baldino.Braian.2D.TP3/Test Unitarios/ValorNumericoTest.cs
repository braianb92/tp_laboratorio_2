using Clases_Instanciables;
using Clases_Abstractas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Unitarios
{
    [TestClass]
    public class ValorNumericoTest
    {
        [TestMethod]
        public void ValidarNumero()
        {
            //Arrange
            Alumno alumno1 = new Alumno(1, "Juan", "Lopez", "12234456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);

            //Assert
            Assert.IsInstanceOfType(alumno1.DNI, typeof(int));
            Assert.IsNotInstanceOfType(alumno1.DNI, typeof(string));
        }
    }
}
