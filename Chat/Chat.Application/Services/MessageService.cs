using AutoMapper;
using Chat.Application.Models;
using Chat.Application.Services.Interfaces;
using Chat.Domain.Models;
using Chat.Infrastructure.Repositories.Interfaces;

namespace Chat.Application.Services;

/// <inheritdoc />
public class MessageService : IMessageService
{
    private readonly IMapper mapper;
    private readonly IMessageRepository repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="MessageService"/> class.
    /// </summary>
    /// <param name="repository">The <see cref="IMessageRepository"/> a instance.</param>
    /// <param name="mapper">The <see cref="IMapper"/> a instance.</param>
    public MessageService(
        IMapper mapper,
        IMessageRepository repository)
    {
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    /// <inheritdoc />
    public async Task<GetMessageViewModel> AddAsync(CreateMessageViewModel createMessageViewModel)
    {
        var message = mapper.Map<Message>(createMessageViewModel);
        var addMessage = await repository.AddAsync(message);
        var messageViewModel = mapper.Map<GetMessageViewModel>(addMessage) ?? new GetMessageViewModel();

        return messageViewModel;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<GetMessageViewModel>> GetByChatId(int identifier)
    {
        var messages = await repository.GetByChatId(identifier);
        var messageViewModel = mapper.Map<IEnumerable<GetMessageViewModel>>(messages) ?? Array.Empty<GetMessageViewModel>();

        return messageViewModel;
    }
}