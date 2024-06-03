namespace Chat.Infrastructure.Repositories.Interfaces;

/// <summary>
/// The chat repository.
/// </summary>
public interface IChatRepository : IBaseRepository<Domain.Models.Chat>
{
    /// <summary>
    /// Gets all chats.
    /// </summary>
    /// <returns>The <see cref="Chat"/> a instance.</returns>
    Task<IEnumerable<Domain.Models.Chat>> GetAllAsync();
}