# ADR-001 — Arquitetura da Aplicação

## Status

Aceito

---

## Contexto

O CasaHub foi concebido como um projeto de portfólio com objetivo de evoluir para um produto comercial.

Dessa forma, a arquitetura deve favorecer manutenção, escalabilidade, reutilização de código e facilidade de testes.

---

## Decisão

O backend adotará uma arquitetura em camadas composta pelos seguintes projetos:

- API
- Application
- Domain
- Infrastructure

Cada camada possui responsabilidades bem definidas e dependências controladas através de Injeção de Dependência.

O repositório será organizado como um monorepositório contendo:

- backend
- frontend
- documentação

---

## Consequências

### Positivas

- Separação clara de responsabilidades.
- Maior facilidade de manutenção.
- Melhor organização do código.
- Facilidade para testes.
- Evolução independente das camadas.

### Negativas

- Estrutura inicial mais complexa.
- Maior quantidade de projetos na solução.
- Curva de aprendizado maior para novos colaboradores.

---

## Data

2026-07-24