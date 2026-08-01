# ADR-002 - Utilizar autenticação própria em vez do ASP.NET Core Identity

## Status

Aceito

## Contexto

O CasaHub necessita de um mecanismo de autenticação para controle de acesso dos usuários.

Durante a definição da arquitetura foram avaliadas duas abordagens:

- ASP.NET Core Identity;
- Implementação própria utilizando JWT.

O projeto tem como objetivo servir como portfólio profissional e evoluir para um produto comercial, priorizando uma arquitetura limpa, baixo acoplamento e controle sobre as regras de negócio.

---

## Decisão

Foi decidido implementar uma solução própria de autenticação utilizando:

- JWT (JSON Web Token);
- Hash de senhas com BCrypt;
- Refresh Token;
- Autorização baseada em Roles e Policies;
- Serviços próprios para geração e validação de tokens.

O ASP.NET Core Identity não será utilizado nesta versão do projeto.

---

## Justificativa

A implementação própria oferece as seguintes vantagens para o contexto do projeto:

- Modelo de dados mais simples;
- Total controle sobre entidades e regras de autenticação;
- Menor acoplamento com frameworks específicos;
- Maior compreensão dos mecanismos de autenticação;
- Arquitetura mais aderente aos princípios adotados pelo projeto.

Embora o ASP.NET Core Identity forneça diversos recursos prontos, muitos deles não são necessários na fase atual do CasaHub.

---

## Consequências

### Positivas

- Banco de dados mais simples.
- Código mais enxuto.
- Controle total da implementação.
- Facilidade para adaptar as regras de autenticação às necessidades do sistema.

### Negativas

- Recursos como recuperação de senha, confirmação de e-mail e autenticação em dois fatores deverão ser implementados futuramente, caso sejam necessários.
- A responsabilidade pela segurança da implementação passa a ser do projeto.

---

## Revisão futura

Esta decisão poderá ser reavaliada caso o projeto passe a exigir funcionalidades avançadas de gerenciamento de identidade ou autenticação externa.