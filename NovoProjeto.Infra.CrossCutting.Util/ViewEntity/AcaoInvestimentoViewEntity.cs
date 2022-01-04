namespace NovoProjeto.Infra.CrossCutting.Util.ViewEntity
{
    public class AcaoInvestimentoViewEntity : BaseViewEntity
    {
        public string RazaoSocial { get; set; }
        public string TipoOperacao { get; set; }
        public decimal ValorAcao { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotalOperacao { get; set; }
    }
}
