using MediatR;
using Microsoft.AspNetCore.Mvc;
using TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Criar;
using TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Listar;
using TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Obter;

namespace TurnoDoSiriCascudo.WebApi.Controllers.UsuarioControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(ISender mediator) : ControllerBase
    {
        [HttpGet("listar")]
        public async Task<IActionResult> ListarUsuarios()
        {
            var request = new UsuarioListarRequest();
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterUsuarioPorId(Guid id)
        {
            var request = new UsuarioObterRequest(id);
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CriarUsuario(UsuarioCriarRequest request)
        {
            var response = await mediator.Send(request);

            return Created("Criado", response);
        }
    }
}
