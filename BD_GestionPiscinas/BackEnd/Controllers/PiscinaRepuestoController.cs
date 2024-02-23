using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiscinaRepuestoController : ControllerBase
    {
        IPiscinaRepuestoService PiscinaRepuestoService;

        public PiscinaRepuestoController(IPiscinaRepuestoService piscinaProductoService)
        {
            PiscinaRepuestoService = piscinaProductoService;
        }

        // GET: api/<PiscinaRepuestoController>
        [HttpGet]
        public IEnumerable<PiscinaRepuestoModel> Get()
        {
            return PiscinaRepuestoService.GetPiscinaRepuestos();
        }

        // GET api/<PiscinaRepuestoController>/5
        [HttpGet("{id}")]
        public PiscinaRepuestoModel Get(int id)
        {
            return PiscinaRepuestoService.GetById(id);
        }

        // POST api/<PiscinaRepuestoController>
        [HttpPost]
        public string Post([FromBody] PiscinaRepuestoModel empleado)
        {
            var result = PiscinaRepuestoService.AddPiscinaRepuesto(empleado);

            if (result)
            {
                return "Repuesto Agregado Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<PiscinaRepuestoController>/5
        [HttpPut]
        public string Put([FromBody] PiscinaRepuestoModel empleado)
        {
            var result = PiscinaRepuestoService.UpdatePiscinaRepuesto(empleado);

            if (result)
            {
                return "Repuesto Editado Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<PiscinaRepuestoController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            PiscinaRepuestoModel empleado = new PiscinaRepuestoModel { RepuestoId = id };
            var result = PiscinaRepuestoService.DeletePiscinaRepuesto(empleado);

            if (result)
            {
                return "Repuesto Eliminado Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}
