using AutoMapper;
using Chat.Application.Models;
using Chat.Domain.Models;

namespace Chat.Application.Mappers;

/// <summary>
/// The mapping profile.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingProfile"/> class.
    /// </summary>
    public MappingProfile()
    {
        CreateMap<CreateChatViewModel, Domain.Models.Chat>();
        CreateMap<Message, GetMessageViewModel>().ReverseMap();
        CreateMap<Domain.Models.Chat, GetChatViewModel>().ReverseMap();
        CreateMap<Message, CreateMessageViewModel>().ReverseMap();
    }
}