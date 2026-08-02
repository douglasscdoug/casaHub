using CasaHub.Application.Interfaces.Repositories;
using CasaHub.Domain.Entities;
using CasaHub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CasaHub.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CasaHubDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken)
        {
            email = email.Trim().ToLowerInvariant();
            return await _context.Users.AnyAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            email = email.Trim().ToLowerInvariant();
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }
    }
}