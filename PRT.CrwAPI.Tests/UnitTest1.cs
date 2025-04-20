using PRT.CrwAPI.Controllers;
using Moq; // Add this using directive at the top of the file to resolve the 'Mock<>' type.
using PRT.CrwAPI.Models;
using PRT.CrwAPI.Repositories.Interfaces;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRT.CrwAPI.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Producto_Model_Validation()
        {
            // Arrange
            var producto = new Producto
            {
                Id = 1,
                Nombre = "Producto de Prueba",
                Precio = 100.50m,
                Estado = true
            };

            // Act & Assert
            Assert.NotNull(producto);
            Assert.Equal("Producto de Prueba", producto.Nombre);
            Assert.Equal(100.50m, producto.Precio);
            Assert.True(producto.Estado);
        }

        [Fact]
        public async Task ProductosController_GetById_ReturnsProducto()
        {
            // Arrange
            var mockRepo = new Mock<IProductoRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(1))
                    .ReturnsAsync(new Producto { Id = 1, Nombre = "Producto de Prueba" });

            var controller = new ProductosController(mockRepo.Object);

            // Act
            var result = await controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var producto = Assert.IsType<Producto>(okResult.Value);
            Assert.Equal(1, producto.Id);
            Assert.Equal("Producto de Prueba", producto.Nombre);
        }
    }
}