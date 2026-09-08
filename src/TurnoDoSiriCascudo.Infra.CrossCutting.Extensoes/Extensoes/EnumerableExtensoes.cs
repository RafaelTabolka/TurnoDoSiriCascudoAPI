namespace TurnoDoSiriCascudo.Infra.CrossCutting.Extensoes.Extensoes
{
    public static class EnumerableExtensoes
    {
        public static void ForEach<T>(this IEnumerable<T> fonte, Action<T> acao)
        {
            foreach (var elemento in fonte)
            {
                acao(elemento);
            }
        }
    }
}
