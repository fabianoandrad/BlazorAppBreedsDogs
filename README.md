<div align="center">

# 🐶 Breeds Dogs

**Explore raças de cães em um aplicativo nativo com .NET MAUI e Blazor Hybrid.**

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23- Linguagem-239120?logo=csharp&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/)
[![MAUI](https://img.shields.io/badge/.NET%20MAUI-aplicativo%20multiplataforma-512BD4)](https://learn.microsoft.com/dotnet/maui/)

</div>

## Sobre o projeto

O **Breeds Dogs** é um aplicativo multiplataforma feito com **.NET MAUI Blazor Hybrid**. Ele combina uma interface criada com Blazor com recursos de um aplicativo nativo para consultar e explorar informações sobre diferentes raças de cães.

Os dados são obtidos de uma API externa e apresentados em cartões com informações e imagens das raças.

## Funcionalidades

- Listagem de raças de cães obtidas da API.
- Visualização de informações como origem, temperamento, expectativa de vida, peso e altura.
- Imagens ilustrativas das raças.
- Página de detalhes de cada raça.
- Área para consultar raças favoritas.
- Interface responsiva construída com componentes Blazor e MudBlazor.

## Tecnologias

- [C#](https://learn.microsoft.com/dotnet/csharp/)
- [.NET 8](https://dotnet.microsoft.com/)
- [.NET MAUI](https://learn.microsoft.com/dotnet/maui/)
- [Blazor Hybrid](https://learn.microsoft.com/aspnet/core/blazor/hybrid/)
- [MudBlazor](https://mudblazor.com/)
- [Newtonsoft.Json](https://www.newtonsoft.com/json)
- [Breeds Dogs API](https://breeds-dogs-api-node.onrender.com/api/breeds-dogs) — requer autenticação

A API também possui um [repositório próprio](https://github.com/fabianoandrad/breeds-dogs-api-node).

## Plataformas

O projeto está configurado para os seguintes destinos:

- Android
- iOS
- macOS (Mac Catalyst)
- Windows (build disponível em ambiente Windows)

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Workloads do .NET MAUI instalados para a plataforma desejada
- IDE compatível, como [Visual Studio](https://visualstudio.microsoft.com/) com a carga de trabalho **Desenvolvimento de interface do usuário de aplicativos multiplataforma .NET** ou Visual Studio Code com as ferramentas necessárias
- Acesso à API e uma chave válida, pois os endpoints exigem autenticação

> **Segurança:** não publique chaves de API no repositório. Configure credenciais de forma segura para o ambiente em que o aplicativo será executado.

## Como executar

1. Clone o repositório:

   ```bash
   git clone https://github.com/fabianoandrad/BlazorAppBreedsDogs.git
   cd BlazorAppBreedsDogs
   ```

2. Restaure as dependências e workloads do projeto:

   ```bash
   dotnet workload restore BlazorAppBreedsDogs.sln
   dotnet restore BlazorAppBreedsDogs.sln
   ```

3. Abra `BlazorAppBreedsDogs.sln` na sua IDE, selecione um destino instalado (por exemplo, Android Emulator) e execute o projeto.

Para compilar pela linha de comando, informe o framework correspondente ao destino configurado. Por exemplo, para Android:

```bash
dotnet build BlazorAppBreedsDogs/BlazorAppBreedsDogs.csproj -f net8.0-android
```

## Estrutura do projeto

```text
BlazorAppBreedsDogs/
├── Components/       # Componentes, páginas e layout Blazor
├── Models/           # Modelos dos dados das raças
├── Platforms/        # Configurações específicas de cada plataforma MAUI
├── Resources/        # Ícones, fontes, imagens e outros recursos
├── Services/         # Integração com a API, favoritos e estado
└── wwwroot/          # Arquivos estáticos da interface web
```

## Capturas de tela

<div align="center">
  <img width="180" alt="Tela do aplicativo Breeds Dogs" src="https://github.com/user-attachments/assets/51bd55d4-deba-4df5-b409-fbbf67a1c359" />&nbsp;&nbsp;
  <img width="180" alt="Lista de raças no aplicativo" src="https://github.com/user-attachments/assets/2451265b-6ab4-413f-b4d3-e824cf5037c4" />&nbsp;&nbsp;
  <img width="180" alt="Detalhes de uma raça no aplicativo" src="https://github.com/user-attachments/assets/50974c10-d456-4cbe-b308-4753fe6f16c3" />&nbsp;&nbsp;
  <img width="180" alt="Tela de favoritos do aplicativo" src="https://github.com/user-attachments/assets/27990eae-09b0-46ff-9a51-1499c6e149db" />
</div>

## Contribuição

Sugestões e melhorias são bem-vindas. Para contribuir, abra uma issue para relatar uma ideia ou problema, ou envie um pull request com sua proposta.

## Licença

Nenhuma licença foi especificada neste repositório até o momento. Consulte o proprietário antes de reutilizar ou distribuir o código.
