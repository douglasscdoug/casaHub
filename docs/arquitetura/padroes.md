# Padrões de Desenvolvimento

## Objetivo

Este documento reúne os padrões e convenções adotados no desenvolvimento do CasaHub.

Seu objetivo é manter a consistência do código, facilitar a manutenção da aplicação e orientar futuras implementações.

---

# Organização do Repositório

O projeto é organizado em um monorepositório contendo backend, frontend e documentação.

```text
CasaHub/
├── backend/
├── frontend/
├── docs/
├── .github/
└── README.md
```

---

# Fluxo de Desenvolvimento

Toda alteração deve seguir o fluxo abaixo:

```text
Issue
    ↓
Branch
    ↓
Desenvolvimento
    ↓
Commits
    ↓
Push
    ↓
Pull Request
    ↓
Merge → develop
    ↓
Release → main
```

Não é permitido desenvolver diretamente nas branches:

- main
- develop

---

# Convenção de Branches

As branches seguem uma nomenclatura semântica utilizando descrições em português.

Exemplos:

```text
feature/cadastro-de-morador

feature/dashboard

bug/corrigir-login

refactor/reorganizar-servicos

docs/arquitetura-backend

chore/configurar-github
```

---

# Convenção de Commits

O projeto utiliza o padrão Conventional Commits.

Exemplos:

```text
feat: adicionar autenticação JWT

fix: corrigir cálculo do saldo

docs: atualizar documentação da arquitetura

refactor: reorganizar camada de aplicação

test: adicionar testes da autenticação

chore: configurar ambiente inicial
```

Cada commit deve representar uma alteração pequena e objetiva.

---

# Organização das Issues

Cada Issue deve representar uma única entrega.

Exemplos:

- Criar autenticação
- Criar dashboard
- Implementar entidade Morador

Evitar:

- Criar módulo financeiro completo

Toda Issue deve possuir:

- Objetivo
- Descrição
- Critérios de aceite
- Labels
- Vinculação ao GitHub Project

---

# Organização do Backend

O backend segue arquitetura em camadas.

```text
API
Application
Domain
Infrastructure
```

A camada Application será organizada por funcionalidades.

Exemplo:

```text
Financeiro/
Compras/
Dashboard/
Moradores/
```

---

# Organização do Frontend

O frontend segue organização por funcionalidades (Feature-Based).

```text
core/
shared/
layout/
features/
```

Cada funcionalidade poderá conter:

```text
pages/
components/
services/
models/
guards/
```

---

# Convenções de Código

## Idioma

- Código em inglês.
- Documentação em português.
- Commits em português.
- Branches em português.

---

## Classes

Utilizar nomes descritivos.

Exemplo:

```text
FinancialService

CreateResidentCommand

DashboardController
```

---

## Interfaces

Prefixo "I".

Exemplo:

```text
IUserRepository

IAuthService
```

---

## Métodos

Utilizar verbos que representem claramente sua ação.

Exemplos:

```text
CreateAsync()

UpdateAsync()

DeleteAsync()

GetByIdAsync()

ListAsync()
```

---

## Variáveis

Utilizar nomes claros e evitar abreviações.

Preferir:

```text
financialSummary
```

Em vez de:

```text
fs
```

---

# Boas Práticas

Sempre priorizar:

- Baixo acoplamento
- Alta coesão
- SOLID
- Clean Code
- DRY (Don't Repeat Yourself)
- KISS (Keep It Simple, Stupid)

---

# Tratamento de Exceções

- Utilizar middleware global para tratamento de exceções.
- Não expor detalhes internos da aplicação.
- Registrar erros utilizando logging.

---

# Validações

As validações de entrada deverão ser realizadas utilizando FluentValidation.

As regras de negócio deverão permanecer na camada de domínio ou aplicação, conforme sua responsabilidade.

---

# Testes

Sempre que possível criar:

- Testes unitários
- Testes de integração

Novas funcionalidades críticas devem possuir cobertura de testes.

---

# Documentação

Toda alteração relevante na arquitetura deverá ser refletida na documentação.

Quando necessário atualizar:

- README
- Arquitetura
- ADRs
- CHANGELOG

---

# Evolução

Este documento poderá ser atualizado conforme novos padrões forem adotados no projeto.

Toda alteração significativa deverá ser registrada e documentada para manter a consistência do desenvolvimento.