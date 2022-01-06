using NovoProjeto.Infra.CrossCutting.Util.HelpEntity;
using System.Collections.Generic;
using System.Linq;

namespace NovoProjeto.Infra.CrossCutting.Util.ServiceEntity
{
    public class AcoesDisponiveisServiceEntity
    {
        public List<AcaoDisponivelServiceEntity> AcoesDisponiveis { get; set; } = new List<AcaoDisponivelServiceEntity>();
        public List<ErroHelpEntity> Erros { get; set; } = new List<ErroHelpEntity>();

        public bool TemErros() => Erros.Any();
    }
}