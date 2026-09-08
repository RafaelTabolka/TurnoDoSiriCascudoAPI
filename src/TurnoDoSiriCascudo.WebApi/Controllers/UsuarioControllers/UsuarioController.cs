using MediatR;
using Microsoft.AspNetCore.Mvc;
using TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Criar;

namespace TurnoDoSiriCascudo.WebApi.Controllers.UsuarioControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(ISender mediator) : ControllerBase
    {
        [HttpPost("criar")]
        public async Task<IActionResult> CriarUsuario(UsuarioCriarRequest request)
        {
            var response = await mediator.Send(request);

            return Created("Criado", response);
        }
    }
}
