using Chat.Api.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

namespace Chat.Api.Extensions;

/// <summary>
/// Authentication extension methods for <see cref="IServiceCollection" />.
/// </summary>
public static class ServiceCollectionAuthenticationExtension
{
    /// <summary>
    /// Adds authentication against Azure AD.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection" />.</param>
    /// <param name="configuration"><see cref="IConfiguration" />.</param>
    public static void AddAzureAdAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(options =>
                {
                    configuration.Bind(ApiConstants.Configurations.AzureAd, options);

                    options.TokenValidationParameters.NameClaimType = ApiConstants.Authentication.NameClaimType;
                },
                options => { configuration.Bind(ApiConstants.Configurations.AzureAd, options); });
    }
}