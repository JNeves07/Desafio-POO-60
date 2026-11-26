using AtividadePoo.Sections.Section06;

namespace AtividadePoo.Tests;

/// <summary>Testes representativos das questões 51 a 60.</summary>
public class ClassesAbstratasTests
{
    [Fact]
    public void Q51_Formas_DevemCalcularArea()
    {
        FormaParaArea triangulo = new TrianguloParaArea(5, 4);
        FormaParaArea retangulo = new RetanguloParaArea(3, 7);

        Assert.Equal(10, triangulo.Area());
        Assert.Equal(21, retangulo.Area());
    }

    [Fact]
    public void Q52_Animais_DevemMover()
    {
        AnimalQueMove peixe = new Peixe();
        AnimalQueMove passaro = new Passaro();

        Assert.Equal("Nadar", peixe.Mover());
        Assert.Equal("Voar", passaro.Mover());
    }

    [Fact]
    public void Q53_Pagamentos_DevemProcessarValor()
    {
        Pagamento cartao = new CartaoCredito();
        Pagamento boleto = new Boleto();

        Assert.Contains("Cartão aprovado", cartao.Processar(200m));
        Assert.Contains("Boleto gerado", boleto.Processar(150m));
        Assert.Throws<ArgumentOutOfRangeException>(() => cartao.Processar(0m));
    }

    [Fact]
    public void Q54_Funcionarios_DevemCalcularBonus()
    {
        FuncionarioComBonus vendedor = new Vendedor(50000m);
        FuncionarioComBonus engenheiro = new Engenheiro();

        Assert.Equal(2500m, vendedor.CalcularBonus());
        Assert.Equal(1000m, engenheiro.CalcularBonus());
    }

    [Fact]
    public void Q55_Veiculos_DevemCalcularConsumoEViagem()
    {
        VeiculoCombustivel eletrico = new CarroEletrico();
        VeiculoCombustivel gasolina = new CarroGasolina();

        Assert.Equal(15, eletrico.CalcularCombustivel(100), 10);
        Assert.Equal(100.0 / 12.0, gasolina.CalcularCombustivel(100), 10);
        Assert.Equal("Viajando 50 km de carro elétrico", eletrico.Viajar(50));
        Assert.Equal("Viajando 50 km de carro a gasolina", gasolina.Viajar(50));
    }

    [Fact]
    public void Q56_Estrategias_DevemSerIntercambiaveis()
    {
        Estrategia ataque = new Ataque();
        Estrategia defesa = new Defesa();

        Assert.Equal("Estratégia de ATAQUE!", ataque.Executar());
        Assert.Equal("Estratégia de DEFESA!", defesa.Executar());
    }

    [Fact]
    public void Q57_Relatorios_DevemGerarConteudo()
    {
        Relatorio pdf = new RelatorioPdf();
        Relatorio excel = new RelatorioExcel();

        Assert.Contains("PDF", pdf.Gerar());
        Assert.Contains("Excel", excel.Gerar());
    }

    [Fact]
    public void Q58_ItensDeMenu_DevemPreparar()
    {
        ItemMenu prato = new PratoPrincipal();
        ItemMenu sobremesa = new Sobremesa();

        Assert.Equal("Preparando prato principal...", prato.Preparar());
        Assert.Equal("Preparando sobremesa...", sobremesa.Preparar());
    }

    [Fact]
    public void Q59_Notificadores_DevemValidarMensagemEUsarCanal()
    {
        Notificador email = new EmailNotificador();
        Notificador sms = new SmsNotificador();

        Assert.Equal("Email: Olá", email.Enviar("Olá"));
        Assert.Equal("SMS: Olá", sms.Enviar("Olá"));
        Assert.Throws<ArgumentException>(() => email.Enviar(" "));
    }

    [Fact]
    public void Q60_Simuladores_DevemExigirInicioAntesDeExecutar()
    {
        Simulador jogo = new SimuladorJogo();
        Simulador treinamento = new SimuladorTreinamento();

        Assert.Throws<InvalidOperationException>(() => jogo.Executar());
        Assert.Throws<InvalidOperationException>(() => treinamento.Executar());

        jogo.Iniciar();
        jogo.Executar();
        jogo.Finalizar();
        treinamento.Iniciar();
        treinamento.Executar();
        treinamento.Finalizar();

        Assert.Throws<InvalidOperationException>(() => jogo.Executar());
    }
}
