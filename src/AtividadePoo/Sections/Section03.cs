namespace AtividadePoo.Sections.Section03;

/// <summary>Questões 21 a 30: encapsulamento.</summary>
public static class Secao03
{
    public static string Titulo => "Seção 3: Encapsulamento (Q21-Q30)";

    public static IReadOnlyList<string> Executar()
    {
        var linhas = new List<string>();

        // Q21
        linhas.Add($"Q21: Idade = {new PessoaComIdade { Idade = 25 }.Idade}");

        // Q22
        var conta = new Conta();
        conta.Depositar(100m);
        linhas.Add($"Q22: Saque 30 => {conta.Sacar(30m)}, Saldo={Formatacao.Moeda(conta.Saldo)}");

        // Q23
        var aluno = new AlunoComNota { Nota = 9.5 };
        var notaRejeitada = false;
        try
        {
            aluno.Nota = 11;
        }
        catch (ArgumentOutOfRangeException)
        {
            notaRejeitada = true;
        }

        linhas.Add(
            $"Q23: Nota válida = {Formatacao.Numero(aluno.Nota, "F1")} " +
            $"(nota 11 rejeitada: {notaRejeitada})");

        // Q24
        var produto = new ProdutoComDesconto(50m);
        produto.AplicarDesconto(60m);
        linhas.Add($"Q24: Preço após desconto = {Formatacao.Moeda(produto.Preco)}");

        // Q25
        var carro = new CarroComVelocidadeMaxima();
        carro.Acelerar(250);
        linhas.Add($"Q25: Velocidade = {carro.Velocidade} (máx 200)");

        // Q26
        var usuario = new UsuarioComSenha("1234");
        linhas.Add($"Q26: Autenticar '1234' => {usuario.Autenticar("1234")}");

        // Q27
        var banco = new Banco();
        banco.Adicionar(1);
        banco.Adicionar(2);
        banco.Adicionar(2);
        banco.Remover(1);
        linhas.Add($"Q27: Contas => {string.Join(", ", banco.Listar())}");

        // Q28
        linhas.Add($"Q28: Área (somente get) = {new FormaSomenteLeitura(12.5).Area}");

        // Q29
        linhas.Add($"Q29: Bônus = {Formatacao.Moeda(new EmpregadoComBonus(2000m).CalcularBonus())}");

        // Q30
        var configuracao = new Configuracao();
        configuracao.Set("tema", "escuro");
        linhas.Add($"Q30: Config 'tema' = {configuracao.Get("tema")}");

        return linhas;
    }
}

// Q21 - Propriedade com intervalo válido.
public sealed class PessoaComIdade
{
    private int _idade;

    public int Idade
    {
        get => _idade;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            if (value > 150)
                throw new ArgumentOutOfRangeException(nameof(value), "Idade não pode ultrapassar 150 anos.");
            _idade = value;
        }
    }
}

// Q22 - Saldo acessível somente por leitura; saque retorna sucesso.
public sealed class Conta
{
    public decimal Saldo { get; private set; }

    public void Depositar(decimal valor)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(valor);
        Saldo += valor;
    }

    public bool Sacar(decimal valor)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(valor);

        if (valor > Saldo)
            return false;

        Saldo -= valor;
        return true;
    }
}

// Q23 - Nota válida somente entre 0 e 10.
public sealed class AlunoComNota
{
    private double _nota;

    public double Nota
    {
        get => _nota;
        set
        {
            if (value is < 0 or > 10)
                throw new ArgumentOutOfRangeException(nameof(value), value, "A nota deve estar entre 0 e 10.");
            _nota = value;
        }
    }
}

// Q24 - Preço nunca negativo.
public sealed class ProdutoComDesconto
{
    public ProdutoComDesconto(decimal precoInicial)
    {
        Preco = Math.Max(0m, precoInicial);
    }

    public decimal Preco { get; private set; }

    public void AplicarDesconto(decimal valor)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(valor);
        Preco = Math.Max(0m, Preco - valor);
    }
}

// Q25 - Velocidade limitada a 200.
public sealed class CarroComVelocidadeMaxima
{
    private const int VelocidadeMaxima = 200;

    public int Velocidade { get; private set; }

    public void Acelerar(int delta)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(delta);
        Velocidade = Math.Min(VelocidadeMaxima, Velocidade + delta);
    }
}

// Q26 - Senha privada e autenticação.
public sealed class UsuarioComSenha
{
    public UsuarioComSenha(string senha)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(senha);
        Senha = senha;
    }

    private string Senha { get; }

    public bool Autenticar(string tentativa) =>
        string.Equals(Senha, tentativa, StringComparison.Ordinal);
}

// Q27 - Conjunto de contas sem duplicatas.
public sealed class Banco
{
    private readonly HashSet<int> _contas = [];

    public void Adicionar(int id) => _contas.Add(id);

    public bool Remover(int id) => _contas.Remove(id);

    public IReadOnlyCollection<int> Listar() => _contas.Order().ToArray();
}

// Q28 - Área calculada no construtor e exposta somente para leitura.
public sealed class FormaSomenteLeitura
{
    public FormaSomenteLeitura(double areaCalculada)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(areaCalculada);
        Area = areaCalculada;
    }

    public double Area { get; }
}

// Q29 - Cálculo de bônus sobre o salário.
public sealed class EmpregadoComBonus
{
    public EmpregadoComBonus(decimal salario)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(salario);
        Salario = salario;
    }

    public decimal Salario { get; }

    public decimal CalcularBonus() => Salario * 0.10m;
}

// Q30 - Configurações em dicionário privado.
public sealed class Configuracao
{
    private readonly Dictionary<string, string> _valores = new(StringComparer.OrdinalIgnoreCase);

    public void Set(string chave, string valor)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(chave);
        ArgumentNullException.ThrowIfNull(valor);
        _valores[chave.Trim()] = valor;
    }

    public string? Get(string chave)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(chave);
        return _valores.TryGetValue(chave.Trim(), out var valor) ? valor : null;
    }
}
