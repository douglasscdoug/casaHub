# Fluxo de Desenvolvimento do CasaHub

Este documento descreve o processo utilizado para desenvolver, organizar e publicar alterações no projeto.

## Visão geral do fluxo

O desenvolvimento segue o fluxo:

Issue → Branch → Desenvolvimento → Commit → Pull Request → Merge → Release

---

# 1. Criar uma Issue

Toda alteração deve começar com uma Issue.

A Issue deve representar uma entrega pequena e objetiva.

Exemplos:

✅ Criar tela de login

✅ Criar endpoint de cadastro de usuário

✅ Adicionar validação de senha

Evitar:

❌ Criar todo o módulo financeiro

---

## Informações da Issue

Adicionar:

- Título claro
- Descrição do objetivo
- Critérios de aceite
- Labels
- Adicionar ao Project

---

# 2. Criar uma branch

As branches sempre devem partir da `develop`.

Atualizar a develop:

```bash
git switch develop

git pull
```

Criar uma nova branch:
```bash
git switch -c feature/nome-da-tarefa
```
Padrão: `tipo/descricao-em-portugues`

Exemplos:

```bash
feature/cadastro-de-usuario

bug/corrigir-login

refactor/organizar-servicos

chore/configurar-ambiente

docs/documentar-fluxo
```
---

# 3. Desenvolvimento

Durante o desenvolvimento:

- Manter a Issue atualizada.
- Fazer commits pequenos.
- Não misturar alterações diferentes.

## Exemplo:

`Adicionar entidade Usuario`

não deve conter:

`Adicionar Usuario + corrigir Dashboard + alterar layout`

---

# 4. Commits

Utilizar Conventional Commits.

## Formato:

`tipo: descrição`

## Exemplos:

```bash
feat: adicionar cadastro de usuário

fix: corrigir validação de senha

docs: atualizar documentação

refactor: reorganizar serviços

chore: configurar ambiente
```

## Tipos principais:

| Tipo     | Uso                 |
| -------- | ------------------- |
| feat     | Nova funcionalidade |
| fix      | Correção            |
| docs     | Documentação        |
| refactor | Refatoração         |
| test     | Testes              |
| chore    | Configuração        |

---

# 5. Enviar branch para o GitHub

Após finalizar:

```bash
git push -u origin nome-da-branch
```

---

# 6. Criar Pull Request

O Pull Request sempre deve seguir:

```bash
branch criada
        ↓
develop
```

## Exemplo:

```bash
feature/cadastro-de-usuario

↓

develop
```

Nunca:

```bash
feature

↓

main
```

## Preencher Pull Request

Informar:

- Objetivo
- Issue relacionada
- Alterações realizadas
- Tipo de alteração
- Checklist

Fechar Issue automaticamente:

`Closes #numero`

## Exemplo:

`Closes #15`

---

# 7. Revisão e Merge

Antes do merge:

Verificar:

Código funcionando
Sem arquivos desnecessários
Documentação atualizada
Sem conflitos

Estratégia de merge:

Preferencialmente:

```bash
Squash and merge
```

para manter histórico limpo.

---

# 8. Após o Merge

Atualizar ambiente local:

```bash
git switch develop

git pull
```

Excluir branch:

```bash
git branch -d nome-da-branch
```

Excluir branch remota:

```bash
git push origin --delete nome-da-branch
```

---

# 9. Releases

A branch main representa versões estáveis.

## Fluxo:

```bash
develop

↓

main

↓

Release
```

Só enviar para main quando houver uma versão funcional.

## Exemplo:

``v0.1.0``

---

# 10. Organização do Project

Colunas:

```bash
Backlog
Ready
In Progress
Review
Done
```

## Fluxo:

Nova Issue:

``Backlog``

Iniciou desenvolvimento:

``In Progress``

Criou PR:

``Review``

Merge realizado:

``Done``

---

# Regras importantes

- Toda alteração começa por uma Issue.
- Toda alteração deve possuir uma branch.
- Não desenvolver diretamente na main ou develop.
- Commits devem ser pequenos e claros.
- PRs devem ser revisados antes do merge.
- Manter documentação atualizada.

---