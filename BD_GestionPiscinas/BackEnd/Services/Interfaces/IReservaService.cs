using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IReservaService
    {
        IEnumerable<ReservaModel> GetReservas();
        ReservaModel GetById(int id);
        bool AddReserva(ReservaModel Reserva);
        bool UpdateReserva(ReservaModel Reserva);
        bool DeleteReserva(ReservaModel Reserva);
    }
}
