using System;
using System.Collections.Generic;
using System.Linq;
using Bisuteria.App.Dominio.Entidades;

namespace Bisuteria.App.Persistencia.AppRepositorios
{
    public class RepositorioCategoria : IRepositorioCategoria
    {
        
        private readonly AppContext _appContext;
        public RepositorioCategoria(AppContext appContext)
        {
            _appContext = appContext;
        }


    Categoria IRepositorioCategoria.AddCategoria(Categoria categoria) 
        {
            var CategoriaAdicionado = _appContext.Categorias.Add(categoria);
            _appContext.SaveChanges();
            //return CategoriaAdicionado.entity;
            return CategoriaAdicionado.Entity;
        }

     Categoria IRepositorioCategoria.UpdateCategoria(Categoria categoria)
        {
            var CategoriaEncontrado = _appContext.Categorias.FirstOrDefault(p => p.categoria == categoria.categoria);
            if (CategoriaEncontrado != null)
            {
                CategoriaEncontrado.categoria = categoria.categoria;
                
                //posterior cambio agregando cada atributo
               _appContext.SaveChanges();
            }
            return CategoriaEncontrado;
        }

        Categoria IRepositorioCategoria.GetCategoria(string categoria)
        {
            return _appContext.Categorias.FirstOrDefault(p => p.categoria == categoria);
        }

        IEnumerable<Categoria> IRepositorioCategoria.GetAllCategorias()
        {
            return _appContext.Categorias;
        }


        void IRepositorioCategoria.DeleteCategoria(string categoria)
        {
            var CategoriaEncontrado = _appContext.Categorias.FirstOrDefault(p => p.categoria == categoria);
            if (CategoriaEncontrado == null)
                return;
            _appContext.Categorias.Remove(CategoriaEncontrado);
            _appContext.SaveChanges();
        }
    }
}