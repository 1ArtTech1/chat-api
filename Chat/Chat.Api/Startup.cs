using System.Reflection;
using Chat.Api.Constants;
using Chat.Api.Extensions;
using Chat.Application.Extensions;
using Chat.Application.Mappers;
using Chat.Application.Providers;
using Chat.Application.Providers.Interfaces;
using Chat.Application.Services;
using Chat.Application.Services.Interfaces;
using Chat.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Chat.Api;

public class Startup
{
    private IConfiguration configuration { get; }

    public Startup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddSwaggerConfiguration(configuration);
        services.ConfigureCorsForOrigins(configuration);
        services.AddAzureAdAuthentication(configuration);
        services.AddSignalR();
        services.AddDbContext<DataBaseContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(ApiConstants.Configurations.SqlConnectionString)), ServiceLifetime.Singleton);
        services.SetupApplicationDependencyInjection();
        services.SetupApiDependencyInjection();
        services.AddAutoMapper(Assembly.GetExecutingAssembly(), typeof(MappingProfile).Assembly);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.SetupApplicationBuilder(env);
    }
}