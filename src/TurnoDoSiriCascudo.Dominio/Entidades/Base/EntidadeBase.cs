namespace TurnoDoSiriCascudo.Dominio.Entidades.Base
{
    public class EntidadeBase
    {
        public Guid Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? EditadoEm { get; set; }
    }
}
