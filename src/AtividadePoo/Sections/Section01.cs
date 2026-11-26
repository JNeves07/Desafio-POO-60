namespace AtividadePoo.Sections.Section01;

/// <summary>Questões 1 a 10: introdução a classes e objetos.</summary>
public static class Secao01
{
    public static string Titulo => "Seção 1: Introdução a Classes e Objetos (Q1-Q10)";

    public static IReadOnlyList<string> Executar()
    {
        var linhas = new List<string>();

        // Q1
        _ = new PessoaSimples();
        linhas.Add("Q1: Pessoa instanciada.");

        // Q2
        linhas.Add($"Q2: Carro.Cor = {new Carro().Cor}");

        // Q3
        var animal = new Animal("Rex", 3);
        linhas.Add($"Q3: Animal Nome={animal.Nome}, Idade={animal.Idade}");

        // Q4
        var livro = new Livro { Titulo = "POO na Prática", Autor = "Ana Dev" };
        linhas.Add($"Q4: {livro.ExibirInfo()}");

        // Q5
        var quadrado = new Quadrado { Lado = 4 };
        linhas.Add($"Q5: Área do quadrado (lado 4) = {quadrado.Area()}");

        // Q6
        var alunos = new[]
        {
            new Aluno { Nome = "João", Nota = 8.5 },
            new Aluno { Nome = "Maria", Nota = 9.0 },
        };
        linhas.Add($"Q6: Maior nota: {Aluno.MelhorNota(alunos)!.Nome}");

        // Q7
        var circulo = new Circulo { Raio = 3 };
        linhas.Add(
            $"Q7: Área={Formatacao.Numero(circulo.Area(), "F2")}, " +
            $"Perímetro={Formatacao.Numero(circulo.Perimetro(), "F2")}");

        // Q8
        var conta = new ContaBancaria();
        conta.Depositar(250m);
        linhas.Add($"Q8: Saldo após depósito = {Formatacao.Moeda(conta.Saldo)}");

        // Q9
        var produto = new Produto { Nome = "Mouse", Preco = 100m };
        produto.AplicarDesconto();
        linhas.Add($"Q9: {produto.Nome} com desconto = {Formatacao.Moeda(produto.Preco)}");

        // Q10
        var ponto = new Ponto { X = 3, Y = 4 };
        linhas.Add($"Q10: Distância até origem = {Formatacao.Numero(ponto.DistanciaOrigem(), "F2")}");

        return linhas;
    }
}

// Q1 - Classe vazia para demonstrar a declaração de um tipo.
public sealed class PessoaSimples
{
}

// Q2 - Propriedade com valor padrão.
public sealed class Carro
{
    public string Cor { get; set; } = "Vermelho";
}

// Q3 - Construtor com parâmetros.
public sealed class Animal
{
    public Animal(string nome, int idade)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nome);
        ArgumentOutOfRangeException.ThrowIfNegative(idade);
        Nome = nome.Trim();
        Idade = idade;
    }

    public string Nome { get; }

    public int Idade { get; }
}

// Q4 - Método que descreve o objeto.
public sealed class Livro
{
    public string Titulo { get; set; } = string.Empty;

    public string Autor { get; set; } = string.Empty;

    public string ExibirInfo() => $"Livro: \"{Titulo}\", Autor: {Autor}";
}

// Q5 - Cálculo da área de um quadrado.
public sealed class Quadrado
{
    private double _lado;

    public double Lado
    {
        get => _lado;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            _lado = value;
        }
    }

    public double Area() => Lado * Lado;
}

// Q6 - Aluno e seleção da maior nota.
public sealed class Aluno
{
    public string Nome { get; set; } = string.Empty;

    public double Nota { get; set; }

    public static Aluno? MelhorNota(IEnumerable<Aluno> alunos)
    {
        ArgumentNullException.ThrowIfNull(alunos);
        return alunos.MaxBy(aluno => aluno.Nota);
    }
}

// Q7 - Área e perímetro de um círculo.
public sealed class Circulo
{
    private double _raio;

    public double Raio
    {
        get => _raio;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            _raio = value;
        }
    }

    public double Area() => Math.PI * Raio * Raio;

    public double Perimetro() => 2 * Math.PI * Raio;
}

// Q8 - Encapsulamento do saldo com depósito válido.
public sealed class ContaBancaria
{
    public decimal Saldo { get; private set; }

    public void Depositar(decimal valor)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(valor);
        Saldo += valor;
    }
}

// Q9 - Desconto de 10% no preço do produto.
public sealed class Produto
{
    private decimal _preco;

    public string Nome { get; set; } = string.Empty;

    public decimal Preco
    {
        get => _preco;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            _preco = value;
        }
    }

    public void AplicarDesconto() => Preco *= 0.9m;
}

// Q10 - Distância de um ponto até a origem.
public sealed class Ponto
{
    public double X { get; set; }

    public double Y { get; set; }

    public double DistanciaOrigem() => Math.Sqrt((X * X) + (Y * Y));
}
