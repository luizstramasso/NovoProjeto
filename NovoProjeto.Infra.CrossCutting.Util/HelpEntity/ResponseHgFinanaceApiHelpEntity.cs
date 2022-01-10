using Newtonsoft.Json;
using System.Collections.Generic;

namespace NovoProjeto.Infra.CrossCutting.Util.HelpEntity
{
    public class ResponseHgFinanaceApiHelpEntity
    {
        [JsonProperty( "results" )]
        public Results Results { get; set; }
    }
    public class Results
    {
        [JsonProperty( "currencies" )]
        public Currencies Currencies { get; set; }
    }
    public class Currencies
    {
        [JsonProperty( "USD" )]
        public USD USD { get; set; }

        [JsonProperty( "EUR" )]
        public EUR EUR { get; set; }

        [JsonProperty( "GBP" )]
        public GBP GBP { get; set; }

        [JsonProperty( "ARS" )]
        public ARS ARS { get; set; }

        [JsonProperty( "CAD" )]
        public CAD CAD { get; set; }

        [JsonProperty( "AUD" )]
        public AUD AUD { get; set; }

        [JsonProperty( "JPY" )]
        public JPY JPY { get; set; }

        [JsonProperty( "CNY" )]
        public CNY CNY { get; set; }

        [JsonProperty( "BTC" )]
        public BTC BTC { get; set; }

        public List<Currency> CurrenciesList { get; set; }

        public List<Currency> ConversaoParaLista( Currencies currencies )
        {
            var currrenciesList = new List<Currency>();

            currrenciesList.Add( new Currency( "USD", currencies.USD.Name, currencies.USD.Buy ) );
            currrenciesList.Add( new Currency( "EUR", currencies.EUR.Name, currencies.EUR.Buy ) );
            currrenciesList.Add( new Currency( "GBP", currencies.GBP.Name, currencies.GBP.Buy ) );
            currrenciesList.Add( new Currency( "ARS", currencies.ARS.Name, currencies.ARS.Buy ) );
            currrenciesList.Add( new Currency( "CAD", currencies.CAD.Name, currencies.CAD.Buy ) );
            currrenciesList.Add( new Currency( "AUD", currencies.AUD.Name, currencies.AUD.Buy ) );
            currrenciesList.Add( new Currency( "JPY", currencies.JPY.Name, currencies.JPY.Buy ) );
            currrenciesList.Add( new Currency( "CNY", currencies.CNY.Name, currencies.CNY.Buy ) );
            currrenciesList.Add( new Currency( "BTC", currencies.BTC.Name, currencies.BTC.Buy ) );

            return currrenciesList;
        }
    }

    #region [ Auxiliares de conversão HgFinanceApi ]
    public class USD
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "buy" )]
        public double Buy { get; set; }

        [JsonProperty( "sell" )]
        public double Sell { get; set; }

        [JsonProperty( "variation" )]
        public double Variation { get; set; }
    }
    public class EUR
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "buy" )]
        public double Buy { get; set; }

        [JsonProperty( "sell" )]
        public double Sell { get; set; }

        [JsonProperty( "variation" )]
        public double Variation { get; set; }
    }
    public class GBP
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "buy" )]
        public double Buy { get; set; }

        [JsonProperty( "sell" )]
        public object Sell { get; set; }

        [JsonProperty( "variation" )]
        public double Variation { get; set; }
    }
    public class ARS
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "buy" )]
        public double Buy { get; set; }

        [JsonProperty( "sell" )]
        public object Sell { get; set; }

        [JsonProperty( "variation" )]
        public double Variation { get; set; }
    }
    public class CAD
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "buy" )]
        public double Buy { get; set; }

        [JsonProperty( "sell" )]
        public object Sell { get; set; }

        [JsonProperty( "variation" )]
        public double Variation { get; set; }
    }
    public class AUD
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "buy" )]
        public double Buy { get; set; }

        [JsonProperty( "sell" )]
        public object Sell { get; set; }

        [JsonProperty( "variation" )]
        public double Variation { get; set; }
    }
    public class JPY
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "buy" )]
        public double Buy { get; set; }

        [JsonProperty( "sell" )]
        public object Sell { get; set; }

        [JsonProperty( "variation" )]
        public double Variation { get; set; }
    }
    public class CNY
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "buy" )]
        public double Buy { get; set; }

        [JsonProperty( "sell" )]
        public object Sell { get; set; }

        [JsonProperty( "variation" )]
        public double Variation { get; set; }
    }
    public class BTC
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "buy" )]
        public double Buy { get; set; }

        [JsonProperty( "sell" )]
        public double Sell { get; set; }

        [JsonProperty( "variation" )]
        public double Variation { get; set; }
    }
    public class Currency
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }

        public Currency( string codigo, string nome, double valor )
        {
            Codigo = codigo;
            Nome = nome;
            Valor = valor;
        }
    }
    #endregion [ Auxiliares de conversão HgFinanceApi ]
}
