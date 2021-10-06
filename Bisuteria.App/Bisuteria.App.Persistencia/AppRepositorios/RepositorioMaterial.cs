using System;
using System.Collections.Generic;
using System.Linq;
using Bisuteria.App.Dominio.Entidades;

namespace Bisuteria.App.Persistencia.AppRepositorios
{
    public class RepositorioMaterial : IRepositorioMaterial
    {
        
        private readonly AppContext _appContext;
        public RepositorioMaterial(AppContext appContext)
        {
            _appContext = appContext;
        }


    Material IRepositorioMaterial.AddMaterial(Material material) 
        {
            var MaterialAdicionado = _appContext.Materiales.Add(material);
            _appContext.SaveChanges();
            //return MaterialAdicionado.entity;
            return MaterialAdicionado.Entity;
        }

     Material IRepositorioMaterial.UpdateMaterial(Material material)
        {
            var MaterialEncontrado = _appContext.Materiales.FirstOrDefault(p => p.material == material.material);
            if (MaterialEncontrado != null)
            {
                MaterialEncontrado.material = material.material;
                
                //posterior cambio agregando cada atributo
               _appContext.SaveChanges();
            }
            return MaterialEncontrado;
        }

        Material IRepositorioMaterial.GetMaterial(string material)
        {
            return _appContext.Materiales.FirstOrDefault(p => p.material == material);
        }

        IEnumerable<Material> IRepositorioMaterial.GetAllMaterials()
        {
            return _appContext.Materiales;
        }


        void IRepositorioMaterial.DeleteMaterial(string material)
        {
            var MaterialEncontrado = _appContext.Materiales.FirstOrDefault(p => p.material == material);
            if (MaterialEncontrado == null)
                return;
            _appContext.Materiales.Remove(MaterialEncontrado);
            _appContext.SaveChanges();
        }
    }
}