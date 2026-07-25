# Visão Geral da Arquitetura

## Objetivo

O CasaHub foi projetado seguindo princípios de arquitetura em camadas e boas práticas de engenharia de software, com foco em manutenibilidade, escalabilidade e evolução contínua.

A arquitetura busca manter baixo acoplamento e alta coesão entre os componentes, permitindo que novas funcionalidades sejam incorporadas sem comprometer as existentes.

---

## Arquitetura

O CasaHub é organizado em um monorepositório, contendo aplicações independentes para backend e frontend.

O backend segue uma arquitetura em camadas composta por:

- API
- Application
- Domain
- Infrastructure

O frontend será desenvolvido utilizando Angular, organizado por funcionalidades (Feature-Based), favorecendo modularidade, reutilização de componentes e facilidade de manutenção.

---

## Estrutura da Solução

```text
CasaHub/
├── backend/
├── frontend/
├── docs/
├── .github/
├── README.md
├── CHANGELOG.md
├── CONTRIBUTING.md
```

---

## Responsabilidade das Camadas

O backend segue uma arquitetura em camadas, onde cada projeto possui responsabilidades específicas.

### API

Responsável por expor os endpoints HTTP, autenticação, autorização e configuração da aplicação.

### Application

Contém os casos de uso, DTOs, validações e regras de aplicação.

### Domain

Contém as entidades, regras de negócio e contratos do domínio.

### Infrastructure

Implementa acesso a banco de dados, autenticação, repositórios e integrações externas.

---

## Tecnologias

### Backend

- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- JWT
- FluentValidation
- AutoMapper

### Frontend

- Angular
- TypeScript
- Tailwind CSS

### Mobile (planejado)

- Planejado para uma fase futura utilizando Ionic + Angular, aproveitando parte da estrutura e da lógica do frontend web.

---

## Princípios Arquiteturais

- Separação de responsabilidades
- Baixo acoplamento
- Alta coesão
- Organização por funcionalidades
- Código limpo
- Escalabilidade
- Facilidade de testes

---

## Evolução da Arquitetura

Este documento representa a visão atual da arquitetura.

Decisões arquiteturais específicas serão registradas na pasta:

docs/decisoes