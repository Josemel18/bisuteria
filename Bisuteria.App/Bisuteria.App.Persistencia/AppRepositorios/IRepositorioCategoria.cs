using System;
using System.Collections.Generic;
using System.Linq;
using Bisuteria.App.Dominio.Entidades;

namespace Bisuteria.App.Persistencia.AppRepositorios
{
    public interface IRepositorioCategoria
    {
        IEnumerable<Categoria> GetAllCategorias();
        Categoria AddCategoria(Categoria categoria);
        Categoria UpdateCategoria(Categoria categoria);
        void DeleteCategoria(string codigo);    
        Categoria GetCategoria(string codigo);
    }
}