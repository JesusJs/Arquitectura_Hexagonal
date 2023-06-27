using AppVenta.Applicaciones.Interfaces;
using AppVenta.Applicaciones.Servicios;
using AppVenta.Dominio.interfaces.Repositorios;
using AppVenta.Dominio.Modelos;
using AppVenta.Infraestructura.Datos.Contexto;
using AppVenta.Infraestructura.Datos.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AppVenta.Infraestructura.Datos.Common
{
    public static class ServicioCollections
    {
        public static void AddCommonLayer(this IServiceCollection services)
        {
            services.AddDbContext<VentaContexto>(options =>
            options.UseSqlServer(@"Data Source=SNK-\\LOCALHOST; Initial Catalog=VentasDb; Security=False;"));

            //Injection for Categoria
            services.AddTransient<IRepositorioDetalle<VentaDetalleModel, int>, VentaDetalleRepositorio>();
            services.AddTransient<IRepositorioBase<ProductoModel, int>, ProductoRepositorio>();
            services.AddTransient<IRepositorioMovimiento<VentaModel, int>, VentasRepositorio>();

            services.AddTransient<IServicioBase<ProductoModel, int>, ProductoServicio>();
            services.AddTransient<IServicioMovimiento<VentaModel, int>, VentaServicio>();
        }
    }
}
