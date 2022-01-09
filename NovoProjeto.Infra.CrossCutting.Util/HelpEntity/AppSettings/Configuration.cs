namespace NovoProjeto.Infra.CrossCutting.Util.HelpEntity.AppSettings
{
    public class Configuration
    {
        public ExternalRequestUrl ExternalRequestUrl { get; set; }

        public Logging Logging { get; set; }

        public string AllowedHosts { get; set; }

        public YahooFinance GetYahooFinanceConfiguration() => ExternalRequestUrl?.YahooFinance;
    }
}
