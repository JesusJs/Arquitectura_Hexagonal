using AppVenta.Dominio.Modelos;
using AppVenta.Infraestructura.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Infraestructura.DTO.Mappers
{
    public static class VentaDetalleMapper
    {
        public static VentaDetalleDTO Map(this VentaDetalleModel model)
        {
            return new VentaDetalleDTO()
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
        public static List<VentaDetalleDTO> Map(this List<VentaDetalleModel> model)
        {

            List<VentaDetalleDTO> DTO = new List<VentaDetalleDTO>();

            foreach (VentaDetalleModel modelItem in model)
            {
                DTO.Add(Map(modelItem));
            }
            return DTO;
        }
        public static VentaDetalleModel Map(this VentaDetalleDTO model)
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
        public static List<VentaDetalleModel> Map(this List<VentaDetalleDTO> model)
        {

            List<VentaDetalleModel> DTO = new List<VentaDetalleModel>();

            foreach (VentaDetalleDTO modelItem in model)
            {
                DTO.Add(Map(modelItem));
            }
            return DTO;
        }
    }
}
