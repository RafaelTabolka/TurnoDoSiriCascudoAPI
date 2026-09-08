namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Criar
{
    internal class UsuarioCriarResponse(Guid id, string token)
    {
        public Guid Id { get; } = id;
        public string Token { get; } = token;
    }
}
