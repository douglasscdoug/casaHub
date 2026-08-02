using CasaHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaHub.Infrastructure.Persistence
{
    public class CasaHubDbContext(DbContextOptions<CasaHubDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CasaHubDbContext).Assembly);
        }
    }
}