using System;
using System.Collections.Generic;
using System.Linq;
using Bisuteria.App.Dominio.Entidades;


namespace Bisuteria.App.Persistencia
{
    public interface IRepositorioCliente
    {
        IEnumerable<Cliente> GetAllClientes();
        Cliente AddCliente(Cliente cliente);
        Cliente UpdateCliente(Cliente cliente);
        void DeleteCliente(string idCliente);    
        Cliente GetCliente(string idCliente);

    }
}