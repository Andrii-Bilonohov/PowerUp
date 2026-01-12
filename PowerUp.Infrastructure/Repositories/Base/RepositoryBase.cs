using Microsoft.EntityFrameworkCore;
using PowerUp.Domain.Models.Base;
using PowerUp.Infrastructure.Data;

namespace PowerUp.Infrastructure.Repositories.Base;

public abstract class RepositoryBase<TEntity> where TEntity : class
{
    private readonly PowerUpContext _context;
    protected DbSet<TEntity> DbSet => _context.Set<TEntity>();

    protected RepositoryBase(PowerUpContext context)
    {
        _context = context;
    }

    public virtual ValueTask<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
    }

    public virtual async Task<IReadOnlyList<TEntity>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken)
    {
        if (ids == null || ids.Count == 0)
            return new List<TEntity>();
        
        return await DbSet
            .Where(e => ids.Contains(EF.Property<Guid>(e, "Id")))
            .ToListAsync(cancellationToken);
    }

    public virtual void Add(TEntity entity)
    {
        _context.Add(entity);
    }

    public virtual void Update(TEntity entity)
    {
        _context.Update(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        if (entity is BaseEntity baseEntity)
        {
            baseEntity.DeletedAt = DateTime.UtcNow;
            DbSet.Update(entity);
        }
        else
        {
            DbSet.Remove(entity);
        }
    }
}