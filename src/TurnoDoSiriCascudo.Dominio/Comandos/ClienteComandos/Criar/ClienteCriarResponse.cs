namespace TurnoDoSiriCascudo.Dominio.Comandos.ClienteComandos.Criar
{
    internal class ClienteCriarResponse(Guid id, string mensagem)
    {
        public Guid Id { get; } = id;
        public string Mensagem { get; } = mensagem;
    }
}
