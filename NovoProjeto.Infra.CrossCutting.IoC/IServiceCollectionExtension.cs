using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NovoProjeto.Application.AutoMapper;
using NovoProjeto.Application.Interfaces;
using NovoProjeto.Application.Services;
using NovoProjeto.Domain.Interface.Repository;
using NovoProjeto.Domain.Interface.Service.RequestService;
using NovoProjeto.Domain.Models;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity;
using NovoProjeto.Infra.Data.Context;
using NovoProjeto.Infra.Data.Repository;
using NovoProjeto.Infra.Service.RequestService;

namespace NovoProjeto.Infra.CrossCutting.IoC
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection NovoProjetoSetup( this IServiceCollection services )
        {
            // Application
            services
                .AddScoped<IBaseAppService<AcaoInvestimentoViewEntity>, BaseAppService<AcaoInvestimento, AcaoInvestimentoViewEntity>>()
                .AddScoped<IBaseAppService<OperacaoInvestimentoViewEntity>, BaseAppService<OperacaoInvestimento, OperacaoInvestimentoViewEntity>>()
                .AddScoped<IBaseAppService<RelatorioOperacaoInvestimentoViewEntity>, BaseAppService<OperacaoInvestimento, RelatorioOperacaoInvestimentoViewEntity>>();

            services
                .AddScoped<IAcaoInvestimentoAppService, AcaoInvestimentoAppService>()
                .AddScoped<IOperacaoInvestimentoAppService, OperacaoInvestimentoAppService>()
                .AddScoped<IRelatorioOperacaoInvestimentoAppService, RelatorioOperacaoInvestimentoAppService>();

            services.AddAutoMapperSetup();

            // Infra - Service
            services.AddHttpClient();
            services.AddScoped<IFinanceRequestService, FinanceRequestService>();

            // Infra - Data
            services
                .AddScoped<IBaseRepository<AcaoInvestimento>, BaseRepository<AcaoInvestimento>>()
                .AddScoped<IBaseRepository<OperacaoInvestimento>, BaseRepository<OperacaoInvestimento>>();

            services
                .AddScoped<IAcaoInvestimentoRepository, AcaoInvestimentoRepository>()
                .AddScoped<IOperacaoInvestimentoRepository, OperacaoInvestimentoRepository>();

            services.AddDbContext<NovoProjetoContext>( x => x.UseSqlServer( "Server=DESKTOP-7T9SAE6\\SQLEXPRESS;Database=NovoProjeto;Trusted_Connection=True;MultipleActiveResultSets=true" ) );

            return services;
        }
    }
}
