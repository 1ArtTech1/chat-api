using Chat.Domain.Models;

namespace Chat.Infrastructure.Repositories.Interfaces;

/// <summary>
/// The message repository.
/// </summary>
public interface IMessageRepository : IBaseRepository<Message>
{
    /// <summary>
    /// Gets message by chat ID.
    /// </summary>
    /// <param name="identifier">The identifier.</param>
    /// <returns>The <see cref="Message"/> a instance.</returns>
    Task<IEnumerable<Message>> GetByChatId(int identifier);
}