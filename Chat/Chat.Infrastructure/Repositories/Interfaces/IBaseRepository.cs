namespace Chat.Infrastructure.Repositories.Interfaces;

/// <summary>
/// The base repository.
/// </summary>
/// <typeparam name="TEntity">The generic entity type.</typeparam>
public interface IBaseRepository<TEntity>
    where TEntity : class
{
    /// <summary>
    /// Adds a new entity.
    /// </summary>
    /// <param name="entity">Parameter to create new data</param>
    /// <returns>Returns generic data.</returns>
    Task<TEntity> AddAsync(TEntity entity);
    
    /// <summary>
    /// Gets all data.
    /// </summary>
    /// <returns>Returns collections of the data.</returns>
    Task<IEnumerable<TEntity>> GetAllAsync();
}