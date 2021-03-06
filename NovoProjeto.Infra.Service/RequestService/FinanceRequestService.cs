using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NovoProjeto.Domain.Interface.Repository;
using NovoProjeto.Domain.Interface.Service.RequestService;
using NovoProjeto.Infra.CrossCutting.Util.HelpEntity;
using NovoProjeto.Infra.CrossCutting.Util.HelpEntity.AppSettings;
using NovoProjeto.Infra.CrossCutting.Util.ServiceEntity;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Input;
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
        private readonly IAcaoInvestimentoRepository _acaoInvestimentoRepository;
        private readonly Configuration _configuration;


        public FinanceRequestService( IHttpClientFactory clientFactory, IAcaoInvestimentoRepository acaoInvestimentoRepository, IOptions<Configuration> configuration )
        {
            _clientFactory = clientFactory;
            _acaoInvestimentoRepository = acaoInvestimentoRepository;
            _configuration = configuration.Value;
        }

        public async Task<AcoesDisponiveisServiceEntity> ConsultarAcoesYahoo()
        {
            var acoesDisponiveis = new AcoesDisponiveisServiceEntity();
            var endpoint = new UriBuilder();
            var configuration = _configuration.BuscarYahooFinance();

            endpoint.Scheme = configuration.Schema;
            endpoint.Host = configuration.Host;
            endpoint.Path = configuration.Path;

            var maxSymbols = configuration.MaxSymbols;
            var symbols = _acaoInvestimentoRepository.Listar().Take( maxSymbols ).ToList();
            var symbolsToQuery = string.Empty;
            var lastSymbol = symbols.LastOrDefault();

            foreach( var symbol in symbols )
            {
                symbolsToQuery = symbol == lastSymbol ?
                    string.Concat( symbolsToQuery, symbol.CodigoAcao ) :
                    symbolsToQuery = string.Concat( symbolsToQuery, symbol.CodigoAcao, "%2C" );
            }

            var configurationQuery = configuration.Query.ToList();

            var query = string.Empty;
            for( int i = 0 ; i < configurationQuery.Count ; i++ )
            {
                query = string.IsNullOrWhiteSpace( configurationQuery[ i ].Value.ToString() ) ?
                    string.Concat( query, configurationQuery[ i ].Key, "=", symbolsToQuery ) :
                    string.Concat( query, configurationQuery[ i ].Key, "=", configurationQuery[ i ].Value, "&" );
            }

            endpoint.Query = query;

            var request = new HttpRequestMessage( HttpMethod.Get, endpoint.ToString() );

            foreach( var header in configuration.Headers )
            {
                request.Headers.Add( header.Key, header.Value );
            }

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

        public async Task<double> ConverterMoedaParaReal( string moedaAcao )
        {
            var endpoint = new UriBuilder();
            var configuration = _configuration.BuscarHgFinanceApi();
            double retornoCotacaoMoeda = 0.0;

            endpoint.Scheme = configuration.Schema;
            endpoint.Host = configuration.Host;
            endpoint.Path = configuration.Path;
            endpoint.Query = configuration.Key;

            var request = new HttpRequestMessage( HttpMethod.Get, endpoint.ToString() );

            var client = _clientFactory.CreateClient();

            try
            {
                var response = await client.SendAsync( request );

                if( response.IsSuccessStatusCode )
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var rootObj = JsonConvert.DeserializeObject<ResponseHgFinanaceApiHelpEntity>( responseString );
                    var cotacaoMoedaAcao = rootObj.Results.Currencies;

                    retornoCotacaoMoeda = cotacaoMoedaAcao.ConversaoParaLista( cotacaoMoedaAcao ).Where( x => x.Codigo == moedaAcao ).Select( x => x.Valor ).FirstOrDefault();
                }
            }
            catch( Exception )
            {
                return retornoCotacaoMoeda;
            }

            return retornoCotacaoMoeda;
        }

        public double CalculoTotalOperacao( OperacaoInvestimentoInput input, double valorMoedaReal, double precoAcao )
        {
            var valoresCalculoOperacao = _configuration.BuscarCalculoOperacao();
            double custoOperacao = 0.0;
            double valorOrdem = 0.0;
            double valorTotalOperacao = 0.0;

            switch( input.TipoOperacao.ToLower() )
            {
                case "v":
                    valorOrdem = ( input.QuantidadeAcoes * precoAcao * valorMoedaReal );
                    custoOperacao = valoresCalculoOperacao.CustoOperacao + ( valorOrdem * valoresCalculoOperacao.Emolumentos );
                    valorTotalOperacao = valorOrdem - custoOperacao;
                    break;

                case "c":
                    valorOrdem = ( input.QuantidadeAcoes * precoAcao * valorMoedaReal );
                    custoOperacao = valoresCalculoOperacao.CustoOperacao + ( valorOrdem * valoresCalculoOperacao.Emolumentos );
                    valorTotalOperacao = valorOrdem + custoOperacao;
                    break;

                default:
                    break;
            }

            return valorTotalOperacao;
        }
    }
}
