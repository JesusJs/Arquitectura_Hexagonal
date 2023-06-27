using AppVenta.Dominio.Modelos;
using AppVenta.Applicaciones.Interfaces;
using AppVenta.Infraestructura.DTO.DTOs;
using AppVenta.Infraestructura.DTO.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace AppVenta.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IServicioMovimiento<VentaModel, int> _servicioB;

        public VentaController(IServicioMovimiento<VentaModel, int> servicioBase)
        {
            _servicioB = servicioBase;
        }

        // GET: api/<VentaController>
        [HttpGet]
        public ActionResult<List<VentaDTO>> Get()
        {
            return Ok(_servicioB.Listar());
        }

        // GET api/<VentaController>/5
        [HttpGet("{id}")]
        public ActionResult<VentaDTO> Get(int id)
        {
            return Ok(_servicioB.SeleccionarPorId(id));
        }

        // POST api/<VentaController>
        [HttpPost]
        public ActionResult Post([FromBody] VentaDTO venta)
        {
            _servicioB.Agregar(venta.Map());
            return Ok("Venta guardada correctamente !!!!");
        }
        // DELETE api/<VentaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _servicioB.Anular(id);
            return Ok("Venta anulada correctamente !!!!!");
        }
    }
}
