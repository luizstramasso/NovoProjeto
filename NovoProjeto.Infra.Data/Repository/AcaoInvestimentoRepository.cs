using NovoProjeto.Domain.Interface.Repository;
using NovoProjeto.Domain.Models;
using NovoProjeto.Infra.Data.Context;

namespace NovoProjeto.Infra.Data.Repository
{
    public class AcaoInvestimentoRepository : BaseRepository<AcaoInvestimento>, IAcaoInvestimentoRepository
    {
        public AcaoInvestimentoRepository( NovoProjetoContext context ) : base( context )
        {
        }
    }
}
