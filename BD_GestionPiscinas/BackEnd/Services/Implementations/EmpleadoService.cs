using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class EmpleadoService : IEmpleadoService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public EmpleadoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddEmpleado(EmpleadoModel empleado)
        {
            Empleado entity = Convertir(empleado);
            _unidadDeTrabajo._empleadoDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        EmpleadoModel Convertir(Empleado empleado)
        {
            return new EmpleadoModel
            {
                EmpleadoId = empleado.EmpleadoId,
                Cargo = empleado.Cargo,
                Nombre = empleado.Nombre
            };
        }

        Empleado Convertir(EmpleadoModel empleado)
        {
            return new Empleado
            {
                EmpleadoId = empleado.EmpleadoId,
                Cargo = empleado.Cargo,
                Nombre = empleado.Nombre
            };
        }
        public bool DeleteEmpleado(EmpleadoModel empleado)
        {
            Empleado entity = Convertir(empleado);
            _unidadDeTrabajo._empleadoDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public EmpleadoModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._empleadoDAL.Get(id);

            EmpleadoModel empleadoModel = Convertir(entity);
            return empleadoModel;
        }

        public IEnumerable<EmpleadoModel> GetEmpleados()
        {

            var result = _unidadDeTrabajo._empleadoDAL.GetAll();
            List<EmpleadoModel> lista = new List<EmpleadoModel>();
            foreach (var empleado in result)
            {
                lista.Add(Convertir(empleado));


            }
            return lista;
        }

        public bool UpdateEmpleado(EmpleadoModel empleado)
        {
            Empleado entity = Convertir(empleado);
            _unidadDeTrabajo._empleadoDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}
