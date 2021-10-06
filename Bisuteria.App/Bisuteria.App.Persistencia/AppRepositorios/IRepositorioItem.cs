using System;
using System.Collections.Generic;
using System.Linq;
using Bisuteria.App.Dominio.Entidades;


namespace Bisuteria.App.Persistencia.AppRepositorios
{
    public interface IRepositorioItem
    {
        IEnumerable<Item> GetAllItems();
        Item AddItem(Item item);
        Item UpdateItem(Item item);
        void DeleteItem(Venta venta, Producto producto);    
        Item GetItem(Venta venta, Producto producto);
    }
}