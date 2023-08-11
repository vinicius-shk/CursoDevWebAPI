using CursoDevWebAPI.Api.Extensions;

namespace CursoDevWebAPI.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "f870a8221726454495c742a8359d84c8";
                o.LogId = new Guid("911b4d67-2c0e-44f4-b40a-06e8c05cbf83");
            });

            services.AddHealthChecks()
                .AddElmahIoPublisher(options =>
                {
                    options.ApiKey = "f870a8221726454495c742a8359d84c8";
                    options.LogId = new Guid("911b4d67-2c0e-44f4-b40a-06e8c05cbf83");
                    options.HeartbeatId = "a00bf14ee51b48babc74f889dcedaaf3";

                })
                .AddCheck("Produtos", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "BancoSQL");

            return services;

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
        }

        public static IApplicationBuilder UseLoggingConfig(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/api/hc");
            app.UseElmahIo();

            return app;
        }
    }
}
