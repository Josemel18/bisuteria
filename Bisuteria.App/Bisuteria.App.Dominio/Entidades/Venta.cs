namespace Bisuteria.App.Dominio.Entidades
{
    public class Venta
    {
        public int numero { get; set; }
        public Cliente cliente {get;set;}
        public string fecha {get;set;}
        public string medio_pago {get;set;}
        public float valor_total {get;set;}
        public float ganancia {get;set;}
        public string estado {get;set;}
    }
}