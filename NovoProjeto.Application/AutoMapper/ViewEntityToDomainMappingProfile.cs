using AutoMapper;
using NovoProjeto.Domain.Models;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity;

namespace NovoProjeto.Application.AutoMapper
{
    class ViewEntityToDomainMappingProfile : Profile
    {
        public ViewEntityToDomainMappingProfile()
        {
            CreateMap<AcaoInvestimentoViewEntity, AcaoInvestimento>();
            CreateMap<OperacaoInvestimentoViewEntity, OperacaoInvestimento>();
        }
    }
}
