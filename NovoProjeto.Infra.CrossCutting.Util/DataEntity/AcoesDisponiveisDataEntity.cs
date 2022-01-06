using NovoProjeto.Infra.CrossCutting.Util.HelpEntity;
using System.Collections.Generic;
using System.Linq;

namespace NovoProjeto.Infra.CrossCutting.Util.DataEntity
{
    public class AcoesDisponiveisDataEntity
    {
        public List<AcaoInvestimentoDataEntity> ListaAcoesDisponiveis { get; set; }
        public List<ErroHelpEntity> Erros { get; set; }

        public bool TemErros() => Erros.Any();
    }
}