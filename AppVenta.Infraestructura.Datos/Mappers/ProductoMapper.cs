using AppVenta.Dominio.Modelos;
using AppVenta.Infraestructura.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Infraestructura.Datos.Mappers
{
    public static class ProductoMapper
    {
        public static Producto Map(this ProductoModel model)
            {
                return new Producto()
                {
                    productoId = model.productoId,
                    nombre = model.nombre,
                    descripcion = model.descripcion,
                    costo = model.costo,
                    precio = model.precio,
                    cantidadEnStock = model.cantidadEnStock
                };
            }
        public static List<Producto> Map(this List<ProductoModel> model)
            {

                List<Producto> DTO = new List<Producto>();

                foreach (ProductoModel modelItem in model)
                {
                    DTO.Add(Map(modelItem));
                }
                return DTO;
            }
        public static ProductoModel Map(this Producto model)
        {
            return new ProductoModel()
            {
                productoId = model.productoId,
                nombre = model.nombre,
                descripcion = model.descripcion,
                costo = model.costo,
                precio = model.precio,
                cantidadEnStock = model.cantidadEnStock
            };
        }
        public static List<ProductoModel> Map(this List<Producto> model)
        {

            List<ProductoModel> DTO = new List<ProductoModel>();

            foreach (Producto modelItem in model)
            {
                DTO.Add(Map(modelItem));
            }
            return DTO;
        }
    }
}
