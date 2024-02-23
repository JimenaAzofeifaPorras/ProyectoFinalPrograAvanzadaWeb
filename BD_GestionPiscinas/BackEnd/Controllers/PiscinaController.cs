using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiscinaController : ControllerBase
    {
        IPiscinaService PiscinaService;

        public PiscinaController(IPiscinaService piscinaService)
        {
            PiscinaService = piscinaService;
        }

        // GET: api/<PiscinaController>
        [HttpGet]
        public IEnumerable<PiscinaModel> Get()
        {
            return PiscinaService.GetPiscinas();
        }

        // GET api/<PiscinaController>/5
        [HttpGet("{id}")]
        public PiscinaModel Get(int id)
        {
            return PiscinaService.GetById(id);
        }

        // POST api/<PiscinaController>
        [HttpPost]
        public string Post([FromBody] PiscinaModel piscina)
        {
            var result = PiscinaService.AddPiscina(piscina);

            if (result)
            {
                return "Piscina Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<PiscinaController>/5
        [HttpPut]
        public string Put([FromBody] PiscinaModel piscina)
        {
            var result = PiscinaService.UpdatePiscina(piscina);

            if (result)
            {
                return "Piscina Editada Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<PiscinaController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            PiscinaModel piscina = new PiscinaModel { PiscinaId = id };
            var result = PiscinaService.DeletePiscina(piscina);

            if (result)
            {
                return "Piscina Eliminada Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}
