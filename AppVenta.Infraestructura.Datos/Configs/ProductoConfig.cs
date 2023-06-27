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
    public class ProductoConfig: IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("tblProductos");
            builder.HasKey(c => c.productoId);

            builder.HasMany(producto => producto.VentaDetalles)
                   .WithOne(detalle => detalle.Producto);
        }
    }
}
