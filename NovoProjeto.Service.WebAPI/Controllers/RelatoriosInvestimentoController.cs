using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovoProjeto.Application.Interfaces;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Input.Relatorios;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Output;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace NovoProjeto.Service.WebAPI.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class RelatoriosInvestimentoController : ControllerBase
    {
        private readonly IRelatorioOperacaoInvestimentoAppService _relatorioOperacaoInvestimentoAppService;

        public RelatoriosInvestimentoController( IRelatorioOperacaoInvestimentoAppService relatorioOperacaoInvestimentoAppService )
        {
            _relatorioOperacaoInvestimentoAppService = relatorioOperacaoInvestimentoAppService;
        }

        /// <summary>
        /// Extrai relatório de operações de investimento, de acordo com o filtro enviado.
        /// </summary>
        [HttpPost]
        [Route( "relatorioOperacoesInvestimento" )]
        [Produces( "application/json" )]
        [SwaggerOperation( "Nova operação de investimento" )]
        [ProducesResponseType( typeof( RelatorioOperacoesInvestimentoOutput ), StatusCodes.Status200OK )]
        [ProducesResponseType( typeof( bool ), StatusCodes.Status400BadRequest )]
        public async Task<IActionResult> RelatorioOperacoesInvestimento( RelatorioOperacaoInvestimentoInput input )
        {
            var relatorio = await _relatorioOperacaoInvestimentoAppService.ObterRelatorioFiltrado( input );

            if( relatorio.TemErros() )
            {
                return BadRequest( relatorio.Erros );
            }

            return Ok( relatorio );

        }
    }
}
