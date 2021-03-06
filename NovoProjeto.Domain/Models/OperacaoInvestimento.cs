using NovoProjeto.Domain.Models.Enums;

namespace NovoProjeto.Domain.Models
{
    public class OperacaoInvestimento : BaseEntity
    {
        public string CodigoAcao { get; set; }
        public string RazaoSocial { get; set; }
        public TipoOperacaoEnum TipoOperacao { get; set; }
        public decimal ValorAcao { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotalOperacao { get; set; }
    }
}
