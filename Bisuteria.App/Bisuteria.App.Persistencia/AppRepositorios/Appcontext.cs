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
                optionsBuilder
               .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog =ProyectoG58");
            }
        }
    }
}

