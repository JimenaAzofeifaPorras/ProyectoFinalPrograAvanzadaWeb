using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IPiscinaProductoService
    {
        IEnumerable<PiscinaProductoModel> GetPiscinaProductos();
        PiscinaProductoModel GetById(int id);
        bool AddPiscinaProducto(PiscinaProductoModel PiscinaProducto);
        bool UpdatePiscinaProducto(PiscinaProductoModel PiscinaProducto);
        bool DeletePiscinaProducto(PiscinaProductoModel PiscinaProducto);
    }
}
