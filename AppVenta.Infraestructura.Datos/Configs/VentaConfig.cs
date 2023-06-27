using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppVenta.Infraestructura.Datos.Entidades;
//Importar entidades de dominio.
// Importaremos la herramienta entityFrameworkCore
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppVenta.Infraestructura.Datos.Configs
{
    public class VentaConfig : IEntityTypeConfiguration<Venta> 
    {
        public void Configure(EntityTypeBuilder<Venta> builder) {

            builder.ToTable("tblVentas");
            builder.HasKey(c => c.ventaId);

            builder.HasMany(venta => venta.VentaDetalles)
                    .WithOne(detalle => detalle.Venta);
        }
    }
}
