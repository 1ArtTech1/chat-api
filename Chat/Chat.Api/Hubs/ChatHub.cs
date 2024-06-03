using Chat.Application.Models;
using Chat.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Api.Hubs;

/// <summary>
/// The hub for chat.
/// </summary>
[Authorize]
public class ChatHub : Hub
{
    private readonly IChatService chatService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatHub"/> class.
    /// </summary>
    /// <param name="chatService">The <see cref="IChatService"/> a instance.</param>
    public ChatHub(IChatService chatService)
    {
        this.chatService = chatService ?? throw new ArgumentNullException(nameof(chatService));
    }
    
    /// <summary>
    /// Adds new chat.
    /// </summary>
    /// <param name="chatViewModel">The <see cref="CreateChatViewModel"/> a instance.</param>
    public async Task CreateAsync(CreateChatViewModel chatViewModel)
    {
        var chat = await chatService.AddAsync(chatViewModel);
        await Clients.Caller.SendAsync(nameof(CreateAsync), chat);
        await GetAllAsync();
    }

    /// <summary>
    /// Gets all chats.
    /// </summary>
    public async Task GetAllAsync()
    {
        var chats = (await chatService.GetAllAsync()).ToArray();
        await Clients.Caller.SendAsync(nameof(GetAllAsync), chats);
    }
}