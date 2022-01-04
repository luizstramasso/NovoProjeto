using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoProjeto.Infra.CrossCutting.Util.DataEntity
{
    public class AcaoInvestimentoDataEntity
    {
        public string RazaoSocial { get; set; }
        public string CodigoAcao { get; set; }
        public double PrecoAcao { get; set; }
        public string MoedaCorrente { get; set; }
    }
}
