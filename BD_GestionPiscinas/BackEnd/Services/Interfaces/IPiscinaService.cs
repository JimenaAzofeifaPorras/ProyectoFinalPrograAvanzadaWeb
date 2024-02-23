using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IPiscinaService
    {
        IEnumerable<PiscinaModel> GetPiscinas();
        PiscinaModel GetById(int id);
        bool AddPiscina(PiscinaModel Piscina);
        bool UpdatePiscina(PiscinaModel Piscina);
        bool DeletePiscina(PiscinaModel Piscina);
    }
}
