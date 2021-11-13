using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Parcialito.Controllers;
using Parcialito.Models;

namespace Parcialito.Tests.Controllers
{
    [TestClass]
    public class clienteControllerTest
    {
        [TestMethod]
        public void NoAgregarclienteVacio()
        {
            //Arrange
            clientesController controller = new clientesController();

            var Cliente = new cliente()
            {
                nombreCliente =""
               
            };

            //Act
            var result = controller.Agregar(Cliente);
            //Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void NoAgregarNombreconNumero()
        {
            //Arrange
            clientesController controller = new clientesController();

            var Cliente = new cliente()
            {
                nombreCliente = "Sergio12",
                telefono = "7198-8531",
             
                edad = 22,
                DUI = "1234567-8"

            };

            //Act
            var result = controller.Agregar(Cliente);
            //Assert
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void NoAgregarTelefonoCorrecto()
        {
            //Arrange
            clientesController controller = new clientesController();

            var Cliente = new cliente()
            {
                nombreCliente = "Sergio",
                telefono = "71988531",

                edad = 22,
                DUI = "1234567-8"

            };

            //Act
            var result = controller.Agregar(Cliente);
            //Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void NoAgregarDUICorrecto()
        {
            //Arrange
            clientesController controller = new clientesController();

            var Cliente = new cliente()
            {
                nombreCliente = "Sergio",
                telefono = "7198-8531",

                edad = 22,
                DUI = "12345678"

            };

            //Act
            var result = controller.Agregar(Cliente);
            //Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void NoAgregarEdadCorrecta()
        {
            //Arrange
            clientesController controller = new clientesController();

            var Cliente = new cliente()
            {
                nombreCliente = "Sergio",
                telefono = "7198-8531",

                edad = 15,
                DUI = "1234567-8"

            };

            //Act
            var result = controller.Agregar(Cliente);
            //Assert
            Assert.AreEqual(5, result);
        }
    }
}
