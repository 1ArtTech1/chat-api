using Chat.Infrastructure.Repositories;
using Chat.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Infrastructure.Extensions;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionDiExtension
{
    /// <summary>
    /// Adds Dependency Injection.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection" />.</param>
    public static void SetupInfrastructureDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IChatRepository, ChatRepository>();
    }
}