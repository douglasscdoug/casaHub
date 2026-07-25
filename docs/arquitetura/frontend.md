# Arquitetura do Frontend

## Objetivo

O frontend do CasaHub é desenvolvido utilizando Angular e organizado por funcionalidades (Feature-Based), facilitando a escalabilidade da aplicação e a reutilização de componentes.

A arquitetura busca manter o código modular, desacoplado e preparado para futuras expansões, incluindo a versão mobile.

---

## Estrutura da Aplicação

```text
frontend/
│
├── src/
│   ├── app/
│   ├── assets/
│   ├── environments/
│   └── styles/
│
└── public/
```

---

## Organização da Pasta App

```text
app/
│
├── core/
├── shared/
├── layout/
├── features/
└── app.routes.ts
```

---

## Responsabilidade das Pastas

### core

Contém recursos globais da aplicação.

Exemplos:

- Guards
- Interceptors
- Serviços globais
- Configurações
- Autenticação

---

### shared

Contém recursos reutilizáveis entre diferentes funcionalidades.

Exemplos:

- Componentes compartilhados
- Diretivas
- Pipes
- Models comuns
- Utilitários

---

### layout

Responsável pela estrutura visual da aplicação.

Exemplos:

- Navbar
- Sidebar
- Footer
- Layout principal
- Componentes estruturais

---

### features

Contém os módulos de negócio da aplicação.

Exemplo:

```text
features/
│
├── dashboard/
├── autenticacao/
├── moradores/
├── financeiro/
├── compras/
├── tarefas/
└── calendario/
```

Cada funcionalidade poderá conter:

```text
financeiro/
│
├── pages/
├── components/
├── services/
├── models/
├── guards/
└── financeiro.routes.ts
```

---

## Estilização

A interface será construída utilizando:

- Tailwind CSS

O objetivo é criar componentes reutilizáveis, mantendo consistência visual e reduzindo a necessidade de CSS personalizado.

---

## Gerenciamento de Estado

Inicialmente será utilizado o gerenciamento de estado nativo do Angular através de:

- Services
- Signals
- RxJS

Caso a complexidade da aplicação aumente significativamente, poderá ser avaliada a adoção de uma solução dedicada.

---

## Roteamento

O roteamento será organizado por funcionalidades, permitindo carregamento modular e melhor organização do código.

---

## Princípios Adotados

- Componentização
- Organização por funcionalidades
- Reutilização de componentes
- Separação de responsabilidades
- Lazy Loading quando aplicável
- Código limpo

---

## Evolução

A estrutura foi planejada para facilitar o compartilhamento de conceitos e regras de negócio com uma futura aplicação mobile desenvolvida em Ionic + Angular, mantendo consistência entre as plataformas.