using Chat.Api.Constants;
using Chat.Api.Models.Settings;
using Microsoft.OpenApi.Models;

namespace Chat.Api.Extensions;

/// <summary>
/// Swagger extension methods for <see cref="IServiceCollection" />.
/// </summary>
public static class ServiceCollectionSwaggerExtension
{
    /// <summary>
    /// Adds Swagger configuration.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection" />.</param>
    /// <param name="configuration"><see cref="IConfiguration" /> of the application.</param>
    public static void AddSwaggerConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var azureAdConfig = configuration.GetSection(ApiConstants.Configurations.AzureAd).Get<AzureAdSetting>();
        var swaggerConfig = configuration.GetSection(ApiConstants.Configurations.Swagger).Get<SwaggerSetting>();

        var createOpenApiInfo = CreateOpenApiInfo(swaggerConfig);
        var createSecurityDefinition = CreateSecurityScheme(azureAdConfig, swaggerConfig);
        var createSecurityRequirement = CreateOpenApiSecurityRequirement(swaggerConfig);

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(swaggerConfig.Version, createOpenApiInfo);
            c.DescribeAllParametersInCamelCase();
            c.AddSecurityDefinition(swaggerConfig.AuthType, createSecurityDefinition);
            c.AddSecurityRequirement(createSecurityRequirement);
        });
    }
    
    private static OpenApiInfo CreateOpenApiInfo(SwaggerSetting swaggerConfig)
    {
        return new OpenApiInfo
        {
            Title = swaggerConfig.Title,
            Version = swaggerConfig.Version
        };
    }
    
    private static OpenApiSecurityScheme CreateSecurityScheme(
        AzureAdSetting azureCommonConfig,
        SwaggerSetting swaggerConfig)
    {
        return new OpenApiSecurityScheme
        {
            Name = swaggerConfig.AuthType,
            Type = SecuritySchemeType.OAuth2,
            Description = swaggerConfig.Description,
            Flows = new OpenApiOAuthFlows
            {
                Implicit = new OpenApiOAuthFlow()
                {
                    AuthorizationUrl = new Uri(string.Format(swaggerConfig.AuthUrlFormat, azureCommonConfig.TenantId), UriKind.RelativeOrAbsolute),
                    Scopes =
                    {
                        { swaggerConfig.Scope, swaggerConfig.AuthScope }
                    }
                }
            }
        };
    }

    private static OpenApiSecurityRequirement CreateOpenApiSecurityRequirement(SwaggerSetting swaggerConfig)
    {
        return new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = swaggerConfig.AuthType
                    }
                },
                new List<string> { swaggerConfig.AuthScope }
            }
        };
    }
}