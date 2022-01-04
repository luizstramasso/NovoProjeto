using AutoMapper;
using NovoProjeto.Application.Interfaces;
using NovoProjeto.Domain.Interface.Repository;
using NovoProjeto.Domain.Models;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity;

namespace NovoProjeto.Application.Services
{
    public class AcaoInvestimentoAppService : BaseAppService<AcaoInvestimento, AcaoInvestimentoViewEntity>, IAcaoInvestimentoAppService
    {
        public AcaoInvestimentoAppService( IMapper mapper, IBaseRepository<AcaoInvestimento> repository )
            : base( mapper, repository )
        { }
    }
}
