using System;

namespace Bisuteria.App.Dominio.Entidades
{
    public class Producto
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int stock {get;set;}
        public float peso {get;set;}
        public string talla { get; set; }
        public Categoria categoria { get; set; }
        public Material material { get; set; }
        public float precio_compra {get;set;}
        public float precio_venta {get;set;}
        public string estado { get; set; }
    }
}