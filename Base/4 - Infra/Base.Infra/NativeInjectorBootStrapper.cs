using AutoMapper;
using Base.Aplicacao.Interfaces.ServicosApp;
using Base.Aplicacao.ServicosApp;
using Base.Dados.Repositorios;
using Base.Dominio.Interfaces.Repositorios;
using Base.Dominio.Interfaces.Servicos;
using Base.Dominio.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Base.Infra
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Aplicacao
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            services.AddScoped<IDefaultServicosApp, DefaultServicosApp>();

            // Dominio
            services.AddScoped<IDefaultServicos, DefaultServicos>();

            // Infra
            services.AddScoped<IDefaultRepositorio, DefaultRepositorio>();
        }
    }
}
