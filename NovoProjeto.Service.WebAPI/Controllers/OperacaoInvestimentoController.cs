using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovoProjeto.Application.Interfaces;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Input;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace NovoProjeto.Service.WebAPI.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class OperacaoInvestimentoController : ControllerBase
    {
        private readonly IOperacaoInvestimentoAppService _operacaoInvestimentoAppService;

        public OperacaoInvestimentoController( IOperacaoInvestimentoAppService operacaoInvestimentoAppService )
        {
            _operacaoInvestimentoAppService = operacaoInvestimentoAppService;
        }

        /// <summary>
        /// Criar uma Operação de investimento.
        /// </summary>
        [HttpPost]
        [Route( "novaOperacaoInvestimento" )]
        [Produces( "application/json" )]
        [SwaggerOperation( "Nova operação de investimento" )]
        [ProducesResponseType( typeof( bool ), StatusCodes.Status200OK )]
        [ProducesResponseType( typeof( bool ), StatusCodes.Status400BadRequest )]
        public async Task<IActionResult> NovaOperacaoInvestimento( OperacaoInvestimentoInput input )
        {
            var novaOperacaoInvestimento = await _operacaoInvestimentoAppService.NovaOperacaoInvestimento( input );

            if( !novaOperacaoInvestimento )
            {
                return BadRequest( false );
            }
            return Ok( true );

        }
    }
}
