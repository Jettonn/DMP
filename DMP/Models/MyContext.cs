using Microsoft.EntityFrameworkCore;

namespace DMP.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<Event> Events { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}