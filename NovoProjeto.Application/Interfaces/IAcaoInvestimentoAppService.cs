using NovoProjeto.Infra.CrossCutting.Util.ViewEntity;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Input;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Output;
using System.Threading.Tasks;

namespace NovoProjeto.Application.Interfaces
{
    public interface IAcaoInvestimentoAppService : IBaseAppService<AcaoInvestimentoViewEntity>
    {
        Task<AcoesDisponiveisOutput> ListarAcoesDisponiveis();
        Task<bool> IncluirNovaAcaoInvestimento( AcaoInvestimentoInput input );
    }
}
