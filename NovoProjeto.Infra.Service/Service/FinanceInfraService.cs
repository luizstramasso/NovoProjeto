using Newtonsoft.Json;
using NovoProjeto.Domain.Interface.Service;
using NovoProjeto.Infra.CrossCutting.Util.DataEntity;
using NovoProjeto.Infra.CrossCutting.Util.HelpEntity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NovoProjeto.Infra.Service.Service
{
    public class FinanceInfraService : IFinanceInfraService
    {
        private readonly IHttpClientFactory _clientFactory;

        public FinanceInfraService( IHttpClientFactory clientFactory )
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<AcaoInvestimentoDataEntity>> ListarAcoes()
        {
            var listaAcoes = new List<AcaoInvestimentoDataEntity>();
            var endpoint = @"https://yfapi.net/v6/finance/quote?region=US&lang=en&symbols=AAPL%2CAMZN%2CGOOG%2CFB%2CTSLA%2CNFLX%2CIBM";
            var request = new HttpRequestMessage( HttpMethod.Get, endpoint );
            request.Headers.Add( "accept", " application/json" );
            request.Headers.Add( "X-API-KEY", "OzeRJXB0Gsa4Qk90oCtrG92AUlqqVSUPaTjgDFVM" );

            var client = _clientFactory.CreateClient();
            try
            {

                var response = await client.SendAsync( request );

                if( response.IsSuccessStatusCode )
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var rootObj = JsonConvert.DeserializeObject<ResponseYahooEntity>( responseString );

                    foreach( var item in rootObj.QuoteResponse.Result )
                    {
                        listaAcoes.Add( new AcaoInvestimentoDataEntity()
                        {
                            CodigoAcao = item.Symbol,
                            PrecoAcao = item.RegularMarketPrice,
                            RazaoSocial = item.LongName,
                            MoedaCorrente = item.Currency
                        } );
                    }
                }
            }
            catch( Exception )
            {

                throw;
            }

            return listaAcoes;
        }
    }


}
