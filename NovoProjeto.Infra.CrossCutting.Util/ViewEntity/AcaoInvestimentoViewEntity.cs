namespace NovoProjeto.Infra.CrossCutting.Util.ViewEntity
{
    public class AcaoInvestimentoViewEntity : BaseViewEntity
    {
        public string Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string TipoOperacao { get; set; }
        public double ValorAcao { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotalOperacao { get; set; }
    }
}
