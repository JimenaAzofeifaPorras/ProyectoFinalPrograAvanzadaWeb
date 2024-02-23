using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IEmpleadoService
    {
        IEnumerable<EmpleadoModel> GetEmpleados();
        EmpleadoModel GetById(int id);
        bool AddEmpleado(EmpleadoModel Empleado);
        bool UpdateEmpleado(EmpleadoModel Empleado);
        bool DeleteEmpleado(EmpleadoModel Empleado);
    }
}
