using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {

        public IClienteDAL _clienteDAL { get; }
        public IPiscinaProductoDAL _productoDAL { get; }
        public IPiscinaDAL _piscinaDAL { get; }
        public IServicioPiscinaDAL _servicioPiscinaDAL { get; }
        public IEmpleadoDAL _empleadoDAL { get; }
        public IReservaDAL _reservaDAL { get; }
        public IPiscinaRepuestoDAL _repuestoDAL { get; }

        private readonly GestionPiscinasContext _context;

        public UnidadDeTrabajo(GestionPiscinasContext gestionPiscinasContext,
                                IClienteDAL clienteDAL,
                                IPiscinaProductoDAL productoDAL,
                                IPiscinaDAL piscinaDAL,
                                IServicioPiscinaDAL servicioPiscinaDAL,
                                IEmpleadoDAL empleadoDAL,
                                IReservaDAL reservaDAL,
                                IPiscinaRepuestoDAL repuestoDAL
                                )
        {
            _context = gestionPiscinasContext;
            _clienteDAL = clienteDAL;
            _productoDAL = productoDAL;
            _piscinaDAL = piscinaDAL;
            _servicioPiscinaDAL = servicioPiscinaDAL;
            _empleadoDAL = empleadoDAL;
            _reservaDAL = reservaDAL;
            _repuestoDAL = repuestoDAL;
        }


        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}