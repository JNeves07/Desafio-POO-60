using AtividadePoo.Sections.Section03;

namespace AtividadePoo.Tests;

/// <summary>Testes representativos das questões 21 a 30.</summary>
public class EncapsulamentoTests
{
    [Fact]
    public void Q21_PessoaComIdade_DeveValidarIdade()
    {
        var pessoa = new PessoaComIdade { Idade = 25 };

        Assert.Equal(25, pessoa.Idade);
        Assert.Throws<ArgumentOutOfRangeException>(() => pessoa.Idade = -1);
        Assert.Throws<ArgumentOutOfRangeException>(() => pessoa.Idade = 200);
    }

    [Fact]
    public void Q22_Conta_DeveDepositarESacar()
    {
        var conta = new Conta();
        conta.Depositar(100m);

        Assert.True(conta.Sacar(30m));
        Assert.Equal(70m, conta.Saldo);
        Assert.False(conta.Sacar(200m));
        Assert.Equal(70m, conta.Saldo);
    }

    [Fact]
    public void Q23_AlunoComNota_DeveRejeitarNotaForaDoIntervalo()
    {
        var aluno = new AlunoComNota { Nota = 9.5 };

        Assert.Equal(9.5, aluno.Nota);
        Assert.Throws<ArgumentOutOfRangeException>(() => aluno.Nota = 11);
        Assert.Throws<ArgumentOutOfRangeException>(() => aluno.Nota = -1);
    }

    [Fact]
    public void Q24_ProdutoComDesconto_NaoDeveFicarNegativo()
    {
        var produto = new ProdutoComDesconto(50m);
        produto.AplicarDesconto(60m);

        Assert.Equal(0m, produto.Preco);
        Assert.Throws<ArgumentOutOfRangeException>(() => produto.AplicarDesconto(-1m));
    }

    [Fact]
    public void Q25_CarroComVelocidadeMaxima_DeveLimitarA200()
    {
        var carro = new CarroComVelocidadeMaxima();
        carro.Acelerar(250);

        Assert.Equal(200, carro.Velocidade);
        Assert.Throws<ArgumentOutOfRangeException>(() => carro.Acelerar(-10));
    }

    [Fact]
    public void Q26_UsuarioComSenha_DeveAutenticarSomenteSenhaCorreta()
    {
        var usuario = new UsuarioComSenha("1234");

        Assert.True(usuario.Autenticar("1234"));
        Assert.False(usuario.Autenticar("4321"));
        Assert.Throws<ArgumentException>(() => new UsuarioComSenha(" "));
    }

    [Fact]
    public void Q27_Banco_NaoDeveDuplicarContas()
    {
        var banco = new Banco();
        banco.Adicionar(1);
        banco.Adicionar(2);
        banco.Adicionar(2);

        Assert.Equal([1, 2], banco.Listar());
        Assert.True(banco.Remover(1));
        Assert.False(banco.Remover(1));
    }

    [Fact]
    public void Q28_FormaSomenteLeitura_DeveExporSomenteGet()
    {
        var forma = new FormaSomenteLeitura(12.5);

        Assert.Equal(12.5, forma.Area);
        Assert.Throws<ArgumentOutOfRangeException>(() => new FormaSomenteLeitura(-1));
    }

    [Fact]
    public void Q29_EmpregadoComBonus_DeveCalcularDezPorCento()
    {
        Assert.Equal(200m, new EmpregadoComBonus(2000m).CalcularBonus());
    }

    [Fact]
    public void Q30_Configuracao_DeveGuardarELerChaves()
    {
        var configuracao = new Configuracao();
        configuracao.Set("tema", "escuro");

        Assert.Equal("escuro", configuracao.Get("TEMA"));
        Assert.Null(configuracao.Get("inexistente"));
        Assert.Throws<ArgumentException>(() => configuracao.Set("", "valor"));
    }
}
