using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using Xunit;
using AppVenta.Dominio.Modelos;
using Moq;
using AppVenta.Dominio.interfaces.Repositorios;
using AppVenta.Applicaciones.Servicios;

namespace Aplicacion.Test
{
    public class VentaServicioTests
    {
        [Fact]
        public void ValidacionConVentaDetalle_VentaConExito()
        {
            // Arrange .
            var venta = new VentaModel
            {
                ventaId = 1,
                VentaDetalles = new List<VentaDetalleModel>
                {
                    new VentaDetalleModel
                    {
                        productoId = 1,
                        cantidadVendida = 5,
                    }
                }
            };

            //Crear instancias de repositorios base con los mocks
            var repoProductoMock = new Mock<IRepositorioBase<ProductoModel, int>>();
            var repoVentaMock = new Mock<IRepositorioMovimiento<VentaModel, int>>();
            var repoDetalleMock = new Mock<IRepositorioDetalle<VentaDetalleModel, int>>();

            //Crear repositorios a consultar con los mocks
            repoProductoMock.Setup(repo => repo.SeleccionarPorId(It.IsAny<int>()))
            .Returns((int productoId) =>
            {
                return new ProductoModel
                {
                    productoId = productoId,
                    cantidadEnStock = 10
                };
            });
            repoDetalleMock.Setup(repo => repo.Agregar(It.IsAny<VentaDetalleModel>()));
            repoVentaMock.Setup(repo => repo.Agregar(It.IsAny<VentaModel>()))
                .Returns((VentaModel v) =>
                {

                    return new VentaModel
                    {
                        ventaId = v.ventaId,
                    };
                });
            repoVentaMock.Setup(repo => repo.GuardarTodosLosCambios());

            // Crear una instancia de VentaService con los mocks
            var ventaService = new VentaServicio(repoVentaMock.Object, repoProductoMock.Object, repoDetalleMock.Object);

            // Act
            var resultado = ventaService.Agregar(venta);

            // Assert.

            // Verificar que el resultado sea igual al objeto venta recibido
            Assert.Equal(venta, resultado);

            // Verificar que se haya llamado al método Agregar del repositorio de detalle de venta
            repoDetalleMock.Verify(repo => repo.Agregar(It.IsAny<VentaDetalleModel>()), Times.Once);

            // Verificar que se haya llamado al método Agregar del repositorio de venta
            repoVentaMock.Verify(repo => repo.Agregar(It.IsAny<VentaModel>()), Times.Once);

            // Verificar que se haya llamado al método GuardarTodosLosCambios del repositorio de venta
            repoVentaMock.Verify(repo => repo.GuardarTodosLosCambios(), Times.Once);

        }
    }
}