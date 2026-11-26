namespace AtividadePoo.Sections.Section05;

/// <summary>Questões 41 a 50: herança avançada e polimorfismo.</summary>
public static class Secao05
{
    public static string Titulo => "Seção 5: Herança Avançada e Polimorfismo (Q41-Q50)";

    public static IReadOnlyList<string> Executar()
    {
        var linhas = new List<string>();

        // Q41
        List<AnimalQueCome> animais = [new Mamifero(), new Ave()];
        linhas.Add($"Q41: {string.Join(" | ", animais.Select(animal => animal.Comer()))}");

        // Q42
        EmpregadoAbstrato horista = new Horista(160, 25m);
        EmpregadoAbstrato assalariado = new Assalariado(3000m);
        linhas.Add(
            $"Q42: Horista={Formatacao.Moeda(horista.CalcularSalario())}, " +
            $"Assalariado={Formatacao.Moeda(assalariado.CalcularSalario())}");

        // Q43
        linhas.Add(
            $"Q43: Perímetro Retângulo(5,3)={CalculadoraDePerimetro.Calcular(new RetanguloGeometrico(5, 3))}, " +
            $"Círculo(r=2)={Formatacao.Numero(CalculadoraDePerimetro.Calcular(new CirculoGeometrico(2)), "F2")}");

        // Q44
        VeiculoQueAcelera bicicleta = new Bicicleta();
        VeiculoQueAcelera moto = new Moto();
        linhas.Add($"Q44: {bicicleta.Acelerar()} | {moto.Acelerar()}");

        // Q45
        var triatleta = new Triatleta();
        linhas.Add($"Q45: {triatleta.Nadar()} | {triatleta.Correr()} | {triatleta.Competir()}");

        // Q46
        ProdutoAbstrato fisico = new ProdutoFisico(100m, 20m);
        ProdutoAbstrato servico = new ProdutoServico(150m, 30m);
        linhas.Add(
            $"Q46: Físico={Formatacao.Moeda(fisico.CalcularPreco())}, " +
            $"Serviço={Formatacao.Moeda(servico.CalcularPreco())}");

        // Q47
        List<PessoaComercial> pessoas = [new Cliente { Nome = "Lia" }, new Fornecedor { Nome = "Zé" }];
        linhas.Add($"Q47: {string.Join(" | ", pessoas.Select(DescreverPessoaComercial))}");

        // Q48
        Arquivo texto = new ArquivoTexto { Nome = "leia.txt", Tamanho = 10 };
        Arquivo binario = new ArquivoBinario { Nome = "img.bin", Tamanho = 0 };
        linhas.Add($"Q48: {texto.Abrir()} | {binario.Abrir()}");

        // Q49
        var corrente = new ContaCorrente(saldo: 100m) { Limite = 50m };
        var investimento = new ContaInvestimento(saldo: 1000m);
        investimento.Render(0.05m);
        linhas.Add(
            $"Q49: CC saque 120 => {corrente.Sacar(120m)} (saldo={Formatacao.Moeda(corrente.Saldo)}), " +
            $"Invest rendimento => {Formatacao.Moeda(investimento.Saldo)}");

        // Q50
        Dispositivo smartphone = new Smartphone();
        Dispositivo tablet = new Tablet();
        linhas.Add(
            $"Q50: {smartphone.Ligar()} | {((ITelaTouch)smartphone).Tocar(10, 20)} | " +
            $"{tablet.Ligar()} | {((ITelaTouch)tablet).Tocar(5, 7)}");

        return linhas;
    }

    private static string DescreverPessoaComercial(PessoaComercial pessoa) => pessoa switch
    {
        Cliente cliente => cliente.Comprar(),
        Fornecedor fornecedor => fornecedor.Fornecer(),
        _ => $"{pessoa.Nome}: tipo desconhecido",
    };
}

// Q41 - Polimorfismo ao alimentar diferentes animais.
public class AnimalQueCome
{
    public virtual string Comer() => "Comer";
}

public sealed class Mamifero : AnimalQueCome
{
    public override string Comer() => "Mamífero comendo";
}

public sealed class Ave : AnimalQueCome
{
    public override string Comer() => "Ave bicando";
}

// Q42 - Classes abstratas para cálculo de salário.
public abstract class EmpregadoAbstrato
{
    public abstract decimal CalcularSalario();
}

public sealed class Horista : EmpregadoAbstrato
{
    public Horista(decimal horas, decimal taxa)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(horas);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(taxa);
        Horas = horas;
        Taxa = taxa;
    }

    public decimal Horas { get; }

    public decimal Taxa { get; }

    public override decimal CalcularSalario() => Horas * Taxa;
}

public sealed class Assalariado : EmpregadoAbstrato
{
    public Assalariado(decimal fixo)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(fixo);
        Fixo = fixo;
    }

    public decimal Fixo { get; }

    public override decimal CalcularSalario() => Fixo;
}

// Q43 - Perímetro calculado por tipos abstratos.
public abstract class FormaGeometrica
{
    public abstract double Perimetro();
}

