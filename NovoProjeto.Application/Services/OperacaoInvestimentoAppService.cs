using AutoMapper;
using NovoProjeto.Application.Interfaces;
using NovoProjeto.Domain.Interface.Repository;
using NovoProjeto.Domain.Interface.Service.RequestService;
using NovoProjeto.Domain.Models;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Input;
using System.Linq;
using System.Threading.Tasks;

namespace NovoProjeto.Application.Services
{
    public class OperacaoInvestimentoAppService : BaseAppService<OperacaoInvestimento, OperacaoInvestimentoViewEntity>, IOperacaoInvestimentoAppService
    {
        private readonly IAcaoInvestimentoAppService _acaoInvestimentoAppService;
        private readonly IFinanceRequestService _financeRequestService;

        public OperacaoInvestimentoAppService( IMapper mapper, IBaseRepository<OperacaoInvestimento> repository,
            IAcaoInvestimentoAppService acaoInvestimentoAppService, IFinanceRequestService financeRequestService ) : base( mapper, repository )
        {
            _acaoInvestimentoAppService = acaoInvestimentoAppService;
            _financeRequestService = financeRequestService;
        }

        public async Task<bool> NovaOperacaoInvestimento( OperacaoInvestimentoInput input )
        {
            var acaoInvestimento = _acaoInvestimentoAppService
                .Listar()
                .Where( x => x.CodigoAcao == input.CodigoAcao )
                .FirstOrDefault();

            if( acaoInvestimento == default )
            {
                return false;
            }

            var dadosYahoo = await _financeRequestService.ConsultarAcoesYahoo();
            var dadosAtuaisAcao = dadosYahoo.AcoesDisponiveis
                .Where( x => x.CodigoAcao == input.CodigoAcao )
                .FirstOrDefault();

            if( dadosAtuaisAcao == default )
            {
                return false;
            }

            var conversaoMoeda = await _financeRequestService.ConverterMoedaParaReal( dadosAtuaisAcao.MoedaCorrente );
            var valorTotalOpercao = _financeRequestService.CalculoTotalOperacao( input, conversaoMoeda, dadosAtuaisAcao.PrecoAcao );


            var novaOperacaoInvestimento = new OperacaoInvestimentoViewEntity()
            {
                CodigoAcao = acaoInvestimento.CodigoAcao,
                RazaoSocial = acaoInvestimento.RazaoSocial,
                TipoOperacao = input.TipoOperacao,
                ValorAcao = dadosAtuaisAcao.PrecoAcao * conversaoMoeda,
                Quantidade = input.QuantidadeAcoes,
                MoedaCorrente = "BRL",
                ValorTotalOperacao = valorTotalOpercao
            };

            return base.Incluir( novaOperacaoInvestimento );
        }
    }
}