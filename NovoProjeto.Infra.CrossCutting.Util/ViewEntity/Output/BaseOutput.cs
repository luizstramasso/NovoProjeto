using System;
using System.Collections.Generic;
using System.Linq;

namespace NovoProjeto.Infra.CrossCutting.Util.ViewEntity.Output
{
    public abstract class BaseOutput
    {
        public Guid ID { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Validacao { get; set; }
        public List<ErroViewEntity> Erros { get; set; } = new List<ErroViewEntity>();

        public bool TemErros() => Erros.Any();
    }
}
