using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Core.ApiPipeline.Swagger;

/// <summary>
/// Swagger extensions for add and use openApi versioning
/// </summary>
public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerWithVersions(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddApiVersioning(setup =>
        {
            setup.DefaultApiVersion = new ApiVersion(1, 0);
            setup.AssumeDefaultVersionWhenUnspecified = true;
            setup.ReportApiVersions = true;

        });

        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerWithVersioning(this IApplicationBuilder app)
    {
        IServiceProvider services = app.ApplicationServices;
        var provider = services.GetRequiredService<IApiVersionDescriptionProvider>();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            foreach (var description in provider.ApiVersionDescriptions.Reverse())
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }
        });

        return app;
    }

    public static IServiceCollection AddSwaggerVersioning(this IServiceCollection services)
    {
        services.AddSwaggerGen(setup =>
        {
            setup.EnableAnnotations();
        });
        services.ConfigureOptions<ConfigureSwaggerOptions>();

        return services;
    }
}
