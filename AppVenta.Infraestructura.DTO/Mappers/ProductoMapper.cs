using AppVenta.Dominio.Modelos;
using AppVenta.Infraestructura.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Infraestructura.DTO.Mappers
{
    public static class ProductoMapper
    {
        public static ProductoDTO Map(this ProductoModel model)
        {
            return new ProductoDTO()
            {
                productoId = model.productoId,
                nombre = model.nombre,
                descripcion = model.descripcion,
                costo = model.costo,
                precio = model.precio,
                cantidadEnStock = model.cantidadEnStock
            };
        }
        public static List<ProductoDTO> Map(this List<ProductoModel> model)
        {

            List<ProductoDTO> DTO = new List<ProductoDTO>();

            foreach (ProductoModel modelItem in model)
            {
                DTO.Add(Map(modelItem));
            }
            return DTO;
        }
        public static ProductoModel Map(this ProductoDTO model)
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
        public static List<ProductoModel> Map(this List<ProductoDTO> model)
        {

            List<ProductoModel> DTO = new List<ProductoModel>();

            foreach (ProductoDTO modelItem in model)
            {
                DTO.Add(Map(modelItem));
            }
            return DTO;
        }
    }
}
