using NovoProjeto.Infra.CrossCutting.Util.DataEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovoProjeto.Domain.Interface.Service
{
    public interface IFinanceInfraService
    {
        Task<List<AcaoInvestimentoDataEntity>> ListarAcoes();
    }
}
