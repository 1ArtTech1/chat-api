using Chat.Application.Models;

namespace Chat.Application.Services.Interfaces;

/// <summary>
/// The chat service.
/// </summary>
public interface IChatService
{
    /// <summary>
    /// Adds new chat.
    /// </summary>
    /// <param name="chatViewModel">The <see cref="CreateChatViewModel"/> a instance.</param>
    /// <returns>The <see cref="GetChatViewModel"/> a instance.</returns>
    Task<GetChatViewModel> AddAsync(CreateChatViewModel chatViewModel);

    /// <summary>
    /// Gets all chats.
    /// </summary>
    /// <returns>The <see cref="GetChatViewModel"/> a instance.</returns>
    Task<IEnumerable<GetChatViewModel>> GetAllAsync();
}