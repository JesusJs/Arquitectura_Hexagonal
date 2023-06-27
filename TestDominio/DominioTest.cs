using System;
using System.Collections.Generic;
using Xunit;
using AppVenta.Dominio.Modelos;

namespace Dominio.Tests
{
    public class VentaTests
    {
        [Fact]
        public void AsignarDatosVentas_ValidacionExitosa()
        {
            // Arange.
            int ventaId = 1;
            long numeroVenta = 1;
            DateTime dateTime = DateTime.Now;
            string concepto = "Hola mundo";
            decimal subtotal1 = 1;
            decimal impuesto = 1;
            decimal total = 1;
            bool anulado = false;
            List<VentaDetalleModel> ventaDetalle = new List<VentaDetalleModel>();
         
            // Act.
            VentaModel venta = new VentaModel()
            {
                ventaId = ventaId,
                numeroVenta = numeroVenta,
                fecha = dateTime,
                concepto = concepto,
                subtotal1 = subtotal1,
                impuesto = impuesto,
                total = total,
                anulado = anulado,
                VentaDetalles = ventaDetalle
            };

            // Assert.
            Assert.Equal(ventaId, venta.ventaId);
            Assert.Equal(numeroVenta, venta.numeroVenta);
            Assert.Equal(dateTime, venta.fecha);
            Assert.Equal(concepto, venta.concepto);
            Assert.Equal(subtotal1, venta.subtotal1);
            Assert.Equal(impuesto, venta.impuesto);
            Assert.Equal(total, venta.total);
            Assert.Equal(anulado, venta.anulado);
            Assert.Equal(ventaDetalle, venta.VentaDetalles);
        }
    }
    public class VentaDetalleTests
    {
        [Fact]
        public void AsignarDatosVentaDetalle_ValidacionExitosa()
        {
            // Arange.
            int productoId = 1;
            int ventaId = 1;
            decimal costoUnitario = 2;
            decimal precioUnitario = 1;
            decimal cantidadVendida = 1;
            decimal subtotal = 1;
            decimal impuesto = 1;
            decimal total = 1;

            // Act.
            VentaDetalleModel venta = new VentaDetalleModel()
            {
                productoId = productoId,
                ventaId = ventaId,
                costoUnitario = costoUnitario,
                precioUnitario = precioUnitario,
                cantidadVendida = cantidadVendida,
                subtotal = subtotal,
                impuesto = impuesto,
                total = total,
            };

            // Assert.
            Assert.Equal(productoId, venta.productoId);
            Assert.Equal(ventaId, venta.ventaId);
            Assert.Equal(costoUnitario, venta.costoUnitario);
            Assert.Equal(precioUnitario, venta.precioUnitario);
            Assert.Equal(cantidadVendida, venta.cantidadVendida);
            Assert.Equal(impuesto, venta.impuesto);
            Assert.Equal(subtotal, venta.subtotal);
            Assert.Equal(total, venta.total);
        }
    }
    public class ProductoTests
    {
        [Fact]
        public void AsignarDatosProducto_ValidacionExitosa()
        {
            // Arange.
            int productoId = 1;
            string nombre = "Jesus";
            string descripcion = "Hola Mundo";
            decimal costo = 1;
            decimal precio = 1;
            decimal cantidadEnStock = 1;
            List<VentaDetalleModel> ventaDetalle = new List<VentaDetalleModel>();

            // Act.
            ProductoModel venta = new ProductoModel()
            {
                productoId = productoId,
                nombre = nombre,
                descripcion = descripcion,
                costo = costo,
                precio = precio,
                cantidadEnStock = cantidadEnStock,
                VentaDetalles = ventaDetalle,
            };

            // Assert.
            Assert.Equal(productoId, venta.productoId);
            Assert.Equal(nombre, venta.nombre);
            Assert.Equal(descripcion, venta.descripcion);
            Assert.Equal(costo, venta.costo);
            Assert.Equal(precio, venta.precio);
            Assert.Equal(cantidadEnStock, venta.cantidadEnStock);
            Assert.Equal(ventaDetalle, venta.VentaDetalles);
        }
    }
}
