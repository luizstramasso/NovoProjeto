using System;

namespace NovoProjeto.Domain.Models
{
    public abstract class BaseEntity
    {
        public Guid ID { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Validacao { get; set; }
    }
}
