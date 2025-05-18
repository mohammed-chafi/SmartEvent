using Microsoft.EntityFrameworkCore;
using SmartEvent.Core.Models;

namespace SmartEvent.Data.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Organisation> Organisations { get; set; }

    }
}