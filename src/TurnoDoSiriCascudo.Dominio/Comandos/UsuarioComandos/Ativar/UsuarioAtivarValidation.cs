using FluentValidation;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Ativar
{
    internal class UsuarioAtivarValidation : AbstractValidator<UsuarioAtivarRequest>
    {
        public UsuarioAtivarValidation()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
