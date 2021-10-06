using System;
using System.Collections.Generic;
using System.Linq;
using Bisuteria.App.Dominio.Entidades;

namespace Bisuteria.App.Persistencia
{
    public interface IRepositorioVenta
    {
        IEnumerable<Venta> GetAllVentas();
        Venta AddVenta(Venta venta);
        Venta UpdateVenta(Venta venta);
        void DeleteVenta(int numero);    
        Venta GetVenta(int numero);
    }
}