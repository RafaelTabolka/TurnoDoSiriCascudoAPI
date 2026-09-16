using FluentValidation;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.PapelAdmin
{
    internal class UsuarioPapelAdminValidation : AbstractValidator<UsuarioPapelAdminRequest>
    {
        public UsuarioPapelAdminValidation()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
