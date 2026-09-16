using MediatR;
using Microsoft.AspNetCore.Mvc;
using TurnoDoSiriCascudo.Dominio.Comandos.ClienteComandos.Criar;

namespace TurnoDoSiriCascudo.WebApi.Controllers.ClienteControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController(ISender mediator) : ControllerBase
    {
        [HttpPost("criar")]
        public async Task<IActionResult> CriarCliente(ClienteCriarRequest request)
        {
            var response = await mediator.Send(request);

            return Created("Criado", response);
        }
    }
}
