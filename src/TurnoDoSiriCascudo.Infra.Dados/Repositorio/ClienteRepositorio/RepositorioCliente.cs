using TurnoDoSiriCascudo.Dominio.Entidades.ClienteEntidade;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.ClienteRepositorio;
using TurnoDoSiriCascudo.Infra.Dados.Contexto;
using TurnoDoSiriCascudo.Infra.Dados.Repositorio.Base;

namespace TurnoDoSiriCascudo.Infra.Dados.Repositorio.ClienteRepositorio
{
    public class RepositorioCliente(TurnoDoSiriCascudoContexto contexto) :
        RepositorioBase<Cliente>(contexto), IRepositorioCliente;
}
