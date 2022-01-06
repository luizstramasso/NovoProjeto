using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovoProjeto.Application.Interfaces;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity;
using Swashbuckle.AspNetCore.Annotations;
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
    }
}
