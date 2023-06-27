using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Importamos las entidades de dominio 
// Importamos las Interfaces de repositorio
// Importamos el Contexto
using AppVenta.Dominio.interfaces;
using AppVenta.Dominio.interfaces.Repositorios;
using AppVenta.Dominio.Modelos;
using AppVenta.Infraestructura.Datos.Contexto;
using AppVenta.Infraestructura.Datos.Mappers;

namespace AppVenta.Infraestructura.Datos.Repositorio
{

    public class VentaDetalleRepositorio: IRepositorioDetalle<VentaDetalleModel, int>
    {
        // Crearemos la instancia de nuestro Context y lo llamaremos db.
        private readonly VentaContexto _dbContext;

        // Agregraremos un constructor que reciba como parametro VentaContexto de nombre "db"
        public VentaDetalleRepositorio(VentaContexto DbContext)
        {
            _dbContext = DbContext;
        }

        public VentaDetalleModel Agregar(VentaDetalleModel entidad)
        {
            _dbContext.VentaDetalles.Add(entidad.Map());
            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            _dbContext.SaveChanges();
        }
    }
}
