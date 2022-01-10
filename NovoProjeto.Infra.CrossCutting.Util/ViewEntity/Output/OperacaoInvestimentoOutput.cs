namespace NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Output
{
    public class OperacaoInvestimentoOutput : BaseOutput
    {
        public string Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string TipoOperacao { get; set; }
        public double ValorAcao { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotalOperacao { get; set; }
    }
}
