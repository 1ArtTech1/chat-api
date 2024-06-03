using Chat.Application.Models;

namespace Chat.Application.Services.Interfaces;

/// <summary>
/// The message service.
/// </summary>
public interface IMessageService
{
    /// <summary>
    /// Adds a new message.
    /// </summary>
    /// <param name="createMessageViewModel">The <see cref="CreateMessageViewModel"/> a instance.</param>
    /// <returns>The <see cref="GetMessageViewModel"/> a instance.</returns>
    Task<GetMessageViewModel> AddAsync(CreateMessageViewModel createMessageViewModel);

    /// <summary>
    /// Get messages by chat ID.
    /// </summary>
    /// <param name="identifier">The identifier.</param>
    /// <returns>The <see cref="GetMessageViewModel"/> a instance.</returns>
    Task<IEnumerable<GetMessageViewModel>> GetByChatId(int identifier);
}