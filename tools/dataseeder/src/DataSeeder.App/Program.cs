using DataSeeder.App.Services;
using EshopDb.Dapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DataSeeder.App;

public static class Program
{
    public static async Task Main(string[] args)
    {
        await Host.CreateDefaultBuilder(args)
            .ConfigureServices((ctx, services) =>
            {
                var configuration = ctx.Configuration;

                services.AddDatabase(configuration);
                services.AddLogging(c => c.AddConsole().SetMinimumLevel(LogLevel.Warning));
                services.AddHostedService<DataSeedService>();

            }).RunConsoleAsync();

    }
}