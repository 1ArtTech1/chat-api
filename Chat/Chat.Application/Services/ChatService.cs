using AutoMapper;
using Chat.Application.Models;
using Chat.Application.Services.Interfaces;
using Chat.Infrastructure.Repositories.Interfaces;

namespace Chat.Application.Services;

/// <inheritdoc />
public class ChatService : IChatService
{
    private readonly IMapper mapper;
    private readonly IChatRepository repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatService"/> class.
    /// </summary>
    /// <param name="repository">The <see cref="IChatRepository"/> a instance.</param>
    /// <param name="mapper">The <see cref="IMapper"/> a instance.</param>
    public ChatService(
        IChatRepository repository,
        IMapper mapper)
    {
        this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <inheritdoc />
    public async Task<GetChatViewModel> AddAsync(CreateChatViewModel chatViewModel)
    {
        var chat = mapper.Map<Domain.Models.Chat>(chatViewModel);
        var createdChat = await repository.AddAsync(chat);
        var getChatViewModel = mapper.Map<GetChatViewModel>(createdChat) ?? new GetChatViewModel();

        return getChatViewModel;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<GetChatViewModel>> GetAllAsync()
    {
        var chats = await repository.GetAllAsync();
        var chatsViewModel = mapper.Map<IEnumerable<GetChatViewModel>>(chats) ?? Array.Empty<GetChatViewModel>();
        
        return chatsViewModel; 
    }
}