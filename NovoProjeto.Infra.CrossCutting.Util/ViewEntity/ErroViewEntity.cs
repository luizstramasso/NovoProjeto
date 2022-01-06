namespace NovoProjeto.Infra.CrossCutting.Util.ViewEntity
{
    public class ErroViewEntity
    {
        public string Mensagem { get; set; }
        public string NemaSpace { get; set; }

        public ErroViewEntity()
        {

        }
        public ErroViewEntity( string mensagem, string nsameSpace )
        {
            Mensagem = mensagem;
            NemaSpace = nsameSpace;
        }
    }
}
