using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Infraestructura.Datos.Entidades
{
    public class Venta
    {
        public int ventaId { get; set; }

        public long numeroVenta { get; set; }

        public DateTime fecha { get; set; }

        public string concepto { get; set; }

        public decimal subtotal1 { get; set; }

        public decimal impuesto { get; set; }
        public decimal total { get; set; }

        public bool anulado { get; set; }

        public virtual List<VentaDetalle> VentaDetalles { get; set; }
    }
}
