# ADR-003 — Banco de Dados PostgreSQL

## Status

Aceito

---

## Contexto

O CasaHub necessita de um banco de dados relacional robusto, gratuito e amplamente suportado para armazenar suas informações.

Além disso, o projeto possui como objetivo futura hospedagem em ambientes de nuvem e possível comercialização.

---

## Decisão

O banco de dados adotado será o PostgreSQL.

O acesso aos dados será realizado utilizando:

- Entity Framework Core
- Npgsql Entity Framework Provider

Toda alteração estrutural será realizada através de Migrations.

Não serão realizadas alterações diretamente no banco de dados.

---

## Motivos da escolha

- Software livre.
- Excelente desempenho.
- Amplo suporte em provedores de nuvem.
- Excelente integração com Entity Framework Core.
- Grande comunidade.
- Recursos avançados para consultas e indexação.

---

## Consequências

### Positivas

- Sem custo de licenciamento.
- Facilidade de hospedagem.
- Escalabilidade.
- Portabilidade.
- Compatibilidade com diversos provedores.

### Negativas

- Algumas diferenças de sintaxe em relação ao SQL Server.
- Necessidade de utilizar o provider Npgsql.

---

## Data

2026-07-24