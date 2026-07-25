# Arquitetura do Banco de Dados

## Objetivo

Este documento descreve a estratégia de modelagem e organização do banco de dados do CasaHub.

O detalhamento das entidades e relacionamentos será realizado conforme os módulos forem sendo implementados.

---

## Tecnologia

O banco de dados utilizado será:

- PostgreSQL

O acesso aos dados será realizado utilizando:

- Entity Framework Core

---

## Estratégia de Modelagem

A modelagem será baseada nas regras de negócio do sistema.

Cada módulo possuirá entidades próprias, mantendo alta coesão e baixo acoplamento.

Sempre que possível serão utilizados:

- Chaves primárias numéricas
- Chaves estrangeiras explícitas
- Restrições de integridade
- Índices para otimização de consultas

---

## Convenções

- Nomes das tabelas no singular.
- Chaves primárias nomeadas como Id.
- Chaves estrangeiras seguindo o padrão NomeEntidadeId.
- Datas armazenadas em UTC.
- Exclusão lógica quando aplicável.

---

## Migrações

Todas as alterações de estrutura deverão ser realizadas através de Migrations do Entity Framework Core.

Não serão realizadas alterações diretamente no banco de dados.

---

## Evolução

A modelagem completa será documentada conforme novas funcionalidades forem implementadas.