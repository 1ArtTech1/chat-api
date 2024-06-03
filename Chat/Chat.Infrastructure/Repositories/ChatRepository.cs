using Chat.Infrastructure.Contexts;
using Chat.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Repositories;

/// <inheritdoc cref="IChatRepository" />
public class ChatRepository : BaseRepository<Domain.Models.Chat>, IChatRepository
{
    private readonly DataBaseContext context;   
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ChatRepository"/> class.
    /// </summary>
    /// <param name="context">The <see cref="DataBaseContext"/> a instance.</param>
    public ChatRepository(DataBaseContext context) 
        : base(context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <inheritdoc cref="BaseRepository{Chat}" />
    public override async Task<IEnumerable<Domain.Models.Chat>> GetAllAsync()
    {
        var chats = await context.Chats
            .Include(chat => chat.Messages)
            .ToArrayAsync();

        return chats;
    }
}