using System;
using System.Collections.Generic;
using System.Linq;
using Bisuteria.App.Dominio.Entidades;

namespace Bisuteria.App.Persistencia.AppRepositorios
{
    
        public class RepositorioProducto : IRepositorioProducto
    {
        private readonly AppContext _appContext;
        public RepositorioProducto(AppContext appContext)
        {
            _appContext = appContext;
        }


    Producto IRepositorioProducto.AddProducto(Producto producto) 
        {
            var ProductoAdicionado = _appContext.Productos.Add(producto);
            _appContext.SaveChanges();
            //return ProductoAdicionado.entity;
            return ProductoAdicionado.Entity;
        }

     Producto IRepositorioProducto.UpdateProducto(Producto producto)
        {
            var ProductoEncontrado = _appContext.Productos.FirstOrDefault(p => p.codigo == producto.codigo);
            if (ProductoEncontrado != null)
            {
                ProductoEncontrado.codigo = producto.codigo;
                
                //posterior cambio agregando cada atributo
               _appContext.SaveChanges();
            }
            return ProductoEncontrado;
        }

        Producto IRepositorioProducto.GetProducto(string codigo)
        {
            return _appContext.Productos.FirstOrDefault(p => p.codigo == codigo);
        }

        IEnumerable<Producto> IRepositorioProducto.GetAllProductos()
        {
            return _appContext.Productos;
        }


        void IRepositorioProducto.DeleteProducto(string codigo)
        {
            var ProductoEncontrado = _appContext.Productos.FirstOrDefault(p => p.codigo == codigo);
            if (ProductoEncontrado == null)
                return;
            _appContext.Productos.Remove(ProductoEncontrado);
            _appContext.SaveChanges();
        }
    }
    


}