using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Importamos la herramienta de entity framework core.
// Importaremos las entidades de dominio.
// Importaremos las configuraciones que acabamos de crear.
using Microsoft.EntityFrameworkCore;
using AppVenta.Infraestructura.Datos.Configs;
using AppVenta.Infraestructura.Datos.Entidades;

namespace AppVenta.Infraestructura.Datos.Contexto
{
    public class VentaContexto:DbContext
    {
        public VentaContexto(DbContextOptions<VentaContexto> options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaDetalle> VentaDetalles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductoConfig());
            modelBuilder.ApplyConfiguration(new VentaConfig());
            modelBuilder.ApplyConfiguration(new VentaDetalleConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VentaContexto).Assembly);
        }

    }
}
