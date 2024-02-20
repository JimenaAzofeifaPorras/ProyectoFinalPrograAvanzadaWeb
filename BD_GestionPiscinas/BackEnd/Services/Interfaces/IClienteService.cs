using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IClienteService
    {
        IEnumerable<ClienteModel> GetCategories();
        ClienteModel GetById(int id);
        bool AddCliente(ClienteModel cliente);
        bool UpdateCliente(ClienteModel cliente);
        bool DeleteCliente(ClienteModel cliente);


    }
}