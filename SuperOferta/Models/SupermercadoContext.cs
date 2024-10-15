using Microsoft.EntityFrameworkCore;

namespace SuperOferta.Models
{
    public class SupermercadoContext : DbContext
    {
        public DbSet<Supermercado> Supermercados { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public SupermercadoContext(DbContextOptions<SupermercadoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
