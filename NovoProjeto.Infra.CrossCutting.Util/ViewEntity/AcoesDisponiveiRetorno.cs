using System.Collections.Generic;
using System.Linq;

namespace NovoProjeto.Infra.CrossCutting.Util.ViewEntity
{
    public class AcoesDisponiveiRetorno
    {
        public List<AcaoDisponivelViewEntity> AcoesDisponiveis { get; set; } = new List<AcaoDisponivelViewEntity>();
        public List<ErroViewEntity> Erros { get; set; } = new List<ErroViewEntity>();

        public bool TemErros() => Erros.Any();
    }
}
