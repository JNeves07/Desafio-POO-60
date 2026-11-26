namespace AtividadePoo.Sections.Section06;

/// <summary>Questões 51 a 60: classes abstratas.</summary>
public static class Secao06
{
    public static string Titulo => "Seção 6: Classes Abstratas (Q51-Q60)";

    public static IReadOnlyList<string> Executar()
    {
        var linhas = new List<string>();

        // Q51
        FormaParaArea triangulo = new TrianguloParaArea(5, 4);
        FormaParaArea retangulo = new RetanguloParaArea(3, 7);
        linhas.Add($"Q51: Triângulo área={triangulo.Area()}, Retangulo área={retangulo.Area()}");

        // Q52
        AnimalQueMove peixe = new Peixe();
        AnimalQueMove passaro = new Passaro();
        linhas.Add($"Q52: Peixe={peixe.Mover()}, Pássaro={passaro.Mover()}");

        // Q53
        Pagamento cartao = new CartaoCredito();
        Pagamento boleto = new Boleto();
        linhas.Add($"Q53: {cartao.Processar(200m)} | {boleto.Processar(150m)}");

        // Q54
        FuncionarioComBonus vendedor = new Vendedor(50000m);
        FuncionarioComBonus engenheiro = new Engenheiro();
        linhas.Add(
            $"Q54: Bônus Vendedor={Formatacao.Moeda(vendedor.CalcularBonus())}, " +
            $"Engenheiro={Formatacao.Moeda(engenheiro.CalcularBonus())}");

        // Q55
        VeiculoCombustivel eletrico = new CarroEletrico();
        VeiculoCombustivel gasolina = new CarroGasolina();
        linhas.Add(
            $"Q55: Elétrico consumo(100km)={Formatacao.Numero(eletrico.CalcularCombustivel(100), "F2")}, " +
            $"Gasolina={Formatacao.Numero(gasolina.CalcularCombustivel(100), "F2")} | " +
            $"{eletrico.Viajar(50)} | {gasolina.Viajar(50)}");

        // Q56
        Estrategia ataque = new Ataque();
        Estrategia defesa = new Defesa();
        linhas.Add($"Q56: {ataque.Executar()} | {defesa.Executar()}");

        // Q57
        Relatorio pdf = new RelatorioPdf();
        Relatorio excel = new RelatorioExcel();
        linhas.Add($"Q57: {pdf.Gerar()} | {excel.Gerar()}");

        // Q58
        ItemMenu principal = new PratoPrincipal();
        ItemMenu sobremesa = new Sobremesa();
        linhas.Add($"Q58: {principal.Preparar()} | {sobremesa.Preparar()}");

        // Q59
        Notificador email = new EmailNotificador();
        Notificador sms = new SmsNotificador();
        linhas.Add($"Q59: {email.Enviar("Olá por Email")} | {sms.Enviar("Olá por SMS")}");

        // Q60
        var simuladorJogo = new SimuladorJogo();
        simuladorJogo.Iniciar();
        simuladorJogo.Executar();
        simuladorJogo.Finalizar();
        var simuladorTreinamento = new SimuladorTreinamento();
        simuladorTreinamento.Iniciar();
        simuladorTreinamento.Executar();
        simuladorTreinamento.Finalizar();
        linhas.Add("Q60: Simulações de jogo e treinamento concluídas.");

        return linhas;
    }
}

// Q51 - Formas abstratas com cálculo de área.
public abstract class FormaParaArea
{
    public abstract double Area();
}

public sealed class TrianguloParaArea : FormaParaArea
{
    public TrianguloParaArea(double baseTriangulo, double altura)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(baseTriangulo);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(altura);
        Base = baseTriangulo;
        Altura = altura;
    }

    public double Base { get; }

    public double Altura { get; }

    public override double Area() => (Base * Altura) / 2;
}

public sealed class RetanguloParaArea : FormaParaArea
{
    public RetanguloParaArea(double largura, double altura)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(largura);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(altura);
        Largura = largura;
        Altura = altura;
    }

    public double Largura { get; }

    public double Altura { get; }

    public override double Area() => Largura * Altura;
}

// Q52 - Animais com forma de locomoção abstrata.
public abstract class AnimalQueMove
{
    public abstract string Mover();
}

public sealed class Peixe : AnimalQueMove
{
    public override string Mover() => "Nadar";
}

