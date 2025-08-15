# MauiBrownianMotion

Simulador de Movimento Browniano para Finanças usando .NET MAUI

## Descrição

Este projeto é uma aplicação desktop .NET MAUI para Windows que simula o movimento browniano (processo estocástico) aplicado a preços de ativos financeiros. O usuário pode ajustar parâmetros como preço inicial, volatilidade, retorno médio e tempo, e visualizar o gráfico gerado em tempo real.

## Funcionalidades

-   Interface moderna e responsiva
-   Simulação de movimento browniano com parâmetros customizáveis
-   Visualização gráfica interativa usando GraphicsView
-   Padrão MVVM (Model-View-ViewModel)
-   Suporte a tema escuro

## Parâmetros de Entrada

-   **Preço inicial**: valor inicial do ativo
-   **Volatilidade média (%)**: volatilidade anual em porcentagem (ex: 20 para 20%)
-   **Retorno médio (%)**: retorno médio anual em porcentagem (ex: 1 para 1%)
-   **Tempo (dias)**: número de dias da simulação

## Como executar

1. Clone o repositório:
    ```
    git clone https://github.com/carlosescomosilva/net-maui-brownian-motion.git
    ```
2. Abra a solução `MauiBrownianMotion.sln` no Visual Studio 2022 ou superior.
3. Selecione a plataforma **Windows**.
4. Compile e execute o projeto.

## Estrutura do Projeto

```
MauiBrownianMotion/
├── MauiBrownianMotion.sln                # Solução principal
├── MauiBrownianMotion/                   # Projeto principal
│   ├── App.xaml / App.xaml.cs            # Configuração global do app
│   ├── AppShell.xaml / AppShell.xaml.cs  # Navegação Shell
│   ├── MauiProgram.cs                    # Configuração de DI e inicialização
│   ├── Models/
│   │   └── BrownianMotionModel.cs        # Lógica do movimento browniano
│   ├── ViewModels/
│   │   └── MainViewModel.cs              # Lógica MVVM e comandos
│   ├── Views/
│   │   ├── MainPage.xaml / .cs           # Tela principal
│   │   └── Controls/
│   │       └── BrownianMotionDrawable.cs # Desenho do gráfico
│   ├── Resources/
│   │   ├── AppIcon/                      # Ícones
│   │   ├── Fonts/                        # Fontes customizadas
│   │   ├── Images/                       # Imagens
│   │   ├── Raw/                          # Arquivos auxiliares
│   │   ├── Splash/                       # Splash screen
│   │   └── Styles/                       # Temas e cores
│   ├── Platforms/Windows/                # Específicos do Windows
│   ├── Properties/                       # launchSettings.json
│   └── ... (bin, obj, etc)
└── README.md
```

## Instruções para Build e Execução

1. **Pré-requisitos:**

    - Visual Studio 2022 ou superior
    - .NET 8 ou superior
    - Workload MAUI instalado

2. **Clone o repositório:**

    ```sh
    git clone https://github.com/carlosescomosilva/net-maui-brownian-motion.git
    cd net-maui-brownian-motion/MauiBrownianMotion
    ```

3. **Abra a solução:**

    - Abra o arquivo `MauiBrownianMotion.sln` no Visual Studio.

4. **Selecione a plataforma Windows:**

    - No topo do Visual Studio, selecione a configuração `Debug` e a plataforma `Windows`.

5. **Compile e execute:**

    - Pressione `F5` ou clique em "Iniciar" para rodar o app.

6. **Utilize a interface:**
    - Preencha os parâmetros desejados e clique em "Gerar simulação" para visualizar o gráfico.

## Tecnologias

-   [.NET MAUI](https://learn.microsoft.com/dotnet/maui/)
-   C#
-   MVVM

## Licença

MIT

---

Desenvolvido por carlosecosmesilva
