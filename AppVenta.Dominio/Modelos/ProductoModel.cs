using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Dominio.Modelos
{
    public class ProductoModel
    {

        public int productoId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal costo { get; set; }
        public decimal precio { get; set; }
        public decimal cantidadEnStock { get; set; }
        public List<VentaDetalleModel> VentaDetalles { get; set; }
    }
}