public sealed class Passaro : AnimalQueMove
{
    public override string Mover() => "Voar";
}

// Q53 - Processamento polimórfico de pagamentos.
public abstract class Pagamento
{
    public abstract string Processar(decimal valor);
}

public sealed class CartaoCredito : Pagamento
{
    public override string Processar(decimal valor)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(valor);
        return $"Cartão aprovado: {Formatacao.Moeda(valor)}";
    }
}

public sealed class Boleto : Pagamento
{
    public override string Processar(decimal valor)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(valor);
        return $"Boleto gerado: {Formatacao.Moeda(valor)}";
    }
}

// Q54 - Bônus por tipo de funcionário.
public abstract class FuncionarioComBonus
{
    public abstract decimal CalcularBonus();
}

public sealed class Vendedor : FuncionarioComBonus
{
    public Vendedor(decimal vendas)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(vendas);
        Vendas = vendas;
    }

    public decimal Vendas { get; }

    public override decimal CalcularBonus() => Vendas * 0.05m;
}

public sealed class Engenheiro : FuncionarioComBonus
{
    public override decimal CalcularBonus() => 1000m;
}

// Q55 - Consumo e viagem abstratos.
public abstract class VeiculoCombustivel
{
    public abstract double CalcularCombustivel(double distancia);

    public abstract string Viajar(double distancia);
}

public sealed class CarroEletrico : VeiculoCombustivel
{
    public override double CalcularCombustivel(double distancia)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(distancia);
        return distancia * 0.15;
    }

    public override string Viajar(double distancia) => $"Viajando {distancia} km de carro elétrico";
}

public sealed class CarroGasolina : VeiculoCombustivel
{
    public override double CalcularCombustivel(double distancia)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(distancia);
        return distancia / 12.0;
    }

    public override string Viajar(double distancia) => $"Viajando {distancia} km de carro a gasolina";
}

// Q56 - Estratégias intercambiáveis.
public abstract class Estrategia
{
    public abstract string Executar();
}

public sealed class Ataque : Estrategia
{
    public override string Executar() => "Estratégia de ATAQUE!";
}

public sealed class Defesa : Estrategia
{
    public override string Executar() => "Estratégia de DEFESA!";
}

// Q57 - Geração de relatórios.
public abstract class Relatorio
{
    public abstract string Gerar();
}

public sealed class RelatorioPdf : Relatorio
{
    public override string Gerar() => "Relatório PDF: [conteúdo simulado]";
}

public sealed class RelatorioExcel : Relatorio
{
    public override string Gerar() => "Relatório Excel: [conteúdo simulado]";
}

// Q58 - Itens de cardápio.
public abstract class ItemMenu
{
    public abstract string Preparar();
}

public sealed class PratoPrincipal : ItemMenu
{
    public override string Preparar() => "Preparando prato principal...";
}

public sealed class Sobremesa : ItemMenu
{
    public override string Preparar() => "Preparando sobremesa...";
}

// Q59 - Notificadores com mensagem validada.
public abstract class Notificador
{
    public string Enviar(string mensagem)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(mensagem);
        return $"{Canal}: {mensagem}";
    }

    protected abstract string Canal { get; }
}

public sealed class EmailNotificador : Notificador
{
    protected override string Canal => "Email";
}

public sealed class SmsNotificador : Notificador
{
    protected override string Canal => "SMS";
}

// Q60 - Ciclo de vida de simuladores.
public abstract class Simulador
{
    public abstract void Iniciar();

    public abstract void Executar();

    public abstract void Finalizar();
}

public sealed class SimuladorJogo : Simulador
{
    private bool _iniciado;

    public override void Iniciar()
    {
        _iniciado = true;
    }

    public override void Executar()
    {
        if (!_iniciado)
            throw new InvalidOperationException("O simulador de jogo precisa ser iniciado antes de executar.");
    }

    public override void Finalizar()
    {
        _iniciado = false;
    }
}

public sealed class SimuladorTreinamento : Simulador
{
    private bool _iniciado;

    public override void Iniciar()
    {
        _iniciado = true;
    }

    public override void Executar()
    {
        if (!_iniciado)
            throw new InvalidOperationException("O simulador de treinamento precisa ser iniciado antes de executar.");
    }

    public override void Finalizar()
    {
        _iniciado = false;
    }
}
