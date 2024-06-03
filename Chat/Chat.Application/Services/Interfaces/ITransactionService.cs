using Chat.Application.Models;

namespace Chat.Application.Services.Interfaces;

/// <summary>
/// The transaction service.
/// </summary>
public interface ITransactionService
{
    /// <summary>
    /// Adds message in queue.
    /// </summary>
    /// <param name="message">The <see cref="CreateMessageViewModel"/> a instance.</param>
    /// <param name="handler">The <see cref="Func{CreateMessageViewModel, Task}"/> a instance.</param>
    /// <returns>The <see cref="Task"/> a instance.</returns>
    Task EnqueueMessageAsync(
        CreateMessageViewModel message,
        Func<CreateMessageViewModel, Task> handler);
}