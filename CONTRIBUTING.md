# Contribuindo com o CasaHub

Obrigado pelo interesse em contribuir com o projeto.

Este documento descreve os padrões e o fluxo de desenvolvimento utilizados no CasaHub para manter a organização, qualidade e rastreabilidade das alterações.

## Fluxo de Desenvolvimento

O projeto utiliza um fluxo baseado em branches:

`main
↑
develop
↑
feature/*`


### Branches principais

#### main

Contém apenas versões estáveis do projeto.

Alterações devem ser realizadas através de Pull Requests.

#### develop

Branch de integração das novas funcionalidades antes de uma versão oficial.

#### feature/*

Branches utilizadas para desenvolvimento de novas funcionalidades ou alterações.

Exemplo:
`feature/cadastro-de-usuario
feature/lista-de-compras
feature/controle-de-despesas`

## Processo para novas alterações

1. Criar uma Issue descrevendo a alteração necessária.
2. Criar uma branch a partir da `develop`.
3. Realizar o desenvolvimento.
4. Criar commits seguindo o padrão definido.
5. Abrir um Pull Request para a `develop`.
6. Realizar a revisão da alteração.
7. Após aprovação, realizar o merge.

## Padrão de Commits

O projeto utiliza Conventional Commits.

Formato:
tipo: descrição
Exemplos:
feat: adicionar cadastro de usuários

fix: corrigir validação do formulário

docs: atualizar documentação da API

refactor: reorganizar serviço de autenticação

test: adicionar testes de usuário

chore: atualizar configurações do projeto


## Tipos de Commit

| Tipo | Uso |
|---|---|
| feat | Nova funcionalidade |
| fix | Correção de problemas |
| docs | Alterações em documentação |
| refactor | Refatoração de código |
| test | Inclusão ou alteração de testes |
| chore | Configurações e tarefas internas |

## Pull Requests

Todo Pull Request deve:

- Estar relacionado a uma Issue.
- Possuir uma descrição clara das alterações.
- Informar possíveis impactos.
- Passar pelos testes disponíveis.
- Manter o padrão de código existente.

Exemplo de fechamento automático de Issue:
`Closes #10`


## Organização das Issues

As Issues devem ser pequenas e focadas em uma entrega específica.

Exemplos:

✅ Criar endpoint para cadastro de usuário

✅ Criar tela de login

✅ Adicionar validação de senha

Evitar:

❌ Implementar todo o módulo financeiro

## Ambiente de Desenvolvimento

As instruções para configuração do ambiente serão adicionadas conforme novas tecnologias forem incorporadas ao projeto.

## Código de Conduta

Todos os colaboradores devem manter uma comunicação respeitosa e colaborativa, buscando contribuir para a evolução do projeto.