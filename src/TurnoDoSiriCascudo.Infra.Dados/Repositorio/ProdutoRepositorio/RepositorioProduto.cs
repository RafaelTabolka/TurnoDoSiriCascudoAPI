using TurnoDoSiriCascudo.Dominio.Entidades.ProdutoEntidade;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.ProdutoRepositorio;
using TurnoDoSiriCascudo.Infra.Dados.Contexto;
using TurnoDoSiriCascudo.Infra.Dados.Repositorio.Base;

namespace TurnoDoSiriCascudo.Infra.Dados.Repositorio.ProdutoRepositorio
{
    public class RepositorioProduto(TurnoDoSiriCascudoContexto contexto) :
        RepositorioBase<Produto>(contexto), IRepositorioProduto;
}
