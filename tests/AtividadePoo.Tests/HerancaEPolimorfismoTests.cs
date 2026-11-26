using AtividadePoo.Sections.Section04;
using AtividadePoo.Sections.Section05;

namespace AtividadePoo.Tests;

/// <summary>Testes representativos das questões 31 a 50.</summary>
public class HerancaEPolimorfismoTests
{
    [Fact]
    public void Q31_Cachorro_DeveSobrescreverFazerSom()
    {
        AnimalQueFazSom animal = new Cachorro();

        Assert.Equal("Latir", animal.FazerSom());
        Assert.Equal("Som", new AnimalQueFazSom().FazerSom());
    }

    [Fact]
    public void Q32_CarroComBuzina_DeveHerdarVelocidadeEBuzinar()
    {
        var carro = new CarroComBuzina { Velocidade = 60 };

        Assert.Equal("Biiip!", carro.Buzinar());
        Assert.Equal(60, carro.Velocidade);
    }

    [Fact]
    public void Q33_QuadradoAbstrato_DeveCalcularArea()
    {
        FormaAbstrata forma = new QuadradoAbstrato(6);

        Assert.Equal(36, forma.Area());
        Assert.Throws<ArgumentOutOfRangeException>(() => new QuadradoAbstrato(0));
    }

    [Fact]
    public void Q34_AlunoHeranca_DeveHerdarNome()
    {
        var aluno = new AlunoHeranca { Nome = "Nina", Idade = 20, Nota = 9.8 };

        Assert.Equal("Nina", aluno.Nome);
        Assert.Equal("Nina estudando...", aluno.Estudar());
        Assert.Equal(20, aluno.Idade);
    }

    [Fact]
    public void Q35_ContaPoupanca_DeveRenderJuros()
    {
        var conta = new ContaPoupanca();
        conta.Depositar(1000m);
        conta.RenderJuros();

        Assert.Equal(1010m, conta.Saldo);
    }

    [Fact]
    public void Q36_Gerente_DeveSomarSalarioBaseEBonus()
    {
        var gerente = new Gerente { SalarioBase = 4000m, Bonus = 800m };

        Assert.Equal(4800m, gerente.SalarioTotal());
    }

    [Fact]
    public void Q37_ProdutoDigital_DeveHerdarPrecoEBaixar()
    {
        var produto = new ProdutoDigital { Preco = 59.90m, TamanhoArquivoBytes = 2048 };

        Assert.Equal(59.90m, produto.Preco);
        Assert.Equal("Baixando 2048 bytes...", produto.Baixar());
    }

    [Fact]
    public void Q38_Aviao_DeveSobrescreverMover()
    {
        Transporte transporte = new Aviao { Altitude = 10000 };

        Assert.Equal("Voar", transporte.Mover());
        Assert.Equal(10000, ((Aviao)transporte).Altitude);
    }

    [Fact]
    public void Q39_JogoOnline_DeveConectarAoServidor()
    {
        var jogo = new JogoOnline { Nome = "RPG-Z", Servidor = "BR-1" };

        Assert.Equal("Conectando ao BR-1...", jogo.Conectar());
        Assert.Equal("RPG-Z", jogo.Nome);
    }

    [Fact]
    public void Q40_LivroERevista_DevemHerdarTitulo()
    {
        var livro = new LivroDaBiblioteca { Titulo = "POO Essencial", Autor = "Dev X" };
        var revista = new Revista { Titulo = "Tech Monthly", Edicao = 42 };

        Assert.Equal("Dev X", livro.Autor);
        Assert.Equal("Tech Monthly", revista.Titulo);
        Assert.Equal(42, revista.Edicao);
    }

    [Fact]
    public void Q41_Animais_DevemComerDeFormaDiferente()
    {
        List<AnimalQueCome> animais = [new Mamifero(), new Ave()];

        Assert.Equal(["Mamífero comendo", "Ave bicando"], animais.Select(animal => animal.Comer()));
    }

