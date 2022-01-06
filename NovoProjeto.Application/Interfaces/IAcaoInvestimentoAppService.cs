using NovoProjeto.Infra.CrossCutting.Util.ViewEntity;
using System.Threading.Tasks;

namespace NovoProjeto.Application.Interfaces
{
    public interface IAcaoInvestimentoAppService : IBaseAppService<AcaoInvestimentoViewEntity>
    {
        Task<AcoesDisponiveiRetorno> ListarAcoesDisponiveis();
    }
}
