using System.Collections.Generic;

namespace NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Output
{
    public class AcoesDisponiveisOutput : BaseOutput
    {
        public List<AcaoDisponivelViewEntity> AcoesDisponiveis { get; set; } = new List<AcaoDisponivelViewEntity>();
    }
}
