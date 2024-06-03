using Chat.Application.Models;
using Chat.Application.Providers.Interfaces;
using Chat.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Api.Hubs;

/// <summary>
/// The hub for message.
/// </summary>
[Authorize]
public class MessageHub : Hub
{
    private readonly ITransactionService transactionService;
    private readonly IMessageService messageService;
    private readonly IGroupManagerProvider _groupManagerProvider;
    private readonly IHubContext<MessageHub> hubContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="MessageHub"/> class.
    /// </summary>
    /// <param name="messageService">The <see cref="IMessageService"/> a instance.</param>
    /// <param name="transactionService">The <see cref="ITransactionService"/> a instance.</param>
    /// <param name="groupManagerProvider">The <see cref="IGroupManagerProvider"/> a instance.</param>
    /// <param name="hubContext">The <see cref="IHubContext{MessageHub}"/> a instance.</param>
    public MessageHub(
        IMessageService messageService,
        ITransactionService transactionService,
        IGroupManagerProvider groupManagerProvider,
        IHubContext<MessageHub> hubContext)
    {
        this.hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
        this._groupManagerProvider = groupManagerProvider ?? throw new ArgumentNullException(nameof(groupManagerProvider));
        this.messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
        this.transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
    }
    
    /// <summary>
    /// Adds new message.
    /// </summary>
    /// <param name="messageViewModel">The <see cref="CreateMessageViewModel"/> a instance.</param>
    public async Task CreateAsync(CreateMessageViewModel messageViewModel)
    {
        await transactionService.EnqueueMessageAsync(messageViewModel, CreateMessageAsync);
        await Clients.Caller.SendAsync(nameof(CreateAsync), messageViewModel);
    }

    /// <summary>
    /// Gets message by chat ID.
    /// </summary>
    /// <param name="identifier">The chat identifier.</param>
    public async Task GetByChatIdAsync(int identifier)
    {
        var messages = await messageService.GetByChatId(identifier);
        var allConnectionByIds = _groupManagerProvider.GroupManager.Where(keyValuePair => keyValuePair.Value.Equals(identifier));

        foreach (var connectionId in allConnectionByIds)
        {
            await hubContext.Clients.Client(connectionId.Key).SendAsync(nameof(GetByChatIdAsync), messages);
        }
    }

    /// <summary>
    /// Adds connection ID in the group manager.
    /// </summary>
    /// <param name="identifier">The identifier.</param>
    public void JoinGroup(int identifier)
    {
        _groupManagerProvider.GroupManager.Remove(Context.ConnectionId);
        _groupManagerProvider.GroupManager.Add(Context.ConnectionId, identifier);
    }
    
    /// <inheritdoc />
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _groupManagerProvider.GroupManager.Remove(Context.ConnectionId);
        
        return base.OnDisconnectedAsync(exception);
    }
    
    private async Task CreateMessageAsync(CreateMessageViewModel messageViewModel)
    {
        await messageService.AddAsync(messageViewModel);
        await GetByChatIdAsync(messageViewModel.ChatId);
    }
}