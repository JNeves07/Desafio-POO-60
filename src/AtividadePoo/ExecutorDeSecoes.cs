using AtividadePoo.Sections.Section01;
using AtividadePoo.Sections.Section02;
using AtividadePoo.Sections.Section03;
using AtividadePoo.Sections.Section04;
using AtividadePoo.Sections.Section05;
using AtividadePoo.Sections.Section06;

namespace AtividadePoo;

/// <summary>Executa uma seção específica ou todas as seções do desafio.</summary>
public static class ExecutorDeSecoes
{
    private static readonly IReadOnlyDictionary<int, Func<IReadOnlyList<string>>> Secoes =
        new Dictionary<int, Func<IReadOnlyList<string>>>
        {
            [1] = Secao01.Executar,
            [2] = Secao02.Executar,
            [3] = Secao03.Executar,
            [4] = Secao04.Executar,
            [5] = Secao05.Executar,
            [6] = Secao06.Executar,
        };

    public static IReadOnlyList<int> NumerosDisponiveis => Secoes.Keys.Order().ToArray();

    public static IReadOnlyList<string> Executar(int numero)
    {
        if (!Secoes.TryGetValue(numero, out var secao))
            throw new ArgumentOutOfRangeException(
                nameof(numero),
                numero,
                $"A seção deve estar entre 1 e {Secoes.Count}.");

        return secao();
    }

    public static IReadOnlyList<string> ExecutarTodas()
    {
        var linhas = new List<string>();

        foreach (var numero in NumerosDisponiveis)
            linhas.AddRange(Executar(numero));

        return linhas;
    }
}
