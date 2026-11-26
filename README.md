# Desafio de Fixação de POO (C#)

Resolução organizada das **60 questões** de Programação Orientada a Objetos, migrada de um único arquivo de console para uma biblioteca C# com seções, runner dedicado e testes automatizados.

## Tecnologias

- **.NET 10** (`net10.0`) e **C#**
- **xUnit** para testes automatizados
- **Docker** para executar o runner em contêiner
- **GitHub Actions** para integração contínua (CI)

## Estrutura

```text
Atividade-de-Poo/
├── docs/original/
│   └── DesafioFixacaoPOO.cs           # Arquivo original preservado
├── src/
│   ├── AtividadePoo/                  # Biblioteca com as 60 soluções
│   │   ├── ExecutorDeSecoes.cs
│   │   ├── Formatacao.cs
│   │   └── Sections/
│   │       ├── Section01.cs           # Q1-Q10: classes e objetos
│   │       ├── Section02.cs           # Q11-Q20: métodos e construtores
│   │       ├── Section03.cs           # Q21-Q30: encapsulamento
│   │       ├── Section04.cs           # Q31-Q40: herança básica
│   │       ├── Section05.cs           # Q41-Q50: herança avançada/polimorfismo
│   │       └── Section06.cs           # Q51-Q60: classes abstratas
│   └── AtividadePoo.Cli/              # Runner de console
│       ├── Program.cs
│       └── Runner.cs
├── tests/AtividadePoo.Tests/          # Testes xUnit das 60 questões
├── .github/workflows/ci.yml
├── Dockerfile
└── AtividadePoo.sln
```

Cada seção expõe um método `Executar()` que devolve as linhas correspondentes às suas questões, mantendo as classes com nomes descritivos e separadas por `namespace`.

## Como executar

Pré-requisito: [.NET SDK 10.0](https://dotnet.microsoft.com/download).

```bash
# Todas as seções
dotnet run --project src/AtividadePoo.Cli

# Apenas a seção 3
dotnet run --project src/AtividadePoo.Cli -- --section 3

# Forma alternativa
dotnet run --project src/AtividadePoo.Cli -- --section=3

# Ajuda
dotnet run --project src/AtividadePoo.Cli -- --help
```

### Usando Docker

```bash
docker build -t atividade-poo .
docker run --rm atividade-poo --section 3
```

## Testes

```bash
dotnet test AtividadePoo.sln
```

Os testes cobrem as seis seções (60 questões executadas pelo `ExecutorDeSecoes`) e, de forma direta, mais de 12 questões representativas de encapsulamento, herança, interfaces, classes abstratas, polimorfismo e exceções.

Algumas questões foram endurecidas em relação ao arquivo original: valores inválidos geram exceções (por exemplo, divisão por zero, nota fora de `0..10`, triângulo impossível e simulador executado antes de `Iniciar`) e a formatação de moeda/números usa sempre a cultura `pt-BR`, evitando saídas dependentes da máquina.

## Integração contínua

O workflow `.github/workflows/ci.yml` instala o .NET 10, restaura dependências, compila a solução em `Release` e executa `dotnet test` em cada `push` e `pull request` para `main`/`master`.

## Histórico

O arquivo primitivo `DesafioFixacaoPOO.cs` foi preservado em `docs/original/` antes da refatoração. Ele continha uma duplicação de trechos a partir da metade do arquivo; a versão atual foi reconstruída integralmente.
