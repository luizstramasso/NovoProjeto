namespace NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Input
{
    public class OperacaoInvestimentoInput : BaseInvestimentoInput
    {
        public int QuantidadeAcoes { get; set; }
        public string TipoOperacao { get; set; }
    }
}
