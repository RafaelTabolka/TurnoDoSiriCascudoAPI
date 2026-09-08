using FluentValidation;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Criar
{
    internal class UsuarioCriarValidation : AbstractValidator<UsuarioCriarRequest>
    {
        public UsuarioCriarValidation()
        {
            RuleFor(u => u.NomeUsuario)
                .NotEmpty().WithMessage("Nome do usuário não pode ser vazio")
                .MaximumLength(150).WithMessage("Máximo de 150 caracteres");

            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("Senha não pode ser vazia")
                .MaximumLength(100).WithMessage("Máximo de 100 caracteres")
                .Equal(u => u.ConfirmaSenha)
                .WithMessage("Confirmar senha deve ser igual a senha");
        }
    }
}
