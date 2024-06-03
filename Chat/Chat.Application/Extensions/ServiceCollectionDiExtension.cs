using Chat.Application.Services;
using Chat.Application.Services.Interfaces;
using Chat.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Application.Extensions;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionDiExtension
{
    /// <summary>
    /// Adds Dependency Injection.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection" />.</param>
    public static void SetupApplicationDependencyInjection(this IServiceCollection services)
    {
        services.SetupInfrastructureDependencyInjection();
        services.AddScoped<IChatService, ChatService>();
        services.AddScoped<IMessageService, MessageService>();
    }
}