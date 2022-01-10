using AutoMapper;
using NovoProjeto.Application.Interfaces;
using NovoProjeto.Domain.Interface.Repository;
using NovoProjeto.Domain.Interface.Service.RequestService;
using NovoProjeto.Domain.Models;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Input;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Input.Relatorios;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Output;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoProjeto.Application.Services
{
    public class RelatorioOperacaoInvestimentoAppService : IRelatorioOperacaoInvestimentoAppService
    {
        private readonly IOperacaoInvestimentoAppService _operacaoInvestimentoAppService;

        public RelatorioOperacaoInvestimentoAppService( IOperacaoInvestimentoAppService operacaoInvestimentoAppService )
        {
            _operacaoInvestimentoAppService = operacaoInvestimentoAppService;
        }

        public async Task<RelatorioOperacoesInvestimentoOutput> ObterRelatorioFiltrado( RelatorioOperacaoInvestimentoInput input )
        {
            var filtroValido = new List<string>();


            foreach( var filtro in input.CodigosAcoes )
            {
                if( !string.IsNullOrWhiteSpace( filtro ) )
                {
                    filtroValido.Add( filtro );
                }
            }


            var relatorioRetorno = new RelatorioOperacoesInvestimentoOutput();

            var relatorioFiltrado = await Task.FromResult( _operacaoInvestimentoAppService.Listar()
                .Where( x => filtroValido.Any() ? filtroValido.Contains( x.CodigoAcao ) : true )
                .ToList() );

            foreach( var relatorio in relatorioFiltrado )
            {
                relatorioRetorno.AcoesDisponiveis.Add(
                    new OperacaoInvestimentoOutput()
                    {
                        Codigo = relatorio.CodigoAcao,
                        DataAlteracao = relatorio.DataAlteracao,
                        DataInclusao = relatorio.DataInclusao,
                        ID = relatorio.ID,
                        Quantidade = relatorio.Quantidade,
                        RazaoSocial = relatorio.RazaoSocial,
                        TipoOperacao = relatorio.TipoOperacao,
                        Validacao = relatorio.Validacao,
                        ValorAcao = relatorio.ValorAcao,
                        ValorTotalOperacao = relatorio.ValorTotalOperacao,
                        MoedaOperacao = relatorio.MoedaCorrente ?? "BRL"
                    } );
            }

            return relatorioRetorno;
        }
    }
}