using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IPiscinaServicioService
    {
        IEnumerable<PiscinaServicioModel> GetPiscinaServicios();
        PiscinaServicioModel GetById(int id);
        bool AddPiscinaServicio(PiscinaServicioModel PiscinaServicio);
        bool UpdatePiscinaServicio(PiscinaServicioModel PiscinaServicio);
        bool DeletePiscinaServicio(PiscinaServicioModel PiscinaServicio);
    }
}
