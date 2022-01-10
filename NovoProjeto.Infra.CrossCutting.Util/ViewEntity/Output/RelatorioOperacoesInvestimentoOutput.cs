using System.Collections.Generic;

namespace NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Output
{
    public class RelatorioOperacoesInvestimentoOutput : BaseOutput
    {
        public List<OperacaoInvestimentoOutput> AcoesDisponiveis { get; set; } = new List<OperacaoInvestimentoOutput>();
    }
}
