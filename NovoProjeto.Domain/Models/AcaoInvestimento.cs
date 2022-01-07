using NovoProjeto.Domain.Models.Enums;

namespace NovoProjeto.Domain.Models
{
    public class AcaoInvestimento : BaseEntity
    {
        public string CodigoAcao { get; set; }
        public string RazaoSocial { get; set; }
    }
}
