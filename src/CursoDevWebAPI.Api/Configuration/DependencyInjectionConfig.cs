using CursoDevWebAPI.Business.Intefaces;
using CursoDevWebAPI.Data.Context;
using CursoDevWebAPI.Data.Repository;

namespace CursoDevWebAPI.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();


            return services;
        }
    }
}
