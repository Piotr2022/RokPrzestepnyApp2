using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RokPrzestepnyZBaza.Model;

namespace RokPrzestepnyZBaza.Data
{
    public class RokPrzestepnyDbContext : IdentityDbContext
    {
        public RokPrzestepnyDbContext(DbContextOptions<RokPrzestepnyDbContext> options) : base(options)
        {
        }

        public DbSet<WpisPrzestepnosci> WpisyPrzestepnosci { get; set; }
    }
}