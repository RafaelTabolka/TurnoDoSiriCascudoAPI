using FluentValidation;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Atualizar
{
    internal class UsuarioAtualizarValidation : AbstractValidator<UsuarioAtualizarRequest>
    {
        public UsuarioAtualizarValidation()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");

            RuleFor(u => u.NomeUsuario)
                .NotEmpty().WithMessage("Nome do usuário não pode ser vazio")
                .MaximumLength(150).WithMessage("Máximo de 150 caracteres");
        }
    }
}
