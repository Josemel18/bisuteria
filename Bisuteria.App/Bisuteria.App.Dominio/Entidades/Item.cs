namespace Bisuteria.App.Dominio.Entidades
{
    public class Item
    {
        public int id{get;set;}
        public Venta venta {get;set;}
        public Producto producto {get;set;}
        public int cantidad {get;set;}
        public float subtotal {get;set;}
        public float descuento {get;set;}
    }
}