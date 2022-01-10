using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Input.Relatorios;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Output;
using System.Threading.Tasks;

namespace NovoProjeto.Application.Interfaces
{
    public interface IRelatorioOperacaoInvestimentoAppService
    {
        Task<RelatorioOperacoesInvestimentoOutput> ObterRelatorioFiltrado( RelatorioOperacaoInvestimentoInput input );
    }
}
