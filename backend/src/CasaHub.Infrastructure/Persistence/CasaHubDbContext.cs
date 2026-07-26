using Microsoft.EntityFrameworkCore;

namespace CasaHub.Infrastructure.Persistence
{
    public class CasaHubDbContext(DbContextOptions<CasaHubDbContext> options) : DbContext(options)
    {
    }
}