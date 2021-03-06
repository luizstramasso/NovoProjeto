using AutoMapper;
using NovoProjeto.Application.Interfaces;
using NovoProjeto.Domain.Interface.Repository;
using NovoProjeto.Domain.Interface.Service.RequestService;
using NovoProjeto.Domain.Models;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Input;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovoProjeto.Application.Services
{
    public class AcaoInvestimentoAppService : BaseAppService<AcaoInvestimento, AcaoInvestimentoViewEntity>, IAcaoInvestimentoAppService
    {
        private readonly IFinanceRequestService _financeInfraService;


        public AcaoInvestimentoAppService( IMapper mapper, IBaseRepository<AcaoInvestimento> repository, IFinanceRequestService financeInfraService )
            : base( mapper, repository )
        {
            _financeInfraService = financeInfraService;
        }

        public Task<bool> IncluirNovaAcaoInvestimento( AcaoInvestimentoInput input )
        {
            var novaAcaoViewEntity = new AcaoInvestimentoViewEntity()
            {
                CodigoAcao = input.CodigoAcao,
                RazaoSocial = input.RazaoSocial
            };

            return Task.FromResult( base.Incluir( novaAcaoViewEntity ) );
        }

        public async Task<AcoesDisponiveisOutput> ListarAcoesDisponiveis()
        {


            var dataEntity = await _financeInfraService.ConsultarAcoesYahoo();

            var listaAcoes = new List<AcaoDisponivelViewEntity>();
            var listaErros = new List<ErroViewEntity>();
            var retorno = new AcoesDisponiveisOutput();

            if( dataEntity.TemErros() )
            {
                foreach( var item in dataEntity.Erros )
                {
                    listaErros.Add( new ErroViewEntity( item.Mensagem, item.NemaSpace ) );
                }

                retorno.Erros = listaErros;
            }
            else
            {
                foreach( var item in dataEntity.AcoesDisponiveis )
                {
                    listaAcoes.Add( new AcaoDisponivelViewEntity()
                    {
                        RazaoSocial = item.RazaoSocial,
                        PrecoAcao = item.PrecoAcao,
                        CodigoAcao = item.CodigoAcao,
                        MoedaCorrente = item.MoedaCorrente
                    } );
                }

                retorno.AcoesDisponiveis = listaAcoes;
            }

            return retorno;
        }
    }
}