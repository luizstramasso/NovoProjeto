namespace NovoProjeto.Infra.CrossCutting.Util.ViewEntity
{
    public class AcaoDisponivelViewEntity : BaseViewEntity
    {
        public string RazaoSocial { get; set; }
        public string CodigoAcao { get; set; }
        public double PrecoAcao { get; set; }
        public string MoedaCorrente { get; set; }
    }
}
