using MediatR;
using Microsoft.AspNetCore.Mvc;
using TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Ativar;
using TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Atualizar;
using TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Criar;
using TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Desativar;
using TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Listar;
using TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Obter;
using TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.PapelAdmin;

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

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarUsuario(UsuarioAtualizarRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPatch("ativar/{id}")]
        public async Task<IActionResult> AtivarUsuario(Guid id)
        {
            var request = new UsuarioAtivarRequest(id);
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPatch("desativar/{id}")]
        public async Task<IActionResult> DesativarUsuario(Guid id)
        {
            var request = new UsuarioDesativarRequest(id);
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPatch("tornarAdmin/{id}")]
        public async Task<IActionResult> TornarUsuarioAdmin(Guid id)
        {
            var request = new UsuarioPapelAdminRequest(id);
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
