using System.Text.Json.Serialization;
using Uralruin_back.Infrastructure.IRepositories;
using Uralruin_back.Infrastructure.Repositories;
using Uralruin_back.Infrastructure.Middleware;

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