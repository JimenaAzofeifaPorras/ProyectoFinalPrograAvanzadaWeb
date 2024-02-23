using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IClienteDAL _clienteDAL { get; }
        IProductoDAL _productoDAL { get; }
        IPiscinaDAL _piscinaDAL { get; }
        IServicioPiscinaDAL _servicioPiscinaDAL { get; }
        IEmpleadoDAL _empleadoDAL { get; }
        IReservaDAL _reservaDAL { get; }
        IRepuestoDAL _repuestoDAL { get; }
        bool Complete();
    }
}