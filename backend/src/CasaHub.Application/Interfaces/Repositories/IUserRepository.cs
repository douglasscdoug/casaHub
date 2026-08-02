using CasaHub.Domain.Entities;

namespace CasaHub.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);
    }
}