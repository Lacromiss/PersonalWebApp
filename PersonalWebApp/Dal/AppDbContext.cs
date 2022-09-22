using Microsoft.EntityFrameworkCore;
using PersonalWebApp.Models;

namespace PersonalWebApp.Dal
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
    

    }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Me> mes { get; set; }
        public DbSet<Profil> profils { get; set; }
        public DbSet<Science> sciences { get; set; }

    }
}
