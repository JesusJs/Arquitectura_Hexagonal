using AppVenta.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Infraestructura.Datos.Entidades
{
    public class VentaDetalle
    {
        public int productoId { get; set; }
        public int ventaId { get; set; }
        public decimal costoUnitario { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal cantidadVendida { get; set; }
        public decimal subtotal { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Venta Venta { get; set; }

    }
}
