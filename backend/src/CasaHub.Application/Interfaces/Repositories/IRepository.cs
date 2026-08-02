using CasaHub.Domain.Common;

namespace CasaHub.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        void Update(TEntity entity);
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}