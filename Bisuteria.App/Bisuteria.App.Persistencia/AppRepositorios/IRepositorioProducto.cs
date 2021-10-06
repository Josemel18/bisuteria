using System;
using System.Collections.Generic;
using System.Linq;
using Bisuteria.App.Dominio.Entidades;

namespace Bisuteria.App.Persistencia.AppRepositorios
{
    public interface IRepositorioProducto
    {
        IEnumerable<Producto> GetAllProductos();
        Producto AddProducto(Producto producto);
        Producto UpdateProducto(Producto producto);
        void DeleteProducto(string codigo);    
        Producto GetProducto(string codigo);
    }
}