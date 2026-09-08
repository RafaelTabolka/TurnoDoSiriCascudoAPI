using TurnoDoSiriCascudo.Dominio.Entidades.IngredienteEntidade;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.IngredienteRepositorio;
using TurnoDoSiriCascudo.Infra.Dados.Contexto;
using TurnoDoSiriCascudo.Infra.Dados.Repositorio.Base;

namespace TurnoDoSiriCascudo.Infra.Dados.Repositorio.IngredienteRepositorio
{
    public class RepositorioIngrediente(TurnoDoSiriCascudoContexto contexto) :
        RepositorioBase<Ingrediente>(contexto), IRepositorioIngrediente;
}
