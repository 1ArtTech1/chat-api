using Chat.Api.Constants;
using Chat.Api.Hubs;
using Chat.Application.Services;
using Chat.Application.Services.Interfaces;

namespace Chat.Api.Extensions;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionDiExtension
{
    /// <summary>
    /// Adds Dependency Injection.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection" />.</param>
    public static void SetupApiDependencyInjection(this IServiceCollection services)
    {
        var transactionService = new TransactionService();
        services.AddSingleton<ITransactionService, TransactionService>(_ =>  transactionService);
        services.AddHostedService(_ => transactionService);
    }

    /// <summary>
    /// Extension methods for <see cref="IApplicationBuilder"/>.
    /// </summary>
    /// <param name="app"><see cref="IApplicationBuilder" />.</param>
    /// <param name="env"><see cref="IWebHostEnvironment" />.</param>
    public static void SetupApplicationBuilder(
        this IApplicationBuilder app,
        IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1"); });
        }
        else
        {
            app.UseExceptionHandler("/error");
            app.UseHsts();
        }
        
        app.UseCors(ApiConstants.Configurations.CorsPolicyName);

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHub<ChatHub>("/chat");
            endpoints.MapHub<MessageHub>("/message");
        });
    }
}