    [Fact]
    public void Q42_EmpregadosAbstratos_DevemCalcularSalario()
    {
        EmpregadoAbstrato horista = new Horista(160, 25m);
        EmpregadoAbstrato assalariado = new Assalariado(3000m);

        Assert.Equal(4000m, horista.CalcularSalario());
        Assert.Equal(3000m, assalariado.CalcularSalario());
    }

    [Fact]
    public void Q43_CalculadoraDePerimetro_DeveAceitarQualquerForma()
    {
        Assert.Equal(16, CalculadoraDePerimetro.Calcular(new RetanguloGeometrico(5, 3)));
        Assert.Equal(2 * Math.PI * 2, CalculadoraDePerimetro.Calcular(new CirculoGeometrico(2)), 10);
    }

    [Fact]
    public void Q44_Veiculos_DevemAcelerarPorPolimorfismo()
    {
        VeiculoQueAcelera bicicleta = new Bicicleta();
        VeiculoQueAcelera moto = new Moto();

        Assert.Equal("Pedalando mais rápido", bicicleta.Acelerar());
        Assert.Equal("Acelerando motor", moto.Acelerar());
    }

    [Fact]
    public void Q45_Triatleta_DeveImplementarDuasInterfaces()
    {
        INadador nadador = new Triatleta();
        ICorredor corredor = (ICorredor)nadador;

        Assert.Equal("Triatleta nadando", nadador.Nadar());
        Assert.Equal("Triatleta correndo", corredor.Correr());
        Assert.Equal("Triatleta competindo!", ((Triatleta)corredor).Competir());
    }

    [Fact]
    public void Q46_ProdutosAbstratos_DevemCalcularPreco()
    {
        ProdutoAbstrato fisico = new ProdutoFisico(100m, 20m);
        ProdutoAbstrato servico = new ProdutoServico(150m, 30m);

        Assert.Equal(120m, fisico.CalcularPreco());
        Assert.Equal(180m, servico.CalcularPreco());
    }

    [Fact]
    public void Q47_ClienteEFornecedor_DevemHerdarPessoaComercial()
    {
        List<PessoaComercial> pessoas = [new Cliente { Nome = "Lia" }, new Fornecedor { Nome = "Zé" }];

        Assert.Equal("Lia comprando...", ((Cliente)pessoas[0]).Comprar());
        Assert.Equal("Zé fornecendo...", ((Fornecedor)pessoas[1]).Fornecer());
    }

    [Fact]
    public void Q48_Arquivos_DevemAbrirSegundoTamanho()
    {
        Arquivo texto = new ArquivoTexto { Nome = "leia.txt", Tamanho = 10 };
        Arquivo vazio = new ArquivoBinario { Nome = "img.bin", Tamanho = 0 };

        Assert.Equal("Abrindo texto leia.txt", texto.Abrir());
        Assert.Equal("Arquivo vazio", vazio.Abrir());
    }

    [Fact]
    public void Q49_ContaCorrente_DeveUsarLimiteNoSaque()
    {
        var corrente = new ContaCorrente(saldo: 100m) { Limite = 50m };
        var investimento = new ContaInvestimento(saldo: 1000m);
        investimento.Render(0.05m);

        Assert.True(corrente.Sacar(120m));
        Assert.Equal(-20m, corrente.Saldo);
        Assert.False(corrente.Sacar(1000m));
        Assert.Equal(1050m, investimento.Saldo);
    }

    [Fact]
    public void Q50_Dispositivos_DevemLigarEToqueNaTela()
    {
        Dispositivo smartphone = new Smartphone();
        Dispositivo tablet = new Tablet();

        Assert.Equal("Smartphone ligado", smartphone.Ligar());
        Assert.Equal("Smartphone toque em (10,20)", ((ITelaTouch)smartphone).Tocar(10, 20));
        Assert.Equal("Tablet ligado", tablet.Ligar());
        Assert.Equal("Tablet toque em (5,7)", ((ITelaTouch)tablet).Tocar(5, 7));
    }
}
