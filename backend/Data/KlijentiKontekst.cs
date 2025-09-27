using Microsoft.EntityFrameworkCore;
using backend.Models;
namespace backend.Data
{
    public class KlijentiKontekst : DbContext
    {
        public KlijentiKontekst(DbContextOptions<KlijentiKontekst> options) : base(options)
        {
        }
        public DbSet<Knjiga> Knjige { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }  
}