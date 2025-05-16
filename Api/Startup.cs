using System.Text.Json.Serialization;
using Uralruin_back.Infrastructure.IRepositories;
using Uralruin_back.Infrastructure.Repositories;
using Uralruin_back.Infrastructure.Middleware;
using Microsoft.Extensions.FileProviders;

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

	// В Program.cs или Startup.cs
	app.UseCors(builder => builder
    		.WithOrigins("http://localhost:3000") // Укажите ваш фронтенд-адрес
    		.AllowAnyMethod()
    		.AllowAnyHeader());

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        app.UseStaticFiles();
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Uploads")),
            RequestPath = "/uploads"
        });
    }
}