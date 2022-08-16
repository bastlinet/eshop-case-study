using Core.ApiPipeline.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Eshop.Web.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddWebApi(builder.Configuration);

        builder.Services.AddControllers();

        builder.Services.AddSwaggerWithVersions()
            .AddSwaggerVersioning();

        var app = builder.Build();

        app.UseSwaggerWithVersioning();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
