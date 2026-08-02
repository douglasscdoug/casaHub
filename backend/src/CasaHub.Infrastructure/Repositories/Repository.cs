using CasaHub.Application.Interfaces.Repositories;
using CasaHub.Domain.Common;
using CasaHub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CasaHub.Infrastructure.Repositories
{
    public abstract class Repository<TEntity>(CasaHubDbContext context) : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly CasaHubDbContext _context = context;

        protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(entity, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }
        
        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}