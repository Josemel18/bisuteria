using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bisuteria.App.Dominio.Entidades;

namespace Bisuteria.App.Presentacion
{
    public class ListaModel : PageModel
    {

         public IEnumerable<Cliente> clientes {get;set;}
         public ListaModel(){
            clientes = new List<Cliente>()
            {
                new Cliente{identificacion="102030", nombre1="Miguel"},
                new Cliente{identificacion="304050", nombre1="Angie"},
                new Cliente{identificacion="607080", nombre1="Mateo Orozco"}
            };  
        }
        public void OnGet()
        {
        }
    }
}
