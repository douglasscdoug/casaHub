# Arquitetura do Backend

## Objetivo

O backend do CasaHub é desenvolvido utilizando ASP.NET Core e segue uma arquitetura em camadas, com foco em separação de responsabilidades, baixo acoplamento e facilidade de manutenção.

Essa organização permite que novas funcionalidades sejam implementadas de forma modular, reduzindo impactos em componentes existentes.

---

## Estrutura da Solução

```text
backend/
│
├── src/
│   ├── CasaHub.API
│   ├── CasaHub.Application
│   ├── CasaHub.Domain
│   └── CasaHub.Infrastructure
│
└── tests/
    ├── CasaHub.UnitTests
    └── CasaHub.IntegrationTests
```

---

## Responsabilidade dos Projetos

### CasaHub.API

Responsável pela comunicação HTTP da aplicação.

Principais responsabilidades:

- Controllers
- Configuração da aplicação
- Middleware
- Autenticação e autorização
- Swagger
- Injeção de dependências

---

### CasaHub.Application

Responsável pelos casos de uso da aplicação.

Principais responsabilidades:

- DTOs
- Commands e Queries
- Validações
- Serviços de aplicação
- Mapeamentos
- Interfaces

Esta camada contém a lógica de aplicação, mas não conhece detalhes de infraestrutura.

---

### CasaHub.Domain

Representa o núcleo do negócio.

Principais responsabilidades:

- Entidades
- Enums
- Value Objects (quando utilizados)
- Interfaces de domínio
- Regras de negócio

A camada Domain não possui dependência de outras camadas.

---

### CasaHub.Infrastructure

Responsável pela implementação dos serviços externos.

Principais responsabilidades:

- Entity Framework Core
- DbContext
- Configurações das entidades
- Repositórios
- Migrações
- Serviços de autenticação
- Persistência de dados

---

## Dependência entre Camadas

```text
API
 │
 ▼
Application
 │
 ▼
Domain
 ▲
 │
Infrastructure
```

A camada Infrastructure implementa contratos definidos nas camadas superiores através de Injeção de Dependência.

---

## Organização por Funcionalidades

A camada Application será organizada por funcionalidades (Feature-Based), agrupando todos os artefatos relacionados a um mesmo módulo.

Exemplo:

```text
Application/
│
├── Authentication/
├── Dashboard/
├── Financeiro/
├── Compras/
├── Tarefas/
├── Calendario/
└── Moradores/
```

Cada funcionalidade poderá conter seus próprios:

- DTOs
- Commands
- Queries
- Validators
- Services
- Mappings

---

## Tecnologias

- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- JWT
- FluentValidation
- AutoMapper (quando aplicável)

---

## Princípios Adotados

- Arquitetura em camadas
- SOLID
- Clean Code
- Inversão de Dependência
- Injeção de Dependência
- Organização por funcionalidades
- Separação de responsabilidades

---

## Evolução

Novas camadas ou projetos poderão ser adicionados conforme a necessidade do sistema, mantendo a separação clara de responsabilidades e preservando a arquitetura definida.