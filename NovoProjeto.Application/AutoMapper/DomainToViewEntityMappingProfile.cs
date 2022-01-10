using AutoMapper;
using NovoProjeto.Domain.Models;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity;

namespace NovoProjeto.Application.AutoMapper
{
    class DomainToViewEntityMappingProfile : Profile
    {
        public DomainToViewEntityMappingProfile()
        {
            CreateMap<AcaoInvestimento, AcaoInvestimentoViewEntity>();
            CreateMap<OperacaoInvestimento, OperacaoInvestimentoViewEntity>();
        }
    }
}
