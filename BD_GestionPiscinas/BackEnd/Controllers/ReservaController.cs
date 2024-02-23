using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        IReservaService ReservaService;

        public ReservaController(IReservaService reservaService)
        {
            ReservaService = reservaService;
        }

        // GET: api/<ReservaController>
        [HttpGet]
        public IEnumerable<ReservaModel> Get()
        {
            return ReservaService.GetReservas();
        }

        // GET api/<ReservaController>/5
        [HttpGet("{id}")]
        public ReservaModel Get(int id)
        {
            return ReservaService.GetById(id);
        }

        // POST api/<ReservaController>
        [HttpPost]
        public string Post([FromBody] ReservaModel reserva)
        {
            var result = ReservaService.AddReserva(reserva);

            if (result)
            {
                return "Reserva Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<ReservaController>/5
        [HttpPut]
        public string Put([FromBody] ReservaModel reserva)
        {
            var result = ReservaService.UpdateReserva(reserva);

            if (result)
            {
                return "Reserva Editada Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<ReservaController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            ReservaModel reserva = new ReservaModel { ReservaId = id };
            var result = ReservaService.DeleteReserva(reserva);

            if (result)
            {
                return "Reserva Eliminada Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}
