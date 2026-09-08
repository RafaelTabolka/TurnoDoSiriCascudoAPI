using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TurnoDoSiriCascudo.Dominio.Entidades.UsuarioEntidade;
using TurnoDoSiriCascudo.Dominio.Interfaces.IServicoToken;

namespace TurnoDoSiriCascudo.Infra.CrossCutting.Extensoes.ServicoToken
{
    public class ServicoToken(IConfiguration configuracao) : IServicoToken
    {
        public string GerarToken(Usuario usuario)
        {
            var chaveConfigurada = configuracao["Jwt:Chave"]
                ?? throw new InvalidOperationException("A chave do Jwt não foi configurada");

            var emissor = configuracao["Jwt:Emissor"]
                ?? throw new InvalidOperationException("O emissor do Jwt não foi configurada");

            var audiencia = configuracao["Jwt:Audiencia"]
                ?? throw new InvalidOperationException("A audiência do Jwt não foi configurada");

            var expiracaoEmMinutos = int.Parse(configuracao["Jwt:ExpiracaoEmMinutos"]
                ?? throw new InvalidOperationException("O tempo de expiração do Jwt não foi configurada"));

            var agora = DateTime.UtcNow;

            var declaracoes = new List<Claim>
            {
                new (
                    JwtRegisteredClaimNames.Sub,
                    usuario.Id.ToString()
                ),
                new (
                    JwtRegisteredClaimNames.Name,
                    usuario.NomeUsuario
                ),
                new (
                    JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString()
                ),
                new (
                    JwtRegisteredClaimNames.Iat,
                    new DateTimeOffset(agora)
                    .ToUnixTimeMilliseconds()
                    .ToString(),
                    ClaimValueTypes.Integer64
                ),
                new(
                    "papel",
                    usuario.PapelUsuario.ToString()
                )
            };

            var chave = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(chaveConfigurada)
            );

            var credenciais = new SigningCredentials(
                    chave,
                    SecurityAlgorithms.HmacSha512
            );

            var token = new JwtSecurityToken(
                    issuer: emissor,
                    audience: audiencia,
                    claims: declaracoes,
                    expires: DateTime.UtcNow.AddMinutes(expiracaoEmMinutos),
                    signingCredentials: credenciais
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
