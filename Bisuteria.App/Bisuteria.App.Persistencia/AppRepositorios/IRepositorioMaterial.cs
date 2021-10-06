using System;
using System.Collections.Generic;
using System.Linq;
using Bisuteria.App.Dominio.Entidades;

namespace Bisuteria.App.Persistencia.AppRepositorios
{
    public interface IRepositorioMaterial
    {
        IEnumerable<Material> GetAllMaterials();
        Material AddMaterial(Material material);
        Material UpdateMaterial(Material material);
        void DeleteMaterial(string codigo);    
        Material GetMaterial(string codigo);
    }
}