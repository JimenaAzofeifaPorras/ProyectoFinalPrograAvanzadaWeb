using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IPiscinaRepuestoService
    {
        IEnumerable<PiscinaRepuestoModel> GetPiscinaRepuestos();
        PiscinaRepuestoModel GetById(int id);
        bool AddPiscinaRepuesto(PiscinaRepuestoModel PiscinaRepuesto);
        bool UpdatePiscinaRepuesto(PiscinaRepuestoModel PiscinaRepuesto);
        bool DeletePiscinaRepuesto(PiscinaRepuestoModel PiscinaRepuesto);
    }
}
