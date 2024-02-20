using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ClienteService : IClienteService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public ClienteService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddCliente(ClienteModel cliente)
        {
            Cliente entity = Convertir(cliente);
            _unidadDeTrabajo._clienteDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        ClienteModel Convertir(Cliente cliente)
        {
            return new ClienteModel
            {
                ClienteId = cliente.ClienteId,
                Nombre = cliente.Nombre,
                Email = cliente.Email,
                Telefono = cliente.Telefono
            };
        }

        Cliente Convertir(ClienteModel cliente)
        {
            return new Cliente
            {
                ClienteId = cliente.ClienteId,
                Nombre = cliente.Nombre,
                Email = cliente.Email
            };
        }
        public bool DeleteCliente(ClienteModel cliente)
        {
            Cliente entity = Convertir(cliente);
            _unidadDeTrabajo._clienteDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public ClienteModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._clienteDAL.Get(id);

            ClienteModel clienteModel = Convertir(entity);
            return clienteModel;
        }

        public IEnumerable<ClienteModel> GetCategories()
        {

            var result = _unidadDeTrabajo._clienteDAL.GetAll();
            List<ClienteModel> lista = new List<ClienteModel>();
            foreach (var cliente in result)
            {
                lista.Add(Convertir(cliente));


            }
            return lista;
        }

        public bool UpdateCliente(ClienteModel cliente)
        {
            Cliente entity = Convertir(cliente);
            _unidadDeTrabajo._clienteDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}