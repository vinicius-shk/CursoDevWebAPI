using Elmah.Io.Extensions.Logging;

namespace CursoDevWebAPI.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "f870a8221726454495c742a8359d84c8";
                o.LogId = new Guid("911b4d67-2c0e-44f4-b40a-06e8c05cbf83");
            });

            // Config para adicionar o Elmah como provider para o logger padrão.
            /*services.AddLogging(builder =>
            {
                builder.AddElmahIo(o =>
                {
                    o.ApiKey = "f870a8221726454495c742a8359d84c8";
                    o.LogId = new Guid("911b4d67-2c0e-44f4-b40a-06e8c05cbf83");
                });
                builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            });*/

            return services;
        }

        public static IApplicationBuilder UseLoggingConfig(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
