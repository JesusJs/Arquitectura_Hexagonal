//Importamos El dominio de la Aplicacion.
// Importamos las interfaces del repositorio.
// Tambien importamos las interfaces de las aplicaciones.
using AppVenta.Dominio.interfaces.Repositorios;
using AppVenta.Applicaciones.Interfaces;
using AppVenta.Dominio.Modelos;

namespace AppVenta.Applicaciones.Servicios
{
    public class ProductoServicio : IServicioBase<ProductoModel, int>
    {

        private readonly IRepositorioBase<ProductoModel, int> repoProducto;

        public ProductoServicio(IRepositorioBase<ProductoModel, int> _repoProducto)
        {
            this.repoProducto = _repoProducto;
        }

        public ProductoModel Agregar(ProductoModel producto)
        {
            try
            {
                if (producto == null)
                    throw new ArgumentNullException("El 'Producto' es requerido");

                var cantidadStock = Listar().Select(e => e.cantidadEnStock).Count();

                if (producto.cantidadEnStock > cantidadStock)
                    throw new ArgumentNullException("No hay Stock");

                var resultProducto = this.repoProducto.Agregar(producto);
                repoProducto.GuardarTodosLosCambios();
                return resultProducto;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public void Editar(ProductoModel producto)
        {
            try
            {
                if (producto == null)
                    throw new ArgumentNullException("El 'Producto' es requerido");

                this.repoProducto.Editar(producto);
                this.repoProducto.GuardarTodosLosCambios();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void Eliminar(int productoId)
        {
            try
            {
                this.repoProducto.Eliminar(productoId);
                this.repoProducto.GuardarTodosLosCambios();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public List<ProductoModel> Listar()
        {
            try
            {
                return repoProducto.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public ProductoModel SeleccionarPorId(int productoId)
        {
            try
            {
                return repoProducto.SeleccionarPorId(productoId);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
