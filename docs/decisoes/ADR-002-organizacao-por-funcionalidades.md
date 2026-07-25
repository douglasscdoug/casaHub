# ADR-002 — Organização por Funcionalidades

## Status

Aceito

---

## Contexto

O CasaHub possui diversos módulos independentes, como:

- Dashboard
- Financeiro
- Compras
- Tarefas
- Calendário
- Moradores

Organizar o código apenas por tipo (Services, Models, Controllers etc.) tende a dificultar a manutenção conforme o projeto cresce.

---

## Decisão

O backend e o frontend serão organizados por funcionalidades (Feature-Based).

Cada funcionalidade concentrará seus próprios componentes, serviços, modelos e demais artefatos relacionados.

Exemplo:

```text
Financeiro/
Compras/
Dashboard/
Moradores/
```

---

## Consequências

### Positivas

- Maior coesão.
- Menor acoplamento.
- Melhor organização.
- Facilidade para localizar código.
- Escalabilidade.

### Negativas

- Pode gerar duplicação de estruturas entre funcionalidades.
- Exige disciplina para evitar dependências indevidas entre módulos.

---

## Data

2026-07-24