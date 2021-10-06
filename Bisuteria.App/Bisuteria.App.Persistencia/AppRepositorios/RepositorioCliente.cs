using System;
using System.Collections.Generic;
using System.Linq;
using Bisuteria.App.Dominio.Entidades;


namespace Bisuteria.App.Persistencia
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private readonly AppContext _appContext;
        public RepositorioCliente(AppContext appContext)
        {
            _appContext = appContext;
        }


    Cliente IRepositorioCliente.AddCliente(Cliente cliente) 
        {
            var ClienteAdicionado = _appContext.Clientes.Add(cliente);
            _appContext.SaveChanges();
            //return ClienteAdicionado.entity;
            return ClienteAdicionado.Entity;
        }

     Cliente IRepositorioCliente.UpdateCliente(Cliente cliente)
        {
            var ClienteEncontrado = _appContext.Clientes.FirstOrDefault(p => p.identificacion == cliente.identificacion);
            if (ClienteEncontrado != null)
            {
                ClienteEncontrado.identificacion = cliente.identificacion;
                ClienteEncontrado.nombre1         = cliente.nombre1;
               _appContext.SaveChanges();
            }
            return ClienteEncontrado;
        }

        Cliente IRepositorioCliente.GetCliente(string identificacion)
        {
            return _appContext.Clientes.FirstOrDefault(p => p.identificacion == identificacion);
        }

        IEnumerable<Cliente> IRepositorioCliente.GetAllClientes()
        {
            return _appContext.Clientes;
        }


        void IRepositorioCliente.DeleteCliente(string identificacion)
        {
            var ClienteEncontrado = _appContext.Clientes.FirstOrDefault(p => p.identificacion == identificacion);
            if (ClienteEncontrado == null)
                return;
            _appContext.Clientes.Remove(ClienteEncontrado);
            _appContext.SaveChanges();
        }



    }

   
}