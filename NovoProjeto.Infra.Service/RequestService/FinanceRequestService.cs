using Newtonsoft.Json;
using NovoProjeto.Domain.Interface.Service.RequestService;
using NovoProjeto.Infra.CrossCutting.Util.HelpEntity;
using NovoProjeto.Infra.CrossCutting.Util.ServiceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NovoProjeto.Infra.Service.RequestService
{
    public class FinanceRequestService : IFinanceRequestService
    {
        private readonly IHttpClientFactory _clientFactory;

        public FinanceRequestService( IHttpClientFactory clientFactory )
        {
            _clientFactory = clientFactory;
        }

        public async Task<AcoesDisponiveisServiceEntity> ListarAcoesDisponiveis()
        {
            var acoesDisponiveis = new AcoesDisponiveisServiceEntity();
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
                    var rootObj = JsonConvert.DeserializeObject<ResponseYahooHelpEntity>( responseString );
                    var listaAcoes = new List<AcaoDisponivelServiceEntity>();

                    foreach( var item in rootObj.QuoteResponse.Result )
                    {
                        listaAcoes.Add( new AcaoDisponivelServiceEntity()
                        {
                            CodigoAcao = item.Symbol,
                            PrecoAcao = item.RegularMarketPrice,
                            RazaoSocial = item.LongName,
                            MoedaCorrente = item.Currency
                        } );
                    }

                    if( listaAcoes.Any() )
                    {
                        acoesDisponiveis.AcoesDisponiveis = listaAcoes;
                    }
                }
                else
                {
                    acoesDisponiveis.Erros = new List<ErroHelpEntity>() { new ErroHelpEntity( "Erro ao solicitar ações disponíveis. Status de requisição: " + response.StatusCode.ToString(), this.GetType() ) };
                }
            }
            catch( Exception ex )
            {
                acoesDisponiveis.Erros = new List<ErroHelpEntity>() { new ErroHelpEntity( ex.Message, this.GetType() ) };
            }
            finally
            {
                client.Dispose();
            }

            return acoesDisponiveis;
        }
    }
}
