using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SuperOferta.Models
{
    public class SupermercadoContext : IdentityDbContext
    {
        public DbSet<Supermercado> Supermercados { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public SupermercadoContext(DbContextOptions<SupermercadoContext> options) : base(options) { }

        

    }
}
