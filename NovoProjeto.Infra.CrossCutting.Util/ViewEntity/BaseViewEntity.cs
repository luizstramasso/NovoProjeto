using System;

namespace NovoProjeto.Infra.CrossCutting.Util.ViewEntity
{
    public abstract class BaseViewEntity
    {
        public Guid ID { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Validacao { get; set; }
    }
}
