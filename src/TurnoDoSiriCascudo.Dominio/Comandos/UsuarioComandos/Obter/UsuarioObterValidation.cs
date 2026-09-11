using FluentValidation;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Obter
{
    internal class UsuarioObterValidation : AbstractValidator<UsuarioObterRequest>
    {
        public UsuarioObterValidation()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
