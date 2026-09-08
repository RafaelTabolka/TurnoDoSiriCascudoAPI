using TurnoDoSiriCascudo.Dominio.Entidades.PedidoEntidade;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.PedidoRepositorio;
using TurnoDoSiriCascudo.Infra.Dados.Contexto;
using TurnoDoSiriCascudo.Infra.Dados.Repositorio.Base;

namespace TurnoDoSiriCascudo.Infra.Dados.Repositorio.PedidoRepositorio
{
    public class RepositorioPedido(TurnoDoSiriCascudoContexto contexto) :
        RepositorioBase<Pedido>(contexto), IRepositorioPedido;
}
