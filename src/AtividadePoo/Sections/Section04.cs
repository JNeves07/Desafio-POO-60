namespace AtividadePoo.Sections.Section04;

/// <summary>Questões 31 a 40: herança básica.</summary>
public static class Secao04
{
    public static string Titulo => "Seção 4: Herança Básica (Q31-Q40)";

    public static IReadOnlyList<string> Executar()
    {
        var linhas = new List<string>();

        // Q31
        linhas.Add($"Q31: Som do cachorro = {new Cachorro().FazerSom()}");

        // Q32
        var carro = new CarroComBuzina { Velocidade = 60 };
        linhas.Add($"Q32: {carro.Buzinar()} (velocidade {carro.Velocidade})");

        // Q33
        linhas.Add($"Q33: Área quadrado = {new QuadradoAbstrato(6).Area()}");

        // Q34
        var aluno = new AlunoHeranca { Nome = "Nina", Idade = 20, Nota = 9.8 };
        linhas.Add($"Q34: {aluno.Estudar()}");

        // Q35
        var poupanca = new ContaPoupanca();
        poupanca.Depositar(1000m);
        poupanca.RenderJuros();
        linhas.Add($"Q35: Saldo com juros = {Formatacao.Moeda(poupanca.Saldo)}");

        // Q36
        var gerente = new Gerente { SalarioBase = 4000m, Bonus = 800m };
        linhas.Add($"Q36: Salário total gerente = {Formatacao.Moeda(gerente.SalarioTotal())}");

        // Q37
        var digital = new ProdutoDigital { Preco = 59.90m, TamanhoArquivoBytes = 1024 * 1024 };
        linhas.Add($"Q37: {digital.Baixar()}");

        // Q38
        var aviao = new Aviao { Altitude = 10000 };
        linhas.Add($"Q38: Transporte: {aviao.Mover()}, Altitude = {aviao.Altitude}");

        // Q39
        var online = new JogoOnline { Nome = "RPG-Z", Servidor = "BR-1" };
        linhas.Add($"Q39: {online.Conectar()}");

        // Q40
        var livro = new LivroDaBiblioteca { Titulo = "POO Essencial", Autor = "Dev X" };
        var revista = new Revista { Titulo = "Tech Monthly", Edicao = 42 };
        linhas.Add(
            $"Q40: Livro='{livro.Titulo}' de {livro.Autor}; " +
            $"Revista='{revista.Titulo}' edição {revista.Edicao}");

        return linhas;
    }
}

// Q31 - Método virtual sobrescrito pela classe filha.
public class AnimalQueFazSom
{
    public virtual string FazerSom() => "Som";
}

public sealed class Cachorro : AnimalQueFazSom
{
    public override string FazerSom() => "Latir";
}

// Q32 - Herança de velocidade com comportamento adicional.
public class VeiculoComVelocidade
{
    public int Velocidade { get; set; }
}

public sealed class CarroComBuzina : VeiculoComVelocidade
{
    public string Buzinar() => "Biiip!";
}

// Q33 - Classe abstrata com método abstrato.
public abstract class FormaAbstrata
{
    public abstract double Area();
}

public sealed class QuadradoAbstrato : FormaAbstrata
{
    public QuadradoAbstrato(double lado)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(lado);
        Lado = lado;
    }

    public double Lado { get; }

    public override double Area() => Lado * Lado;
}

// Q34 - Aluno herda dados de pessoa.
public class PessoaBase
{
    public string Nome { get; set; } = string.Empty;

    public int Idade { get; set; }
}

public sealed class AlunoHeranca : PessoaBase
{
    public double Nota { get; set; }

    public string Estudar() => $"{Nome} estudando...";
}

// Q35 - Saldo protegido para classes derivadas.
public abstract class ContaBase
{
    public decimal Saldo { get; protected set; }
}

public sealed class ContaPoupanca : ContaBase
{
    public void Depositar(decimal valor)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(valor);
        Saldo += valor;
    }

    public void RenderJuros() => Saldo += Saldo * 0.01m;
}

// Q36 - Gerente compõe salário base e bônus.
public class FuncionarioBase
{
    public decimal SalarioBase { get; set; }
}

public sealed class Gerente : FuncionarioBase
{
    public decimal Bonus { get; set; }

    public decimal SalarioTotal() => SalarioBase + Bonus;
}

// Q37 - Produto digital herda preço.
public class ProdutoBase
{
    public decimal Preco { get; set; }
}

public sealed class ProdutoDigital : ProdutoBase
{
    public long TamanhoArquivoBytes { get; set; }

    public string Baixar() => $"Baixando {TamanhoArquivoBytes} bytes...";
}

// Q38 - Polimorfismo em meio de transporte.
public class Transporte
{
    public virtual string Mover() => "Mover";
}

public sealed class Aviao : Transporte
{
    public int Altitude { get; set; }

    public override string Mover() => "Voar";
}

// Q39 - Jogo online herda nome.
public class JogoBase
{
    public string Nome { get; set; } = string.Empty;
}

public sealed class JogoOnline : JogoBase
{
    public string Servidor { get; set; } = string.Empty;

    public string Conectar() => $"Conectando ao {Servidor}...";
}

// Q40 - Itens de biblioteca com especializações.
public class BibliotecaItem
{
    public string Titulo { get; set; } = string.Empty;
}

public sealed class LivroDaBiblioteca : BibliotecaItem
{
    public string Autor { get; set; } = string.Empty;
}

public sealed class Revista : BibliotecaItem
{
    public int Edicao { get; set; }
}
