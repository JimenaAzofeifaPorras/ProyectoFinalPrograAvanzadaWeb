using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class ClienteDALImpl : DALGenericoImpl<Cliente>, IClienteDAL
    {
   

        public ClienteDALImpl(GestionPiscinasContext context) : base(context)
        {
            
        }


    }
}