using Microsoft.EntityFrameworkCore;

namespace test.Models
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Compras> Compras { get; set; }
    }
}
