using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace TurnoDoSiriCascudo.Dominio.Comportamentos
{
    public sealed class ValidacaoBehavior<TRequest, TResponse>(
        IEnumerable<IValidator<TRequest>> validadores) :
        IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        public async Task<TResponse> Handle(
            TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Armazena os erros encontrados.
            var erros = new List<ValidationFailure>();

            // Executa os validators encontrados para a request.
            foreach (var validador in validadores)
            {
                var resultado = await validador.ValidateAsync(
                    request,
                    cancellationToken
                );

                erros.AddRange(resultado.Errors);
            }

            // Impede a execução do handler quando existem erros.
            if (erros.Count > 0)
                throw new ValidationException(erros);

            // Continua o fluxo e executa o handler.
            return await next(cancellationToken);
        }
    }
}
