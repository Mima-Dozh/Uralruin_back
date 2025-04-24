using Microsoft.EntityFrameworkCore;
using FluentValidation;
using WebApplication2.Dao;
using Uralruin_back.Middleware;
using System.Text.Json.Serialization;
using Uralruin_back.Infrastructure.IRepositories;
using Uralruin_back.Infrastructure.Repositories;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContextFactory<AppDbContext>();

        services.AddScoped<IMapObjectRepository, MapObjectRepository>();
        services.AddScoped<IMapRouteRepository, MapRouteRepository>();

        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        services.AddSwaggerGen();

        services.Configure<ConfigDemo>(_configuration.GetSection(nameof(ConfigDemo)));

        services.AddScoped<IValidator<WeatherForecast>, WeatherForecastValidator>();
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseRouting();

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}