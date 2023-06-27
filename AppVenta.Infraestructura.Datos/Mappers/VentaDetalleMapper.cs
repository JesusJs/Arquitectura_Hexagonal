using AppVenta.Dominio.Modelos;
using AppVenta.Infraestructura.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Infraestructura.Datos.Mappers
{
    public static class VentaDetalleMapper
    {
        public static VentaDetalle Map(this VentaDetalleModel model)
        {
            return new VentaDetalle()
            {
                productoId = model.productoId,
                ventaId = model.ventaId,
                precioUnitario = model.precioUnitario,
                costoUnitario = model.costoUnitario,
                cantidadVendida = model.cantidadVendida,
                subtotal = model.subtotal,
                impuesto = model.impuesto,
                total = model.total
            };
        }
        public static List<VentaDetalle> Map(this List<VentaDetalleModel> model)
        {

            List<VentaDetalle> DTO = new List<VentaDetalle>();

            foreach (VentaDetalleModel modelItem in model)
            {
                DTO.Add(Map(modelItem));
            }
            return DTO;
        }
        public static VentaDetalleModel Map(this VentaDetalle model)
        {
            return new VentaDetalleModel()
            {
                productoId = model.productoId,
                ventaId = model.ventaId,
                precioUnitario = model.precioUnitario,
                costoUnitario = model.costoUnitario,
                cantidadVendida = model.cantidadVendida,
                subtotal = model.subtotal,
                impuesto = model.impuesto,
                total = model.total
            };
        }
        public static List<VentaDetalleModel> Map(this List<VentaDetalle> model)
        {

            List<VentaDetalleModel> DTO = new List<VentaDetalleModel>();

            foreach (VentaDetalle modelItem in model)
            {
                DTO.Add(Map(modelItem));
            }
            return DTO;
        }
    }
}
