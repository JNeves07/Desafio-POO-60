using AtividadePoo.Sections.Section01;
using AtividadePoo.Sections.Section02;

namespace AtividadePoo.Tests;

/// <summary>Testes representativos das questões 1 a 20.</summary>
public class QuestoesBasicasTests
{
    [Fact]
    public void Q01_PessoaSimples_DeveSerInstanciada() =>
        Assert.NotNull(new PessoaSimples());

    [Fact]
    public void Q02_Carro_DeveTerCorVermelhaPorPadrao() =>
        Assert.Equal("Vermelho", new Carro().Cor);

    [Fact]
    public void Q03_Animal_DeveGuardarNomeEIdade()
    {
        var animal = new Animal("Rex", 3);

        Assert.Equal("Rex", animal.Nome);
        Assert.Equal(3, animal.Idade);
        Assert.Throws<ArgumentOutOfRangeException>(() => new Animal("Rex", -1));
    }

    [Fact]
    public void Q04_Livro_DeveExibirTituloEAutor() =>
        Assert.Equal(
            "Livro: \"POO na Prática\", Autor: Ana Dev",
            new Livro { Titulo = "POO na Prática", Autor = "Ana Dev" }.ExibirInfo());

    [Fact]
    public void Q05_Quadrado_DeveCalcularArea()
    {
        Assert.Equal(16, new Quadrado { Lado = 4 }.Area());
        Assert.Throws<ArgumentOutOfRangeException>(() => new Quadrado { Lado = -1 });
    }

    [Fact]
    public void Q06_Aluno_DeveRetornarMaiorNota()
    {
        var alunos = new[]
        {
            new Aluno { Nome = "João", Nota = 8.5 },
            new Aluno { Nome = "Maria", Nota = 9.0 },
        };

        Assert.Equal("Maria", Aluno.MelhorNota(alunos)!.Nome);
    }

    [Fact]
    public void Q07_Circulo_DeveCalcularAreaEPerimetro()
    {
        var circulo = new Circulo { Raio = 2 };

        Assert.Equal(Math.PI * 4, circulo.Area(), 10);
        Assert.Equal(Math.PI * 4, circulo.Perimetro(), 10);
    }

    [Fact]
    public void Q08_ContaBancaria_DevePermitirDepositoValido()
    {
        var conta = new ContaBancaria();
        conta.Depositar(250m);

        Assert.Equal(250m, conta.Saldo);
        Assert.Throws<ArgumentOutOfRangeException>(() => conta.Depositar(0m));
    }

    [Fact]
    public void Q09_Produto_DeveAplicarDescontoDeDezPorCento()
    {
        var produto = new Produto { Nome = "Mouse", Preco = 100m };
        produto.AplicarDesconto();

        Assert.Equal(90m, produto.Preco);
    }

    [Fact]
    public void Q10_Ponto_DeveCalcularDistanciaAteOrigem() =>
        Assert.Equal(5, new Ponto { X = 3, Y = 4 }.DistanciaOrigem(), 10);

    [Fact]
    public void Q11_Retangulo_DeveCalcularAreaEValidarDimensoes()
    {
        Assert.Equal(20, new Retangulo(5, 4).Area());
        Assert.Throws<ArgumentOutOfRangeException>(() => new Retangulo(0, 4));
    }

    [Fact]
    public void Q12_Funcionario_DeveAumentarSalario()
    {
        var funcionario = new Funcionario("Carla", 3000m);
        funcionario.AumentarSalario(10);

        Assert.Equal(3300m, funcionario.Salario);
    }

    [Fact]
    public void Q13_Data_DeveFormatarDiaMesAno() =>
        Assert.Equal("01/09/2025", new Data(1, 9, 2025).Formatar());

    [Fact]
    public void Q14_Veiculo_DeveAcelerar() =>
        Assert.Equal("Acelerando!", new Veiculo("VW", "Gol").Acelerar());

    [Fact]
    public void Q15_Triangulo_DeveCalcularPerimetroEValidarLados()
    {
        Assert.Equal(12, new Triangulo(3, 4, 5).Perimetro());
        Assert.Throws<ArgumentException>(() => new Triangulo(1, 2, 10));
    }

    [Fact]
    public void Q16_Usuario_DeveAlterarEmail()
    {
        var usuario = new Usuario("Alex", "alex@ex.com");
        usuario.AlterarEmail("alex.novo@ex.com");

        Assert.Equal("alex.novo@ex.com", usuario.Email);
    }

    [Fact]
    public void Q17_Biblioteca_DeveListarLivrosAdicionados()
    {
        var biblioteca = new Biblioteca();
        biblioteca.AdicionarLivro("Clean Code");
        biblioteca.AdicionarLivro("Refactoring");

        Assert.Equal(["Clean Code", "Refactoring"], biblioteca.Listar());
    }

    [Fact]
    public void Q18_Calculadora_DeveOperarESinalizarDivisaoPorZero()
    {
        var calculadora = new Calculadora();

        Assert.Equal(7, calculadora.Somar(3, 4));
        Assert.Equal(-1, calculadora.Subtrair(3, 4));
        Assert.Equal(12, calculadora.Multiplicar(3, 4));
        Assert.Equal(4, calculadora.Dividir(12, 3));
        Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(12, 0));
    }

    [Fact]
    public void Q19_Agenda_DeveBuscarContatoIgnorandoCaixa()
    {
        var agenda = new Agenda(["João - 999", "Maria - 888"]);

        Assert.Equal("Maria - 888", agenda.BuscarContato("ma"));
        Assert.Null(agenda.BuscarContato("Pedro"));
    }

    [Fact]
    public void Q20_Jogo_DeveDescreverAExecucao() =>
        Assert.Equal(
            "Jogando Hollow Knight no PC!",
            new Jogo("Hollow Knight", "PC").Jogar());
}
