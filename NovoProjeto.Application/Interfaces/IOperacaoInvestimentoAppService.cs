using NovoProjeto.Infra.CrossCutting.Util.ViewEntity;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Input;
using System.Threading.Tasks;

namespace NovoProjeto.Application.Interfaces
{
    public interface IOperacaoInvestimentoAppService : IBaseAppService<OperacaoInvestimentoViewEntity>
    {
        Task<bool> NovaOperacaoInvestimento( OperacaoInvestimentoInput input );
    }
}
