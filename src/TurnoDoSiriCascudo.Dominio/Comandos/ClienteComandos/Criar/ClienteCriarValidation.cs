using FluentValidation;

namespace TurnoDoSiriCascudo.Dominio.Comandos.ClienteComandos.Criar
{
    internal class ClienteCriarValidation : AbstractValidator<ClienteCriarRequest>
    {
        public ClienteCriarValidation()
        {
            RuleFor(c => c.NomeCliente)
                .NotEmpty().WithMessage("Nome do cliente não pode ser vazio")
                .MaximumLength(100).WithMessage("Máximo de 100 caracteres atingido");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("Telefone não pode ser vazio")
                .MaximumLength(11).WithMessage("Máximo de 11 caracteres");

            RuleFor(c => c.Observacoes)
                .MaximumLength(300).WithMessage("Máximo de 300 caracteres para observações");

            RuleFor(c => c.UsuarioCriadorId)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
