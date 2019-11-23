using System;
using System.Collections.Generic;
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

        #region Tests No Requeridos - USO PERSONAL
        //NO REQUERIDO POR TP4 - TESTEO PERSONAL
        [TestMethod]
        public void GuardaStringExtension()
        {
            Correo correo = new Correo();

            Paquete paquete1 = new Paquete("Bs As", "20/001");
            paquete1.Estado = Paquete.EEstado.EnViaje;

            Paquete paquete2 = new Paquete("Jujuy", "20/002");
            paquete2.Estado = Paquete.EEstado.Ingresado;

            Paquete paquete3 = new Paquete("Brasil", "20/003");
            paquete3.Estado = Paquete.EEstado.Entregado;

            correo += paquete1;
            correo += paquete2;
            correo += paquete3;

            Assert.IsTrue(GuardaString.Guardar(correo.MostrarDatos(correo),"correo.txt"));

        }

        //NO REQUERIDO POR TP4 - TESTEO PERSONAL
        [TestMethod]
        public void PaqueteDAO_Insertar()
        {          
            Paquete paquete = new Paquete("Bs As", "20/001");

            Assert.IsTrue(PaqueteDAO.Insertar(paquete));
        }
        #endregion
    }
}
