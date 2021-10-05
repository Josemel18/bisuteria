namespace Bisuteria.App.Dominio.Entidades
{
    public class Venta
    {
        public int numero { get; set; }
        public Cliente cliente {get;set;}
        public String fecha {get;set;}
        public String medio_pago {get;set;}
        public float valor_total {get;set;}
        public float ganancia {get;set;}
        public String estado {get;set;}
    }
}