using Microsoft.EntityFrameworkCore;
using DataAccess;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    }).Build();

if (args.Length > 0 && args[0].Equals("migrate", StringComparison.InvariantCultureIgnoreCase))
{
    using var db = new AppDbContext();
    await db.Database.MigrateAsync();
}
else
{
    await host.RunAsync();
}
