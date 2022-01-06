using Newtonsoft.Json;
using System.Collections.Generic;

namespace NovoProjeto.Infra.CrossCutting.Util.HelpEntity
{
    public class ResponseYahooHelpEntity
    {
        [JsonProperty( "quoteResponse" )]
        public QuoteResponse QuoteResponse { get; set; }
    }

    public class Result
    {
        [JsonProperty( "longName" )]
        public string LongName { get; set; }

        [JsonProperty( "symbol" )]
        public string Symbol { get; set; }

        [JsonProperty( "regularMarketPrice" )]
        public double RegularMarketPrice { get; set; }

        [JsonProperty( "currency" )]
        public string Currency { get; set; }

    }

    public class QuoteResponse
    {
        [JsonProperty( "result" )]
        public List<Result> Result { get; set; }

        [JsonProperty( "error" )]
        public object Error { get; set; }


        public bool TemErro() => Error == null;
    }
}
