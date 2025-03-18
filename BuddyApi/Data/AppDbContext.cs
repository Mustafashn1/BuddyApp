using BuddyApi.Models;
using Microsoft.EntityFrameworkCore;
namespace BuddyApi.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Planlama> Planlar { get; set; }
        public DbSet<Gorev> Gorevler { get; set; }

    }
}
