using Chat.Infrastructure.Contexts;
using Chat.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Repositories;

/// <inheritdoc />
public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
{
    private DbSet<TEntity> entities;
    private readonly DataBaseContext context;

    /// <summary>
    /// Initializes a new instance of the <see><cref>BaseRepository</cref></see> class.
    /// </summary>
    /// <param name="context">The <see cref="DataBaseContext"/> a instance.</param>
    public BaseRepository(
        DataBaseContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }
   
    /// <inheritdoc />
    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        entities = context.Set<TEntity>();
        await entities.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }
    
    /// <inheritdoc />
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        entities = context.Set<TEntity>();
        
        return await entities.ToListAsync();
    }
}