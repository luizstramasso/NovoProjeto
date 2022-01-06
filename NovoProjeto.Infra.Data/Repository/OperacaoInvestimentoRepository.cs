using NovoProjeto.Domain.Interface.Repository;
using NovoProjeto.Domain.Models;
using NovoProjeto.Infra.Data.Context;

namespace NovoProjeto.Infra.Data.Repository
{
    public class OperacaoInvestimentoRepository : BaseRepository<OperacaoInvestimento>, IOperacaoInvestimentoRepository
    {
        public OperacaoInvestimentoRepository( NovoProjetoContext context ) : base( context )
        {
        }
    }
}
