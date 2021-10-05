using System;

namespace Bisuteria.App.Dominio.Entidades
{
    public class Producto
    {
        public String codigo { get; set; }
        public String nombre { get; set; }
        public int stock {get;set;}
        public float peso {get;set;}
        public String talla { get; set; }
        public Categoria categoria { get; set; }
        public Material material { get; set; }
        public float precio_compra {get;set;}
        public float precio_venta {get;set;}
        public String estado { get; set; }
    }
}