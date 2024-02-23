using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class PiscinaProductoService : IPiscinaProductoService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public PiscinaProductoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddPiscinaProducto(PiscinaProductoModel producto)
        {
            Producto entity = Convertir(producto);
            _unidadDeTrabajo._productoDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        PiscinaProductoModel Convertir(Producto producto)
        {
            return new PiscinaProductoModel
            {
                Precio = producto.Precio,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                ProductoId = producto.ProductoId

            };
        }

        Producto Convertir(PiscinaProductoModel producto)
        {
            return new Producto
            {
                Precio = producto.Precio,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                ProductoId = producto.ProductoId
            };
        }
        public bool DeletePiscinaProducto(PiscinaProductoModel producto)
        {
            Producto entity = Convertir(producto);
            _unidadDeTrabajo._productoDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public PiscinaProductoModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._productoDAL.Get(id);

            PiscinaProductoModel productoModel = Convertir(entity);
            return productoModel;
        }

        public IEnumerable<PiscinaProductoModel> GetPiscinaProductos()
        {

            var result = _unidadDeTrabajo._productoDAL.GetAll();
            List<PiscinaProductoModel> lista = new List<PiscinaProductoModel>();
            foreach (var producto in result)
            {
                lista.Add(Convertir(producto));


            }
            return lista;
        }

        public bool UpdatePiscinaProducto(PiscinaProductoModel producto)
        {
            Producto entity = Convertir(producto);
            _unidadDeTrabajo._productoDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}
