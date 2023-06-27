using AppVenta.Dominio.Modelos;
using AppVenta.Infraestructura.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Infraestructura.DTO.Mappers
{
    public static class VentaMapper
    {
        public static VentaDTO Map(this VentaModel model)
        {
            return new VentaDTO()
            {
                ventaId = model.ventaId,
                numeroVenta = model.numeroVenta,
                fecha = model.fecha,
                concepto = model.concepto,
                subtotal1 = model.subtotal1,
                impuesto = model.impuesto,
                total = model.total,
                anulado = model.anulado,
            };
        }

        public static List<VentaDTO> Map(this List<VentaModel> model)
        {

            List<VentaDTO> DTO = new List<VentaDTO>();

            foreach (VentaModel modelItem in model)
            {
                DTO.Add(Map(modelItem));
            }
            return DTO;
        }
        public static VentaModel Map(this VentaDTO model)
        {
            return new VentaModel()
            {
                ventaId = model.ventaId,
                numeroVenta = model.numeroVenta,
                fecha = model.fecha,
                concepto = model.concepto,
                subtotal1 = model.subtotal1,
                impuesto = model.impuesto,
                total = model.total,
                anulado = model.anulado,
            };
        }
        public static List<VentaModel> Map(this List<VentaDTO> model)
        {

            List<VentaModel> DTO = new List<VentaModel>();

            foreach (VentaDTO modelItems in model)
            {
                DTO.Add(Map(modelItems));
            }
            return DTO;
        }
    }
}
