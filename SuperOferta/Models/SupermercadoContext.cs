using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SuperOferta.Models
{
    public class SupermercadoContext : IdentityDbContext<Cliente,MyRol,String>
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
