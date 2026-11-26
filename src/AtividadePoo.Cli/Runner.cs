using System.Globalization;
using System.Text;
using AtividadePoo;

namespace AtividadePoo.Cli;

/// <summary>Interpretador de argumentos e saída do runner de console.</summary>
public static class Runner
{
    public static int Executar(string[] args, TextWriter? saida = null)
    {
        var writer = saida ?? Console.Out;

        if (saida is null)
            Console.OutputEncoding = Encoding.UTF8;

        CultureInfo.CurrentCulture = Formatacao.Cultura;

        if (!TentarInterpretar(args, out var secao, out var erro))
        {
            writer.WriteLine($"Erro: {erro}");
            EscreverAjuda(writer);
            return 1;
        }

        if (secao == int.MinValue)
        {
            EscreverAjuda(writer);
            return 0;
        }

        var linhas = secao is null
            ? ExecutorDeSecoes.ExecutarTodas()
            : ExecutorDeSecoes.Executar(secao.Value);

        writer.WriteLine("=== Desafio de Fixação POO (C#) ===");

        foreach (var linha in linhas)
            writer.WriteLine(linha);

        writer.WriteLine();
        writer.WriteLine("--- Fim da execução. ---");
        return 0;
    }

    public static void EscreverAjuda(TextWriter writer)
    {
        writer.WriteLine("Uso: dotnet run --project src/AtividadePoo.Cli -- [opções]");
        writer.WriteLine();
        writer.WriteLine("Opções:");
        writer.WriteLine("  --all             Executa todas as seções (padrão)");
        writer.WriteLine("  --section N       Executa apenas a seção N (1 a 6)");
        writer.WriteLine("  --section=N       Forma alternativa de informar a seção");
        writer.WriteLine("  --help, -h        Mostra esta ajuda");
    }

    private static bool TentarInterpretar(string[] args, out int? secao, out string erro)
    {
        secao = null;
        erro = string.Empty;

        for (var indice = 0; indice < args.Length; indice++)
        {
            var argumento = args[indice];
            int numero;

            switch (argumento)
            {
                case "--help":
                case "-h":
                    secao = int.MinValue;
                    return true;
                case "--all":
                    secao = null;
                    break;
                case "--section":
                    if (indice + 1 >= args.Length || !int.TryParse(args[++indice], out numero))
                    {
                        erro = "A opção --section requer um número inteiro.";
                        return false;
                    }

                    secao = numero;
                    break;
                default:
                    if (!argumento.StartsWith("--section=", StringComparison.Ordinal) ||
                        !int.TryParse(argumento["--section=".Length..], out numero))
                    {
                        erro = $"Opção desconhecida: {argumento}";
                        return false;
                    }

                    secao = numero;
                    break;
            }
        }

        if (secao is not null && secao != int.MinValue && !ExecutorDeSecoes.NumerosDisponiveis.Contains(secao.Value))
        {
            erro = $"A seção {secao} não existe. Use um valor entre 1 e {ExecutorDeSecoes.NumerosDisponiveis.Count}.";
            return false;
        }

        return true;
    }
}
