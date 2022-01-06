using NovoProjeto.Infra.CrossCutting.Util.ServiceEntity;
using System.Threading.Tasks;

namespace NovoProjeto.Domain.Interface.Service.RequestService
{
    public interface IFinanceRequestService
    {
        Task<AcoesDisponiveisServiceEntity> ListarAcoesDisponiveis();
    }
}
