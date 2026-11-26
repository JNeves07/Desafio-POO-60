namespace AtividadePoo.Sections.Section02;

/// <summary>Questões 11 a 20: métodos, construtores e coleções.</summary>
public static class Secao02
{
    public static string Titulo => "Seção 2: Métodos e Construtores (Q11-Q20)";

    public static IReadOnlyList<string> Executar()
    {
        var linhas = new List<string>();

        // Q11
        var retangulo = new Retangulo(5, 4);
        linhas.Add($"Q11: Área retângulo = {retangulo.Area()}");

        // Q12
        var funcionario = new Funcionario("Carla", 3000m);
        funcionario.AumentarSalario(10);
        linhas.Add($"Q12: {funcionario.Nome} novo salário = {Formatacao.Moeda(funcionario.Salario)}");

        // Q13
        linhas.Add($"Q13: Data formatada = {new Data(1, 9, 2025).Formatar()}");

        // Q14
        linhas.Add($"Q14: {new Veiculo("VW", "Gol").Acelerar()}");

        // Q15
        linhas.Add($"Q15: Perímetro triângulo = {new Triangulo(3, 4, 5).Perimetro()}");

        // Q16
        var usuario = new Usuario("Alex", "alex@ex.com");
        usuario.AlterarEmail("alex.novo@ex.com");
        linhas.Add($"Q16: Email alterado para {usuario.Email}");

        // Q17
        var biblioteca = new Biblioteca();
        biblioteca.AdicionarLivro("Clean Code");
        biblioteca.AdicionarLivro("Refactoring");
        linhas.Add($"Q17: Livros => {string.Join(", ", biblioteca.Listar())}");

        // Q18
        linhas.Add($"Q18: 12/3 = {new Calculadora().Dividir(12, 3)}");

        // Q19
        var agenda = new Agenda(["João - 999", "Maria - 888"]);
        linhas.Add($"Q19: Buscar 'ma' => {agenda.BuscarContato("ma") ?? "não encontrado"}");

        // Q20
        linhas.Add($"Q20: {new Jogo("Hollow Knight", "PC").Jogar()}");

        return linhas;
    }
}

// Q11 - Dimensões imutáveis informadas no construtor.
public sealed class Retangulo
{
    public Retangulo(double largura, double altura)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(largura);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(altura);
        Largura = largura;
        Altura = altura;
    }

    public double Largura { get; }

    public double Altura { get; }

    public double Area() => Largura * Altura;
}

// Q12 - Saldo protegido contra alteração direta e aumento percentual.
public sealed class Funcionario
{
    public Funcionario(string nome, decimal salario)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nome);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(salario);
        Nome = nome.Trim();
        Salario = salario;
    }

    public string Nome { get; }

    public decimal Salario { get; private set; }

    public void AumentarSalario(double percentual)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(percentual);
        Salario += ((decimal)percentual / 100m) * Salario;
    }
}

// Q13 - Validação e formatação de uma data.
public sealed class Data
{
    private readonly DateTime _data;

    public Data(int dia, int mes, int ano)
    {
        _data = new DateTime(ano, mes, dia);
    }

    public int Dia => _data.Day;

    public int Mes => _data.Month;

    public int Ano => _data.Year;

    public string Formatar() => _data.ToString("dd/MM/yyyy", Formatacao.Cultura);
}

// Q14 - Veículo com método de aceleração.
public sealed class Veiculo
{
    public Veiculo(string marca, string modelo)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(marca);
        ArgumentException.ThrowIfNullOrWhiteSpace(modelo);
        Marca = marca.Trim();
        Modelo = modelo.Trim();
    }

    public string Marca { get; }

    public string Modelo { get; }

    public string Acelerar() => "Acelerando!";
}

// Q15 - Triângulo com validação da desigualdade triangular.
public sealed class Triangulo
{
    public Triangulo(double lado1, double lado2, double lado3)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(lado1);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(lado2);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(lado3);

        if (lado1 + lado2 <= lado3 || lado1 + lado3 <= lado2 || lado2 + lado3 <= lado1)
            throw new ArgumentException("Os lados informados não formam um triângulo.");

        Lado1 = lado1;
        Lado2 = lado2;
        Lado3 = lado3;
    }

    public double Lado1 { get; }

    public double Lado2 { get; }

    public double Lado3 { get; }

    public double Perimetro() => Lado1 + Lado2 + Lado3;
}

// Q16 - E-mail alterado apenas pelo método da classe.
public sealed class Usuario
{
    public Usuario(string nome, string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nome);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        Nome = nome.Trim();
        Email = email.Trim();
    }

    public string Nome { get; }

    public string Email { get; private set; }

    public void AlterarEmail(string novoEmail)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(novoEmail);
        Email = novoEmail.Trim();
    }
}

// Q17 - Coleção privada de títulos.
public sealed class Biblioteca
{
    private readonly List<string> _titulos = [];

    public void AdicionarLivro(string titulo)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(titulo);
        _titulos.Add(titulo.Trim());
    }

    public IReadOnlyList<string> Listar() => _titulos.ToArray();
}

// Q18 - Operações básicas; divisão por zero gera exceção.
public sealed class Calculadora
{
    public double Somar(double a, double b) => a + b;

    public double Subtrair(double a, double b) => a - b;

    public double Multiplicar(double a, double b) => a * b;

    public double Dividir(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Não é possível dividir por zero.");

        return a / b;
    }
}

// Q19 - Busca case-insensitive em uma agenda de contatos.
public sealed class Agenda
{
    private readonly string[] _contatos;

    public Agenda(IEnumerable<string> contatos)
    {
        ArgumentNullException.ThrowIfNull(contatos);
        _contatos = contatos.ToArray();
    }

    public string? BuscarContato(string nome) =>
        Array.Find(_contatos, contato => contato.Contains(nome, StringComparison.OrdinalIgnoreCase));
}

// Q20 - Jogo com plataforma e método de execução.
public sealed class Jogo
{
    public Jogo(string nome, string plataforma)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nome);
        ArgumentException.ThrowIfNullOrWhiteSpace(plataforma);
        Nome = nome.Trim();
        Plataforma = plataforma.Trim();
    }

    public string Nome { get; }

    public string Plataforma { get; }

    public string Jogar() => $"Jogando {Nome} no {Plataforma}!";
}
