using Application.Interfaces.IOrden;
using Application.Interfaces.IProducto;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class ProductoServices : IProductoServices
    {
        private readonly IProductoCommand _command;
        private readonly IProductoQuery _query;

        public ProductoServices(IProductoCommand command, IProductoQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<Producto> CreateProducto(ProductoModel request)
        {
            var Producto = new Producto
            {
                Nombre = request.ProductoNombre,
                Descripcion = request.ProductoDescripcion,
                Marca = request.ProductoMarca,
                Codigo = request.ProductoCodigo,
                Precio = request.ProductoPrecio,
                Image = request.ProductoImage,
            };
            await _command.InsertProducto(Producto);
            return Producto;
        }

        public async Task<Producto> UpdateProducto(Producto producto)
        {
            await _command.UpdateProducto(producto);
            return producto;
        }

        public async Task<Producto> DeleteProducto(Producto producto)
        {
            await _command.RemoveProducto(producto);
            return producto;
        }

        public async Task<List<Producto>> GetAllProductos()
        {
            var Productos = await _query.GetListProductos();
            return Productos;
        }

        public async Task<Producto> GetProductoById(int id)
        {
            var Producto = await _query.GetProducto(id);
            return Producto;
        }
    }
}
