using KeeneticClientSwitch.Data.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");

CreateHostBuilder(args).Build().Run();

IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddDbContext<LocalContext>(options =>
            {
                options.UseSqlite("Data Source=:memory:");
            });
        });
}