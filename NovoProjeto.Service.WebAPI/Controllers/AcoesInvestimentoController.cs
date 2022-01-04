using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovoProjeto.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoProjeto.Service.WebAPI.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class AcoesInvestimentoController : ControllerBase
    {
        private readonly IFinanceInfraService _financeInfraService;

        public AcoesInvestimentoController( IFinanceInfraService financeInfraService )
        {
            _financeInfraService = financeInfraService;
        }

        // GET: lista de acoes disponíveis
        ///<summary>
        ///</summary>
        ///<remarks>
        ///</remarks>
        [HttpGet]
        [Route( "listarAcoes" )]
        public async Task<IActionResult> ListarAcoes()
        {
            var result = await _financeInfraService.ListarAcoes();

            return Ok( result );
        }
    }
}
