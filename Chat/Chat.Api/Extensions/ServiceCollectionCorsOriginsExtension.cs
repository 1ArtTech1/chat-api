using Chat.Api.Constants;
using Chat.Api.Models.Settings;

namespace Chat.Api.Extensions;

/// <summary>
/// Cors extension methods for <see cref="IServiceCollection" />.
/// </summary>
public static class ServiceCollectionCorsOriginsExtension
{
    /// <summary>
    /// Adds Cors configuration.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection" />.</param>
    /// <param name="configuration"><see cref="IConfiguration" /> of the application.</param>
    public static void ConfigureCorsForOrigins(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var corsOriginConfiguration = configuration
            .GetSection(ApiConstants.Configurations.CorsOrigin)
            .Get<CorsOriginSettings>() ?? throw new ArgumentException("Cors origins should not be empty or null.", nameof(configuration));

        services.AddCors(options =>
        {
            options.AddPolicy(
                ApiConstants.Configurations.CorsPolicyName,
                builder =>
                {
                    builder
                        .WithOrigins(corsOriginConfiguration.Links.ToArray())
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
        });
    }
}