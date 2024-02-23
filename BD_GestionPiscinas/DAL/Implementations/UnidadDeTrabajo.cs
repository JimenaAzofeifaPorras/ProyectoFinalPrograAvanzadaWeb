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

        private readonly GestionPiscinasContext _context;

        public UnidadDeTrabajo(GestionPiscinasContext gestionPiscinasContext,
                                IClienteDAL clienteDAL
                                )
        {
            _context = gestionPiscinasContext;
            _clienteDAL = clienteDAL;
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