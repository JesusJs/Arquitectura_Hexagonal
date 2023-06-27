//Importar las entidades de Dominio e Interfaces de repositorios.
using AppVenta.Dominio.interfaces.Repositorios;
using AppVenta.Applicaciones.Interfaces;
using AppVenta.Dominio.Modelos;
using Moq;

namespace AppVenta.Applicaciones.Servicios
{
    public class VentaServicio : IServicioMovimiento<VentaModel, int>
    {
        IRepositorioMovimiento<VentaModel, int> repoVenta;
        IRepositorioBase<ProductoModel, int> repoProducto;
        IRepositorioDetalle<VentaDetalleModel, int> repoDetalle;

        public VentaServicio(
            IRepositorioMovimiento<VentaModel, int> repoVenta, IRepositorioBase<ProductoModel, int> repoProducto, IRepositorioDetalle<VentaDetalleModel, int> repoDetalle)
        {
            this.repoVenta = repoVenta;
            this.repoProducto = repoProducto;
            this.repoDetalle = repoDetalle;
        }

        public VentaModel Agregar(VentaModel venta)
        {
            try
            {
                if (venta == null)
                    throw new ArgumentNullException("La 'Venta' es requerida");

                venta.VentaDetalles.ForEach(detalle =>
                {
                    var productoSeleccionado = repoProducto.SeleccionarPorId(detalle.productoId);
                    if (productoSeleccionado == null)
                    {
                        throw new ArgumentNullException("Usted está intentando vender un producto que no existe");
                    }

                    if (detalle.cantidadVendida > productoSeleccionado.cantidadEnStock)
                    {
                        throw new ArgumentNullException("No hay suficiente stock disponible para el producto seleccionado");
                    }

                    var ventaDetalleNuevo = new VentaDetalleModel()
                    {
                        ventaId = venta.ventaId,
                        productoId = detalle.productoId,
                        costoUnitario = productoSeleccionado.costo,
                        cantidadVendida = detalle.cantidadVendida,
                        subtotal = detalle.precioUnitario * detalle.cantidadVendida,
                        impuesto = (detalle.precioUnitario * detalle.cantidadVendida) * 15 / 100,
                        total = detalle.precioUnitario * detalle.cantidadVendida + ((detalle.precioUnitario * detalle.cantidadVendida) * 15 / 100)
                    };

                    repoDetalle.Agregar(ventaDetalleNuevo);

                    productoSeleccionado.cantidadEnStock -= detalle.cantidadVendida;
                    repoProducto.Editar(productoSeleccionado);

                    venta.subtotal1 += ventaDetalleNuevo.subtotal;
                    venta.impuesto += ventaDetalleNuevo.impuesto;
                    venta.total += ventaDetalleNuevo.total;
                    repoVenta.Agregar(venta);
                    repoVenta.GuardarTodosLosCambios();

                });
                return venta;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new VentaModel();
            }
        }

        public void Anular(int ventaId)
        {
            try
            {
                if(ventaId == null)
                    throw new ArgumentNullException("VentaId es requerido");
                repoVenta.Anular(ventaId);
                repoVenta.GuardarTodosLosCambios();
            }
            catch (Exception ex) { 
            
            }
        }

        public List<VentaModel> Listar()
        {
            return repoVenta.Listar();
        }

        public VentaModel SeleccionarPorId(int ventaId)
        {
            return repoVenta.SeleccionarPorId(ventaId);
        }
    }
}
