# Sobre o Projeto

Este projeto é um jogo mobile open-source desenvolvido na Unity, pensado especialmente para crianças pequenas, com foco em oferecer uma experiência calma, acessível e acolhedora.

A ideia nasceu a partir dos desenhos do Bryan, um pequeno artista de 4 anos, filho de [@olivioCk](https://github.com/olivioCk). Seus monstros, rabiscos e personagens passaram a inspirar o universo visual e criativo do projeto. Nossa missão é dar vida a esses desenhos com carinho, transformando imaginação em brincadeira por meio de uma experiência 2D side-scroller simples, com interações amigáveis, ambientes coloridos e jogabilidade de baixa frustração.

O jogo está sendo desenvolvido com acessibilidade, simplicidade e conforto emocional em mente. É voltado para crianças de 3 a 6 anos e busca proporcionar uma experiência gentil, com controles por toque intuitivos, feedbacks suaves e sem mecânicas punitivas como morte, barra de vida ou tela de game over.

Este também é um projeto colaborativo e transparente. Acreditamos que a tecnologia pode ser uma ferramenta de afeto, expressão e inclusão. Se você é desenvolvedor, artista, educador ou alguém que acredita em construir algo com significado, sua contribuição será muito bem-vinda.

## Tecnologias

- Unity `6.3 TLS`
- .NET SDK `10.0.105 LTS`
- [Husky.Net](https://www.nuget.org/packages/Husky) para hooks de Git

## Requisitos

- Unity Hub (Opcional)
- Unity `6.3 TLS`
- .NET SDK `10.0.105 LTS`

## Como rodar

```bash
# Clone o repositório:
git clone https://github.com/ludiverso/Project-Monsters.git

# Acesse o diretorio do projeto:
cd Project-Monsters

# Rode os comandos necessários:
dotnet tool restore && dotnet husky install
```

## Qualidade e CI

- O hook de `pre-commit` verifica a formatação do código C#.
- O hook de `commit-msg` valida as mensagens de commit no padrão conventional commits.
- O GitHub Actions valida a formatação e as mensagens de commit.
- Se alguma dessas validações falhar, o commit ou o CI será interrompido.

## Créditos

Este projeto conta com a dedicação e a colaboração de:

[@olivioCk](https://github.com/olivioCk)
[@bgandrade](https://github.com/bgandrade)
[@iagoscandido](https://github.com/iagoscandido)
[@iohanaallen](https://github.com/iohanaallen)
[@thadeucruz-ux](https://github.com/thadeucruz-ux)
[@bhya-ray](https://github.com/bhya-ray)
