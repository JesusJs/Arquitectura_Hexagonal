using AppVenta.Dominio.Modelos;
using AppVenta.Infraestructura.Datos.Entidades;

namespace AppFinanciero.Infraestructura.Datos.Mappers
{
    public static class VentasMapper
    {
        public static Venta Map(this VentaModel model)
        {
            return new Venta()
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

        public static List<Venta> Map(this List<VentaModel> model)
        {

            List<Venta> DTO = new List<Venta>();

            foreach (VentaModel modelItem in model)
            {
                DTO.Add(Map(modelItem));
            }
            return DTO;
        }
        public static VentaModel Map(this Venta model)
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
        public static List<VentaModel> Map(this List<Venta> model)
        {

            List<VentaModel> DTO = new List<VentaModel>();

            foreach (Venta modelItems in model)
            {
                DTO.Add(Map(modelItems));
            }
            return DTO;
        }
    }
}