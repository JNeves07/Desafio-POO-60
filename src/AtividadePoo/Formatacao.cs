using System.Globalization;

namespace AtividadePoo;

/// <summary>Formatação determinística usada pelas demonstrações e pelos testes.</summary>
public static class Formatacao
{
    public static CultureInfo Cultura { get; } = CultureInfo.GetCultureInfo("pt-BR");

    public static string Moeda(decimal valor) => valor.ToString("C", Cultura);

    public static string Numero(double valor, string formato) => valor.ToString(formato, Cultura);
}
