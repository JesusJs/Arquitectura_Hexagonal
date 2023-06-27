using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Dominio.Modelos
{
    public class VentaDetalleModel
    {
        public int productoId { get; set; }
        public int ventaId { get; set; }
        public decimal costoUnitario { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal cantidadVendida { get; set; }
        public decimal subtotal { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }

    }
}
