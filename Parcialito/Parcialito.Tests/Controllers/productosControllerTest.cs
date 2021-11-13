using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Parcialito.Controllers;
using Parcialito.Models;

namespace Parcialito.Tests.Controllers
{
    [TestClass]
    public class productosControllerTest
    {
        [TestMethod]
        public void NoAgregarNombreProductoVacio()
        {
            //Arrange
            productosController controller = new productosController();

            var Producto = new producto()
            {
                nombreProducto = "",
                precio = 12,
                stock = 2

            };

            //Act
            var result = controller.Agregar(Producto);
            //Assert
            Assert.AreEqual(6, result);
        }


        [TestMethod]
        public void NoAgregarNombreRepetido()
        {
            //Arrange
            productosController controller = new productosController();

            var Producto = new producto()
            {
                nombreProducto = "Pan",
                precio = 12,
                stock = 2

            };

            //Act
            var result = controller.Agregar(Producto);
            //Assert
            Assert.AreEqual(1, result);
        }


    }
}