public sealed class RetanguloGeometrico : FormaGeometrica
{
    public RetanguloGeometrico(double largura, double altura)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(largura);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(altura);
        Largura = largura;
        Altura = altura;
    }

    public double Largura { get; }

    public double Altura { get; }

    public override double Perimetro() => 2 * (Largura + Altura);
}

public sealed class CirculoGeometrico : FormaGeometrica
{
    public CirculoGeometrico(double raio)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(raio);
        Raio = raio;
    }

    public double Raio { get; }

    public override double Perimetro() => 2 * Math.PI * Raio;
}

public static class CalculadoraDePerimetro
{
    public static double Calcular(FormaGeometrica forma)
    {
        ArgumentNullException.ThrowIfNull(forma);
        return forma.Perimetro();
    }
}

// Q44 - Aceleração polimórfica de veículos.
public class VeiculoQueAcelera
{
    public virtual string Acelerar() => "Acelerar genérico";
}

public sealed class Bicicleta : VeiculoQueAcelera
{
    public override string Acelerar() => "Pedalando mais rápido";
}

public sealed class Moto : VeiculoQueAcelera
{
    public override string Acelerar() => "Acelerando motor";
}

// Q45 - Interfaces múltiplas.
public interface INadador
{
    string Nadar();
}

public interface ICorredor
{
    string Correr();
}

public sealed class Triatleta : INadador, ICorredor
{
    public string Nadar() => "Triatleta nadando";

    public string Correr() => "Triatleta correndo";

    public string Competir() => "Triatleta competindo!";
}

// Q46 - Preço calculado por subclasses.
public abstract class ProdutoAbstrato
{
    public abstract decimal CalcularPreco();
}

public sealed class ProdutoFisico : ProdutoAbstrato
{
    public ProdutoFisico(decimal valorBase, decimal frete)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(valorBase);
        ArgumentOutOfRangeException.ThrowIfNegative(frete);
        ValorBase = valorBase;
        Frete = frete;
    }

    public decimal ValorBase { get; }

    public decimal Frete { get; }

    public override decimal CalcularPreco() => ValorBase + Frete;
}

public sealed class ProdutoServico : ProdutoAbstrato
{
    public ProdutoServico(decimal valorBase, decimal taxa)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(valorBase);
        ArgumentOutOfRangeException.ThrowIfNegative(taxa);
        ValorBase = valorBase;
        Taxa = taxa;
    }

    public decimal ValorBase { get; }

    public decimal Taxa { get; }

    public override decimal CalcularPreco() => ValorBase + Taxa;
}

// Q47 - Cliente e fornecedor compartilham a mesma base.
public class PessoaComercial
{
    public string Nome { get; set; } = string.Empty;
}

public sealed class Cliente : PessoaComercial
{
    public string Comprar() => $"{Nome} comprando...";
}

public sealed class Fornecedor : PessoaComercial
{
    public string Fornecer() => $"{Nome} fornecendo...";
}

// Q48 - Classes abstratas para arquivos.
public abstract class Arquivo
{
    public string Nome { get; set; } = string.Empty;

    public long Tamanho { get; set; }

    public abstract string Abrir();
}

public sealed class ArquivoTexto : Arquivo
{
    public override string Abrir() => Tamanho > 0 ? $"Abrindo texto {Nome}" : "Arquivo vazio";
}

public sealed class ArquivoBinario : Arquivo
{
    public override string Abrir() => Tamanho > 0 ? $"Abrindo binário {Nome}" : "Arquivo vazio";
}

// Q49 - Saque virtual com limite na conta corrente.
public abstract class ContaBancariaAbstrata
{
    protected ContaBancariaAbstrata(decimal saldo = 0m)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(saldo);
        Saldo = saldo;
    }

    public decimal Saldo { get; protected set; }

    public virtual bool Sacar(decimal valor)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(valor);

        if (valor > Saldo)
            return false;

        Saldo -= valor;
        return true;
    }
}

public sealed class ContaCorrente : ContaBancariaAbstrata
{
    public ContaCorrente(decimal saldo = 0m) : base(saldo)
    {
    }

    public decimal Limite { get; set; }

    public override bool Sacar(decimal valor)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(valor);

        if (valor > Saldo + Limite)
            return false;

        Saldo -= valor;
        return true;
    }
}

public sealed class ContaInvestimento : ContaBancariaAbstrata
{
    public ContaInvestimento(decimal saldo = 0m) : base(saldo)
    {
    }

    public void Render(decimal taxa)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(taxa);
        Saldo += Saldo * taxa;
    }
}

// Q50 - Classe abstrata e interface em dispositivos.
public interface ITelaTouch
{
    string Tocar(int x, int y);
}

public abstract class Dispositivo
{
    public abstract string Ligar();
}

public sealed class Smartphone : Dispositivo, ITelaTouch
{
    public override string Ligar() => "Smartphone ligado";

    public string Tocar(int x, int y) => $"Smartphone toque em ({x},{y})";
}

public sealed class Tablet : Dispositivo, ITelaTouch
{
    public override string Ligar() => "Tablet ligado";

    public string Tocar(int x, int y) => $"Tablet toque em ({x},{y})";
}
