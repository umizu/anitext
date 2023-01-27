using Anitext.Api.Options;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Anitext.Api.Registrars;

public static class SwaggerRegistrar
{
    public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });
        services.ConfigureOptions<ConfigureSwaggerOptions>()
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();
        return services;
    }

    public static void UseSwaggerServices(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(o =>
        {
            var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

            foreach (var description in provider.ApiVersionDescriptions)
            {
                o.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.ApiVersion.ToString());
            }
        });
    }
}
