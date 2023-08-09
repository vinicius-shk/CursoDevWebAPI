using CursoDevWebAPI.Api.Extensions;
using CursoDevWebAPI.Business.Intefaces;
using CursoDevWebAPI.Business.Notificacoes;
using CursoDevWebAPI.Business.Services;
using CursoDevWebAPI.Data.Context;
using CursoDevWebAPI.Data.Repository;
using CursoDevWevAPI.Business.Intefaces;

namespace CursoDevWebAPI.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();


            return services;
        }
    }
}
