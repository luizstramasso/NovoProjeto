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
using System;

namespace NovoProjeto.Infra.CrossCutting.IoC
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection NovoProjetoSetup( this IServiceCollection services, Type type )
        {
            // Application
            services
                .AddScoped<IBaseAppService<AcaoInvestimentoViewEntity>, BaseAppService<AcaoInvestimento, AcaoInvestimentoViewEntity>>();

            services
                .AddScoped<IAcaoInvestimentoAppService, AcaoInvestimentoAppService>();

            services.AddAutoMapperSetup( type );

            // Infra - Service
            services.AddHttpClient();
            services.AddScoped<IFinanceRequestService, FinanceRequestService>();

            // Infra - Data
            services
                .AddScoped<IBaseRepository<AcaoInvestimento>, BaseRepository<AcaoInvestimento>>();

            services
                .AddScoped<IAcaoInvestimentoRepository, AcaoInvestimentoRepository>();

            services.AddDbContext<NovoProjetoContext>( x => x.UseInMemoryDatabase( "BancoEmMemoria" ) );

            return services;
        }
    }
}
