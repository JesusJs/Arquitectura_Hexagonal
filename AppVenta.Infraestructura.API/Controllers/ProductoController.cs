using Microsoft.AspNetCore.Mvc;
using AppVenta.Dominio.Modelos;
using AppVenta.Infraestructura.DTO.DTOs;
using AppVenta.Infraestructura.DTO.Mappers;
using AppVenta.Applicaciones.Interfaces;

namespace AppVenta.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IServicioBase<ProductoModel, int> _servicioB;

        public ProductoController(IServicioBase<ProductoModel, int> servicioBase)
        {
            _servicioB = servicioBase;
        }


        // GET: api/<ProductoController>
        [HttpGet]
        public ActionResult<List<ProductoDTO>> Listar()
        {
            return Ok(_servicioB.Listar());
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public ActionResult<ProductoDTO> SeleccionarPorId(int id)
        {
            return Ok(_servicioB.SeleccionarPorId(id));
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult Agregar([FromBody] ProductoDTO producto)
        {
            _servicioB.Agregar(producto.Map());
            return Ok("Agregar satisfactoriamente !!!!!");
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Editar(int id, [FromBody] ProductoDTO producto)
        {
            producto.productoId = id;
            _servicioB.Editar(producto.Map());
            return Ok("Edtitado debidamente !!!!!!");
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            _servicioB.Eliminar(id);
            return Ok("Eliminado correctamente !!!!");
        }
    }
}
