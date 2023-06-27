using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVenta.Infraestructura.Datos.Entidades;

//Importar entidades de dominio.
// Importaremos la herramienta entityFrameworkCore
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AppVenta.Infraestructura.Datos.Configs
{
    public class VentaDetalleConfig: IEntityTypeConfiguration<VentaDetalle>
    {
        public void Configure(EntityTypeBuilder<VentaDetalle> builder)
        {

            builder.ToTable("tblVentasDetalles");
            builder.HasKey(c => new { c.productoId, c.ventaId });

            builder
                .HasOne(detalle => detalle.Producto)
                .WithMany(venta => venta.VentaDetalles);
            builder
               .HasOne(detalle => detalle.Venta)
               .WithMany(venta => venta.VentaDetalles);

        }
    }
}
