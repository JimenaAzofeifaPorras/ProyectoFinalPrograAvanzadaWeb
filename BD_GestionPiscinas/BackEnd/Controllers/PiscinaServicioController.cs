using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiscinaServicioController : ControllerBase
    {
        IPiscinaServicioService PiscinaServicioService;

        public PiscinaServicioController(IPiscinaServicioService piscinaServicioService)
        {
            PiscinaServicioService = piscinaServicioService;
        }

        // GET: api/<PiscinaServicioController>
        [HttpGet]
        public IEnumerable<PiscinaServicioModel> Get()
        {
            return PiscinaServicioService.GetPiscinaServicios();
        }

        // GET api/<PiscinaServicioController>/5
        [HttpGet("{id}")]
        public PiscinaServicioModel Get(int id)
        {
            return PiscinaServicioService.GetById(id);
        }

        // POST api/<PiscinaServicioController>
        [HttpPost]
        public string Post([FromBody] PiscinaServicioModel empleado)
        {
            var result = PiscinaServicioService.AddPiscinaServicio(empleado);

            if (result)
            {
                return "Servicio Agregado Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<PiscinaServicioController>/5
        [HttpPut]
        public string Put([FromBody] PiscinaServicioModel empleado)
        {
            var result = PiscinaServicioService.UpdatePiscinaServicio(empleado);

            if (result)
            {
                return "Servicio Editado Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<PiscinaServicioController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            PiscinaServicioModel empleado = new PiscinaServicioModel { ServicioId = id };
            var result = PiscinaServicioService.DeletePiscinaServicio(empleado);

            if (result)
            {
                return "Servicio Eliminado Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}
