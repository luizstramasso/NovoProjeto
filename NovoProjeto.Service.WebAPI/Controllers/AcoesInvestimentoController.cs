using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovoProjeto.Application.Interfaces;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Input;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovoProjeto.Service.WebAPI.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class AcoesInvestimentoController : ControllerBase
    {
        private readonly IAcaoInvestimentoAppService _acaoInvestimentoAppService;

        public AcoesInvestimentoController( IAcaoInvestimentoAppService acaoInvestimentoAppService )
        {
            _acaoInvestimentoAppService = acaoInvestimentoAppService;
        }

        /// <summary>
        /// Consulta uma lista de ações disponíveis para investimento
        /// </summary>
        [HttpGet]
        [Route( "listarCotacoes" )]
        [Produces( "application/json" )]
        [SwaggerOperation( "Listar Cotações" )]
        [ProducesResponseType( typeof( List<AcaoDisponivelViewEntity> ), StatusCodes.Status200OK )]
        [ProducesResponseType( typeof( List<ErroViewEntity> ), StatusCodes.Status400BadRequest )]
        public async Task<IActionResult> ListarCotacoes()
        {
            var listaCotacoes = await _acaoInvestimentoAppService.ListarAcoesDisponiveis();

            if( listaCotacoes.TemErros() )
            {
                return BadRequest( listaCotacoes.Erros );
            }

            return Ok( listaCotacoes.AcoesDisponiveis );
        }

        /// <summary>
        /// Cadastrar uma nova ação para investimento
        /// </summary>
        [HttpPost]
        [Route( "novaAcao" )]
        [Produces( "application/json" )]
        [SwaggerOperation( "Adiciona Nova Acao" )]
        //[ProducesResponseType( typeof( List<AcaoDisponivelViewEntity> ), StatusCodes.Status200OK )]
        //[ProducesResponseType( typeof( List<ErroViewEntity> ), StatusCodes.Status400BadRequest )]
        public async Task<IActionResult> NovaAcaoInvestimento( AcaoInvestimentoInput input )
        {
            try
            {
                var novaAcao = await _acaoInvestimentoAppService.IncluirNovaAcaoInvestimento( input );

                if( !novaAcao )
                {
                    return BadRequest( "erro ao processar a solicitação" );
                }
                return Ok( novaAcao );
            }
            catch( Exception ex )
            {
                return BadRequest( "erro ao processar a solicitação: " + ex.Message );
            }
        }
    }
}
