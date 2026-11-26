using AtividadePoo;
using AtividadePoo.Cli;

namespace AtividadePoo.Tests;

public class ExecucaoDasSecoesTests
{
    [Theory]
    [InlineData(1, "Q1:", "Q10:")]
    [InlineData(2, "Q11:", "Q20:")]
    [InlineData(3, "Q21:", "Q30:")]
    [InlineData(4, "Q31:", "Q40:")]
    [InlineData(5, "Q41:", "Q50:")]
    [InlineData(6, "Q51:", "Q60:")]
    public void Secao_DeveGerarAsDezQuestoes(int numero, string primeira, string ultima)
    {
        var linhas = ExecutorDeSecoes.Executar(numero);

        Assert.Equal(10, linhas.Count);
        Assert.StartsWith(primeira, linhas[0]);
        Assert.StartsWith(ultima, linhas[^1]);
    }

    [Fact]
    public void ExecutarTodas_DeveGerarAsSessentaQuestoes()
    {
        var linhas = ExecutorDeSecoes.ExecutarTodas();

        Assert.Equal(60, linhas.Count);
        Assert.StartsWith("Q1:", linhas[0]);
        Assert.StartsWith("Q60:", linhas[^1]);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(7)]
    [InlineData(-1)]
    public void SecaoInexistente_DeveLancarExcecao(int numero) =>
        Assert.Throws<ArgumentOutOfRangeException>(() => ExecutorDeSecoes.Executar(numero));

    [Fact]
    public void Runner_SemArgumentos_DeveExecutarTodasAsSecoes()
    {
        var saida = new StringWriter();

        var codigo = Runner.Executar([], saida);
        var texto = saida.ToString();

        Assert.Equal(0, codigo);
        Assert.Contains("Q1:", texto);
        Assert.Contains("Q60:", texto);
        Assert.Contains("Fim da execução", texto);
    }

    [Fact]
    public void Runner_ComSection3_DeveExecutarApenasTerceiraSecao()
    {
        var saida = new StringWriter();

        var codigo = Runner.Executar(["--section", "3"], saida);
        var texto = saida.ToString();

        Assert.Equal(0, codigo);
        Assert.Contains("Q21:", texto);
        Assert.Contains("Q30:", texto);
        Assert.DoesNotContain("Q11:", texto);
        Assert.DoesNotContain("Q31:", texto);
    }

    [Fact]
    public void Runner_ComSectionIgual_DeveAceitarNumero()
    {
        var saida = new StringWriter();

        var codigo = Runner.Executar(["--section=2"], saida);

        Assert.Equal(0, codigo);
        Assert.Contains("Q11:", saida.ToString());
        Assert.Contains("Q20:", saida.ToString());
    }

    [Fact]
    public void Runner_ComHelp_DeveMostrarInstrucoes()
    {
        var saida = new StringWriter();

        var codigo = Runner.Executar(["--help"], saida);

        Assert.Equal(0, codigo);
        Assert.Contains("--section N", saida.ToString());
    }

    [Theory]
    [InlineData("--section", "9")]
    [InlineData("--desconhecida")]
    [InlineData("--section")]
    public void Runner_ComArgumentoInvalido_DeveRetornarErro(params string[] args)
    {
        var saida = new StringWriter();

        var codigo = Runner.Executar(args, saida);

        Assert.Equal(1, codigo);
        Assert.Contains("Erro:", saida.ToString());
    }
}
