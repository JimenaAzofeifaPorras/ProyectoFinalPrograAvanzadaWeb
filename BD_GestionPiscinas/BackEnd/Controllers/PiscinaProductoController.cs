using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiscinaProductoController : ControllerBase
    {
        IPiscinaProductoService PiscinaProductoService;

        public PiscinaProductoController(IPiscinaProductoService piscinaProductoService)
        {
            PiscinaProductoService = piscinaProductoService;
        }

        // GET: api/<PiscinaProductoController>
        [HttpGet]
        public IEnumerable<PiscinaProductoModel> Get()
        {
            return PiscinaProductoService.GetPiscinaProductos();
        }

        // GET api/<PiscinaProductoController>/5
        [HttpGet("{id}")]
        public PiscinaProductoModel Get(int id)
        {
            return PiscinaProductoService.GetById(id);
        }

        // POST api/<PiscinaProductoController>
        [HttpPost]
        public string Post([FromBody] PiscinaProductoModel empleado)
        {
            var result = PiscinaProductoService.AddPiscinaProducto(empleado);

            if (result)
            {
                return "Producto Agregado Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<PiscinaProductoController>/5
        [HttpPut]
        public string Put([FromBody] PiscinaProductoModel empleado)
        {
            var result = PiscinaProductoService.UpdatePiscinaProducto(empleado);

            if (result)
            {
                return "Producto Editado Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<PiscinaProductoController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            PiscinaProductoModel empleado = new PiscinaProductoModel { ProductoId = id };
            var result = PiscinaProductoService.DeletePiscinaProducto(empleado);

            if (result)
            {
                return "Producto Eliminado Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}
