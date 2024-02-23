using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ReservaService : IReservaService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public ReservaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddReserva(ReservaModel reserva)
        {
            Reserva entity = Convertir(reserva);
            _unidadDeTrabajo._reservaDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        ReservaModel Convertir(Reserva reserva)
        {
            return new ReservaModel
            {
                ReservaId = reserva.ReservaId,
                ClienteId = reserva.ClienteId,
                FechaFin = reserva.FechaFin,
                FechaInicio = reserva.FechaInicio,
                PiscinaId = reserva.PiscinaId
            };
        }

        Reserva Convertir(ReservaModel reserva)
        {
            return new Reserva
            {
                ReservaId = reserva.ReservaId,
                ClienteId = reserva.ClienteId,
                FechaFin = reserva.FechaFin,
                FechaInicio = reserva.FechaInicio,
                PiscinaId = reserva.PiscinaId
            };
        }
        public bool DeleteReserva(ReservaModel reserva)
        {
            Reserva entity = Convertir(reserva);
            _unidadDeTrabajo._reservaDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public ReservaModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._reservaDAL.Get(id);

            ReservaModel reservaModel = Convertir(entity);
            return reservaModel;
        }

        public IEnumerable<ReservaModel> GetReservas()
        {

            var result = _unidadDeTrabajo._reservaDAL.GetAll();
            List<ReservaModel> lista = new List<ReservaModel>();
            foreach (var reserva in result)
            {
                lista.Add(Convertir(reserva));


            }
            return lista;
        }

        public bool UpdateReserva(ReservaModel reserva)
        {
            Reserva entity = Convertir(reserva);
            _unidadDeTrabajo._reservaDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}
