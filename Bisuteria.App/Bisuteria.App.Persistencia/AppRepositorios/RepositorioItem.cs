using System;
using System.Collections.Generic;
using System.Linq;
using Bisuteria.App.Dominio.Entidades;

namespace Bisuteria.App.Persistencia.AppRepositorios
{
    public class RepositorioItem : IRepositorioItem
    {
         private readonly AppContext _appContext;
        public RepositorioItem(AppContext appContext)
        {
            _appContext = appContext;
        }


        Item IRepositorioItem.AddItem(Item item) 
        {
            var ItemAdicionado = _appContext.Items.Add(item);
            _appContext.SaveChanges();
            //return ItemAdicionado.entity;
            return ItemAdicionado.Entity;
        }

     Item IRepositorioItem.UpdateItem(Item item)
        {
            var ItemEncontrado = _appContext.Items.FirstOrDefault(p => p.venta.numero == item.venta.numero && p.producto.codigo == item.producto.codigo );
            if (ItemEncontrado != null)
            {
                ItemEncontrado.venta = item.venta;
                ItemEncontrado.producto = item.producto;
                //posterior cambio agregando cada atributo
               _appContext.SaveChanges();
            }
            return ItemEncontrado;
        }

        Item IRepositorioItem.GetItem(Venta venta, Producto producto)
        {
            return _appContext.Items.FirstOrDefault(p => p.venta.numero == venta.numero && p.producto.codigo == producto.codigo );
        }

        IEnumerable<Item> IRepositorioItem.GetAllItems()
        {
            return _appContext.Items;
        }


        void IRepositorioItem.DeleteItem(Venta venta, Producto producto)
        {
            var ItemEncontrado = _appContext.Items.FirstOrDefault(p => p.venta.numero == venta.numero && p.producto.codigo == producto.codigo );
            if (ItemEncontrado == null)
                return;
            _appContext.Items.Remove(ItemEncontrado);
            _appContext.SaveChanges();
        }
    }
}