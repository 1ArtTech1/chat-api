using Chat.Domain.Models;
using Chat.Infrastructure.Contexts;
using Chat.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Repositories;

/// <inheritdoc cref="IMessageRepository" />
public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    private readonly DataBaseContext context;
   
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageRepository"/> class.
    /// </summary>
    /// <param name="context">The <see cref="DataBaseContext"/> a instance.</param>
    public MessageRepository(DataBaseContext context)
        : base(context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    /// <inheritdoc cref="BaseRepository{Message}" />
    public async Task<IEnumerable<Message>> GetByChatId(int identifier)
    {
        var messages = await context.Messages
                .Where(x => x.ChatId.Equals(identifier))
                .ToArrayAsync();

        return messages;
    }
}