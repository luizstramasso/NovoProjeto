namespace NovoProjeto.Infra.CrossCutting.Util.HelpEntity.AppSettings
{
    public class Configuration
    {
        public ExternalRequestUrl ExternalRequestUrl { get; set; }

        public Logging Logging { get; set; }

        public string AllowedHosts { get; set; }

        public InternalVariables InternalVariables { get; set; }


        public HgFinanceApi BuscarHgFinanceApi() => ExternalRequestUrl?.HgFinanceApi;
        public YahooFinance BuscarYahooFinance() => ExternalRequestUrl?.YahooFinance;
        public CalculoOperacao BuscarCalculoOperacao() => InternalVariables?.CalculoOperacao;
    }
}
