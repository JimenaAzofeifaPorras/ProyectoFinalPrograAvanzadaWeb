using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class ClienteDALImpl : DALGenericoImpl<Cliente>, IClienteDAL
    {
        GestionPiscinasContext _context;

        public ClienteDALImpl(GestionPiscinasContext context) : base(context)
        {
            _context = context;
        }



        public IEnumerable<Cliente> GetAll()
        {
            List<sp_GetAllClientes_Result> results;

            string sql = "[dbo].[sp_GetAllClientes]";

            results = _context.Sp_GetAllClientes_Results
                        .FromSqlRaw(sql)
                        .ToList();

            List<Cliente> categories = new List<Cliente>();

            foreach (var item in results)
            {
                categories.Add(
                    new Cliente
                    {
                        ClienteId = item.ClienteId,
                        Nombre = item.Nombre,
                        Email = item.Email,
                        Telefono = item.Telefono
                    }
                    );
            }



            return categories;
        }


        public bool Add(Cliente entity)
        {
            try
            {

                string sql = "exec [dbo].[sp_AddCategory] @Nombre, @Email";

                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName= "@Nombre",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value=entity.Nombre
                    },
                    new SqlParameter()
                    {
                        ParameterName= "@Email",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value=entity.Email
                    }

                };


                _Context.Database.ExecuteSqlRaw(sql, param);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}