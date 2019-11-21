using System;
using ClassLibrary;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Unitarios
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void ListaPaquetesDeCorreoInstanciada()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException (typeof(TrackingIdRepetidoException))]
        public void MismoPaquete()
        {
            Correo correo = new Correo();
            Paquete paquete1 = new Paquete("Bs As", "20/001");
            Paquete paquete2 = new Paquete("Jujuy", "20/001");

            correo.Paquetes.Add(paquete1);
            correo += paquete2;

        }
    }
}
