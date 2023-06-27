// Importamos las entidades de dominio 
// Importamos las Interfaces de repositorio
// Importamos el Contexto
using AppVenta.Dominio.interfaces.Repositorios;
using AppVenta.Infraestructura.Datos.Contexto;
using AppVenta.Dominio.Modelos;
using AppFinanciero.Infraestructura.Datos.Mappers;

namespace AppVenta.Infraestructura.Datos.Repositorio
{
    public class VentasRepositorio : IRepositorioMovimiento<VentaModel, int>
    {
        // Crearemos la instancia de nuestro Context y lo llamaremos db.
        private readonly VentaContexto _dbContext;

        // Agregraremos un constructor que reciba como parametro VentaContexto de nombre "db"
        public VentasRepositorio(VentaContexto DbContext)
        {
            _dbContext = DbContext;
        }

        public VentaModel Agregar(VentaModel entidad)
        {
            _dbContext.Ventas.Add(entidad.Map());
            return entidad;
        }

        public void Anular(int entidadId)
        {
            var ventaSeleccionada = _dbContext.Ventas.Where(c => c.ventaId == entidadId).FirstOrDefault();
            if (ventaSeleccionada == null) {
                throw new NullReferenceException("Esta intentando anular una venta que no existe");
            }
            ventaSeleccionada.anulado = true;

            _dbContext.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }

        public void GuardarTodosLosCambios()
        {
            _dbContext.SaveChanges();
        }

        public List<VentaModel> Listar()
        {
            var listarVentas = _dbContext.Ventas.ToList();
            return listarVentas.Map();
        }

        public VentaModel SeleccionarPorId(int entidadId)
        {
            var ventaSeleccionada = _dbContext.Ventas.Where(c => c.ventaId == entidadId).FirstOrDefault();
            return ventaSeleccionada.Map();
        }
    }
}
