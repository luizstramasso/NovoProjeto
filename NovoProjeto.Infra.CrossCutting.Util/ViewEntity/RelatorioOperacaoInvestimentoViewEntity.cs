namespace NovoProjeto.Infra.CrossCutting.Util.ViewEntity
{
    public class RelatorioOperacaoInvestimentoViewEntity : BaseViewEntity
    {
        public string CodigoAcao { get; set; }
        public string RazaoSocial { get; set; }
        public string TipoOperacao { get; set; }
        public double ValorAcao { get; set; }
        public int Quantidade { get; set; }
        public string MoedaCorrente { get; set; } = "BRL";
        public double ValorTotalOperacao { get; set; }
    }
}
