using Microsoft.EntityFrameworkCore;

namespace SuperOferta.Models
{
    public class SupermercadoContext: DbContext
    {
        public DbSet<Supermercado> Supermercados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SuperOferta;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
