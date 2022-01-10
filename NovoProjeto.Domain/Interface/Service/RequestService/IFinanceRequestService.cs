using NovoProjeto.Infra.CrossCutting.Util.ServiceEntity;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Input;
using System.Threading.Tasks;

namespace NovoProjeto.Domain.Interface.Service.RequestService
{
    public interface IFinanceRequestService
    {
        Task<AcoesDisponiveisServiceEntity> ConsultarAcoesYahoo();
        Task<double> ConverterMoedaParaReal( string moedaAcao );
        double CalculoTotalOperacao( OperacaoInvestimentoInput input, double valorMoedaReal, double precoAcao );
    }
}
