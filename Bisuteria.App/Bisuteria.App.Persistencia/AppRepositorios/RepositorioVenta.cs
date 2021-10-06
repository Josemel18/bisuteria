using System;
using System.Collections.Generic;
using System.Linq;
using Bisuteria.App.Dominio.Entidades;

namespace Bisuteria.App.Persistencia
{
    public class RepositorioVenta : IRepositorioVenta
    {
        private readonly AppContext _appContext;
        public RepositorioVenta(AppContext appContext)
        {
            _appContext = appContext;
        }


        Venta IRepositorioVenta.AddVenta(Venta venta) 
        {
            var VentaAdicionado = _appContext.Ventas.Add(venta);
            _appContext.SaveChanges();
            //return VentaAdicionado.entity;
            return VentaAdicionado.Entity;
        }

     Venta IRepositorioVenta.UpdateVenta(Venta venta)
        {
            var VentaEncontrado = _appContext.Ventas.FirstOrDefault(p => p.numero == venta.numero);
            if (VentaEncontrado != null)
            {
                VentaEncontrado.numero = venta.numero;
             
                //posterior cambio agregando cada atributo
               _appContext.SaveChanges();
            }
            return VentaEncontrado;
        }

        Venta IRepositorioVenta.GetVenta(int numero)
        {
            return _appContext.Ventas.FirstOrDefault(p => p.numero == numero);
        }

        IEnumerable<Venta> IRepositorioVenta.GetAllVentas()
        {
            return _appContext.Ventas;
        }


        void IRepositorioVenta.DeleteVenta(int numero)
        {
            var VentaEncontrado = _appContext.Ventas.FirstOrDefault(p => p.numero == numero);
            if (VentaEncontrado == null)
                return;
            _appContext.Ventas.Remove(VentaEncontrado);
            _appContext.SaveChanges();
        }




    }
}