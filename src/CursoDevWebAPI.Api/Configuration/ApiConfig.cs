using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace CursoDevWebAPI.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.Configure<ApiBehaviorOptions>(o =>
            {
                o.SuppressModelStateInvalidFilter = true;
            });

            services.AddCors(o =>
            {
                o.AddPolicy("Development",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

                // Exemplo de politica por ambiente.
                o.AddPolicy("Production",
                    builder => 
                    builder
                        .WithMethods("GET")
                        .WithOrigins("http://meusite.com")
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        //.WithHeaders(HeaderNames.ContentType, "x-custom-header")
                        .AllowAnyHeader());
            });

            return services;
        }

        public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHttpsRedirection();

            return app;
        }
    }
}
