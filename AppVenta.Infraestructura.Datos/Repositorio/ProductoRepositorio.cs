using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

// Importamos las entidades de dominio 
// Importamos las Interfaces de repositorio
// Importamos el Contexto
using AppVenta.Dominio.interfaces.Repositorios;
using AppVenta.Infraestructura.Datos.Contexto;
using AppVenta.Dominio.Modelos;
using AppVenta.Infraestructura.Datos.Mappers;
using Microsoft.EntityFrameworkCore;

namespace AppVenta.Infraestructura.Datos.Repositorio
{
    public class ProductoRepositorio : IRepositorioBase<ProductoModel, int>
    {
        // Crearemos la instancia de nuestro Context y lo llamaremos _dbcontext.
        private readonly VentaContexto _dbContext;

        // Agregraremos un constructor que reciba como parametro VentaContexto de nombre "_dbcontext"
        public ProductoRepositorio(VentaContexto DbContext)
        {
            _dbContext = DbContext;
        }


        public ProductoModel Agregar(ProductoModel entidad)
        {
            _dbContext.Productos.Add(entidad.Map());
            return entidad;
        }

        public void Editar(ProductoModel entidad)
        {
            var productoSeleccionado = _dbContext.Productos.Where(c => c.productoId == entidad.productoId).FirstOrDefault();
            if(productoSeleccionado != null)
            {
                productoSeleccionado.nombre = entidad.nombre;
                productoSeleccionado.descripcion = entidad.descripcion;
                productoSeleccionado.costo = entidad.costo;
                productoSeleccionado.precio = entidad.precio;
                productoSeleccionado.cantidadEnStock = entidad.cantidadEnStock;

                _dbContext.Entry(productoSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(int entidadId)
        {
            var productoSeleccionado = _dbContext.Productos.Where(c => c.productoId == entidadId).FirstOrDefault();
            if (productoSeleccionado != null)
            {
                _dbContext.Productos.Remove(productoSeleccionado);
            }
        }

        public void GuardarTodosLosCambios()
        {
            _dbContext.SaveChanges();
        }

        public List<ProductoModel> Listar()
        {
            var productoListar = _dbContext.Productos.ToList();
            return productoListar.Map();
        }

        public ProductoModel SeleccionarPorId(int entidadId)
        {
            var productoSeleccionado = _dbContext.Productos.Where(c => c.productoId == entidadId).FirstOrDefault();
            return productoSeleccionado.Map();
        }
    }
}
