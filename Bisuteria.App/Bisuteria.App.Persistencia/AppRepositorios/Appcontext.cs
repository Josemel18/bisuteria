using Microsoft.EntityFrameworkCore;
using Bisuteria.App.Dominio.Entidades;
namespace Bisuteria.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<Categoria> Categorias { get; set; }







       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Utilicé el doble barra inclinada
                optionsBuilder.UseSqlServer("Persist Security Info=False;User ID=sa;Initial Catalog=bisuteria;Data Source=DESKTOP-N45SPK3\\SQLEXPRESS; Password = adminsql");
               //.UseSqlServer("Data Source = DESKTOP-N45SPK3\\SQLEXPRESS ; Initial Catalog = bisuteria ; User ID= sa; Password = adminsql");
            }


        }
    }
}

