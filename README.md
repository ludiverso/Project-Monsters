## Sobre o Projeto

Este projeto é um jogo mobile open-source desenvolvido na Unity, pensado especialmente para crianças pequenas, com foco em oferecer uma experiência calma, acessível e acolhedora.

A ideia nasceu a partir de desenhos de monstros feitos por uma criança, que passaram a inspirar os personagens, o mundo e a identidade visual do jogo. Nosso objetivo é transformar imaginação em brincadeira por meio de uma experiência 2D side-scroller simples, com interações amigáveis, ambientes coloridos e jogabilidade com baixa frustração.

O jogo está sendo desenvolvido com acessibilidade, simplicidade e conforto emocional em mente. É voltado para crianças de 3 a 6 anos e busca proporcionar uma experiência gentil, com controles por toque intuitivos, feedbacks suaves e sem mecânicas punitivas como morte, barra de vida ou tela de game over.

Este também é um projeto open-source colaborativo, e recebemos contribuições de desenvolvedores, artistas, educadores e qualquer pessoa que queira ajudar a construir algo significativo.

## Tecnologias

- Unity `6000.4.0f1`
- .NET SDK `10.0.201` (definido em `global.json`)
- [go-task](https://taskfile.dev/) para comandos de desenvolvimento
- [Husky.Net](https://www.nuget.org/packages/Husky) para hooks de Git

## Requisitos

- Unity Hub + Unity Editor `6000.4.0f1`
- .NET SDK compativel com `global.json`
- Git
- Task

## Onboarding local

1. Clone o repositorio:

```bash
git clone https://github.com/ludiverso/Project-Monsters.git
cd Project-Monsters
```

2. Abra o projeto no Unity `6000.4.0f1`.
3. Gere os arquivos de projeto C# pelo Unity (solution/csproj).
4. Restaure as ferramentas locais:

```bash
dotnet tool restore
```

5. Instale os hooks:

```bash
dotnet husky install
```

6. Valide o setup:

```bash
task format:check
```

## Comandos principais

- Formatar codigo C#:

```bash
task format
```

- Verificar formatacao sem alterar arquivos:

```bash
task format:check
```

## Qualidade e CI

- O hook de `pre-commit` executa `task format:check`.
- O GitHub Actions executa o mesmo check em Pull Requests.
- Se a formatacao estiver fora do padrao, o commit/CI falha.

## Como contribuir

1. Crie uma branch a partir da branch de desenvolvimento.
2. Faca mudancas pequenas e com commits descritivos.
3. Garanta que `task format:check` passa localmente.
4. Abra um Pull Request explicando o que foi alterado e o motivo.
