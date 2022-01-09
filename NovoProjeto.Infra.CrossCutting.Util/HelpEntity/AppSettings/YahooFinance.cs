using System.Collections.Generic;

namespace NovoProjeto.Infra.CrossCutting.Util.HelpEntity.AppSettings
{
    public class YahooFinance
    {
        public string Schema { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public int MaxSymbols { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public Dictionary<string, string> Query { get; set; }
    }
}