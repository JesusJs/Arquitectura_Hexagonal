
namespace AppVenta.Infraestructura.Datos.Entidades
{
    public class Producto
    {
        public int productoId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal costo { get; set; }
        public decimal precio { get; set; }
        public decimal cantidadEnStock { get; set; }
        public virtual List<VentaDetalle> VentaDetalles { get; set; }
    }
}
