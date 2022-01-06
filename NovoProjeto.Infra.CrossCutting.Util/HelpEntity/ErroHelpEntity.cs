using System;

namespace NovoProjeto.Infra.CrossCutting.Util.HelpEntity
{
    public class ErroHelpEntity
    {
        public string Mensagem { get; set; }
        public string NemaSpace { get; set; }

        public ErroHelpEntity()
        {

        }
        public ErroHelpEntity( string mensagem, Type type )
        {
            Mensagem = mensagem;
            NemaSpace = type.ToString();
        }
    }
}
