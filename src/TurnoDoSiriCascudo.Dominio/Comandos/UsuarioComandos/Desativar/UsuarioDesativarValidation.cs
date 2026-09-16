using FluentValidation;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Desativar
{
    internal class UsuarioDesativarValidation : AbstractValidator<UsuarioDesativarRequest>
    {
        public UsuarioDesativarValidation()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
