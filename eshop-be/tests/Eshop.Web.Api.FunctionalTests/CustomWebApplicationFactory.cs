using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace Eshop.Web.Api.FunctionalTests;

/// <summary>
/// <inheritdoc/>
/// </summary>
public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    /// <summary>
    /// <inheritdoc />
    /// </summary>
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var host = builder.Build();
        host.Start();

        // Get service provider.
        // var serviceProvider = host.Services;

        // Create a scope to obtain a reference to the database


        return host;
    }

    /// <summary>
    /// <inheritdoc />
    /// </summary>
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //builder
        //    .ConfigureServices(services =>
        //    {
        //        // Remove the app's ApplicationDbContext registration.
        //        var descriptor = services.SingleOrDefault(
        //    d => d.ServiceType ==
        //        typeof(DbContextOptions<AppDbContext>));

        //        if (descriptor != null)
        //        {
        //            services.Remove(descriptor);
        //        }

        //        // This should be set for each individual test run
        //        string inMemoryCollectionName = Guid.NewGuid().ToString();

        //        // Add ApplicationDbContext using an in-memory database for testing.
        //        services.AddDbContext<AppDbContext>(options =>
        //        {
        //            options.UseInMemoryDatabase(inMemoryCollectionName);
        //        });

        //        services.AddScoped<IMediator, NoOpMediator>();
        //    });
    }
}