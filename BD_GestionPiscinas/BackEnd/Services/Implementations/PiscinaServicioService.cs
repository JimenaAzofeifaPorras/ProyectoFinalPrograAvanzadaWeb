using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class PiscinaServicioService : IPiscinaServicioService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public PiscinaServicioService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddPiscinaServicio(PiscinaServicioModel servicio)
        {
            Servicio entity = Convertir(servicio);
            _unidadDeTrabajo._servicioPiscinaDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        PiscinaServicioModel Convertir(Servicio servicio)
        {
            return new PiscinaServicioModel
            {
                Descripcion = servicio.Descripcion,
                Nombre = servicio.Nombre,
                ServicioId = servicio.ServicioId,

            };
        }

        Servicio Convertir(PiscinaServicioModel servicio)
        {
            return new Servicio
            {
                Descripcion = servicio.Descripcion,
                Nombre = servicio.Nombre,
                ServicioId = servicio.ServicioId,
            };
        }
        public bool DeletePiscinaServicio(PiscinaServicioModel servicio)
        {
            Servicio entity = Convertir(servicio);
            _unidadDeTrabajo._servicioPiscinaDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public PiscinaServicioModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._servicioPiscinaDAL.Get(id);

            PiscinaServicioModel servicioModel = Convertir(entity);
            return servicioModel;
        }

        public IEnumerable<PiscinaServicioModel> GetPiscinaServicios()
        {

            var result = _unidadDeTrabajo._servicioPiscinaDAL.GetAll();
            List<PiscinaServicioModel> lista = new List<PiscinaServicioModel>();
            foreach (var servicio in result)
            {
                lista.Add(Convertir(servicio));


            }
            return lista;
        }

        public bool UpdatePiscinaServicio(PiscinaServicioModel servicio)
        {
            Servicio entity = Convertir(servicio);
            _unidadDeTrabajo._servicioPiscinaDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}
