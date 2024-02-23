using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class PiscinaRepuestoService : IPiscinaRepuestoService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public PiscinaRepuestoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddPiscinaRepuesto(PiscinaRepuestoModel reserva)
        {
            Repuesto entity = Convertir(reserva);
            _unidadDeTrabajo._repuestoDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        PiscinaRepuestoModel Convertir(Repuesto reserva)
        {
            return new PiscinaRepuestoModel
            {
                Nombre = reserva.Nombre,
                Descripcion = reserva.Descripcion,
                Precio = reserva.Precio,
                RepuestoId = reserva.RepuestoId

            };
        }

        Repuesto Convertir(PiscinaRepuestoModel reserva)
        {
            return new Repuesto
            {
                Nombre = reserva.Nombre,
                Descripcion = reserva.Descripcion,
                Precio = reserva.Precio,
                RepuestoId = reserva.RepuestoId
            };
        }
        public bool DeletePiscinaRepuesto(PiscinaRepuestoModel reserva)
        {
            Repuesto entity = Convertir(reserva);
            _unidadDeTrabajo._repuestoDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public PiscinaRepuestoModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._repuestoDAL.Get(id);

            PiscinaRepuestoModel reservaModel = Convertir(entity);
            return reservaModel;
        }

        public IEnumerable<PiscinaRepuestoModel> GetPiscinaRepuestos()
        {

            var result = _unidadDeTrabajo._repuestoDAL.GetAll();
            List<PiscinaRepuestoModel> lista = new List<PiscinaRepuestoModel>();
            foreach (var reserva in result)
            {
                lista.Add(Convertir(reserva));


            }
            return lista;
        }

        public bool UpdatePiscinaRepuesto(PiscinaRepuestoModel reserva)
        {
            Repuesto entity = Convertir(reserva);
            _unidadDeTrabajo._repuestoDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}
