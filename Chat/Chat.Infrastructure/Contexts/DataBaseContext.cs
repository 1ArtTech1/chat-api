using Chat.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Contexts;

/// <summary>
/// The Database context.
/// </summary>
public class DataBaseContext : DbContext
{
    /// <summary>
    /// Gets or sets a chats.
    /// </summary>
    public DbSet<Domain.Models.Chat> Chats { get; set; }

    /// <summary>
    /// Gets or sets a messages.
    /// </summary>
    public DbSet<Message> Messages { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DataBaseContext"/> class.
    /// </summary>
    /// <param name="options">The <see cref="DbContextOptions{DataBaseContext}"/></param>
    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    { 
    }
}