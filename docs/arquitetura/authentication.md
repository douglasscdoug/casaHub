# Autenticação JWT

## Visão Geral

O CasaHub utiliza autenticação baseada em **JSON Web Token (JWT)** para identificar usuários e proteger endpoints da API.

Após um login bem-sucedido, a API gera um token JWT contendo as informações necessárias para identificar o usuário durante a sessão. Esse token deve ser enviado pelo cliente em todas as requisições para endpoints protegidos.

A autenticação foi implementada utilizando os recursos nativos do ASP.NET Core e segue uma arquitetura desacoplada, onde a geração e validação do token são responsabilidades da camada de infraestrutura.

---

# Fluxo de Autenticação

## 1. Cadastro do usuário

O usuário realiza o cadastro através do endpoint:

```http
POST /api/users
```

Durante o processo:

* Os dados são validados utilizando FluentValidation.
* O e-mail é normalizado.
* A senha é criptografada utilizando `PasswordHasher`.
* O usuário é persistido no banco de dados PostgreSQL.

---

## 2. Login

O login é realizado através do endpoint:

```http
POST /api/auth/login
```

Exemplo de requisição:

```json
{
  "email": "usuario@email.com",
  "password": "Senha@123"
}
```

Durante a autenticação:

1. Os dados da requisição são validados.
2. O usuário é localizado pelo e-mail.
3. A senha informada é comparada com o hash armazenado.
4. Caso as credenciais sejam válidas, um JWT é gerado.
5. A API retorna o token juntamente com os dados básicos do usuário.

Exemplo de resposta:

```json
{
  "token": "<jwt>",
  "expiration": "2026-08-02T22:00:00Z",
  "user": {
    "id": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "name": "Douglas",
    "email": "usuario@email.com"
  }
}
```

Caso o usuário ou senha sejam inválidos:

```http
401 Unauthorized
```

```json
{
  "status": 401,
  "title": "Unauthorized",
  "message": "Usuário ou senha inválidos."
}
```

---

# Estrutura do JWT

O token é composto pelas seguintes informações:

* Issuer
* Audience
* Data de expiração
* Claims do usuário
* Assinatura digital

As principais claims utilizadas atualmente são:

| Claim | Descrição                |
| ----- | ------------------------ |
| sub   | Identificador do usuário |
| name  | Nome do usuário          |
| email | E-mail do usuário        |

Outras claims poderão ser adicionadas futuramente conforme novas funcionalidades forem implementadas.

---

# Configuração

As configurações do JWT são realizadas através da seção `Jwt` do arquivo de configuração da aplicação.

Exemplo:

```json
"Jwt": {
  "Issuer": "CasaHub",
  "Audience": "CasaHub",
  "SecretKey": "********",
  "ExpirationMinutes": 60
}
```

## Propriedades

| Propriedade       | Descrição                              |
| ----------------- | -------------------------------------- |
| Issuer            | Emissor do token                       |
| Audience          | Aplicação que aceitará o token         |
| SecretKey         | Chave utilizada para assinatura do JWT |
| ExpirationMinutes | Tempo de expiração do token            |

---

# Geração do Token

A geração do JWT é responsabilidade da implementação de `ITokenService`.

Durante a criação do token são definidos:

* Claims do usuário
* Data de expiração
* Credenciais de assinatura
* Issuer
* Audience

Após sua criação, o token é serializado e retornado para a API.

---

# Validação do Token

A autenticação é configurada utilizando o middleware JWT Bearer do ASP.NET Core.

A validação verifica:

* assinatura do token;
* emissor;
* audiência;
* expiração;
* integridade da chave de assinatura.

Caso qualquer validação falhe, a requisição é rejeitada com resposta **401 Unauthorized**.

---

# Utilização em Endpoints Protegidos

Endpoints que exigem autenticação devem utilizar o atributo:

```csharp
[Authorize]
```

Exemplo:

```csharp
[Authorize]
[HttpGet("private")]
public IActionResult Private()
{
    return Ok("Acesso autorizado.");
}
```

---

# Enviando o Token

Após realizar o login, o cliente deve enviar o JWT em todas as requisições autenticadas utilizando o header:

```http
Authorization: Bearer <token>
```

Exemplo:

```http
GET /api/health/private

Authorization: Bearer eyJhbGciOiJIUzI1NiIs...
```

---

# Respostas da API

## Login realizado com sucesso

**Status:** `200 OK`

Retorna o token JWT e as informações básicas do usuário autenticado.

---

## Dados inválidos

**Status:** `400 Bad Request`

Retornado quando a requisição possui falhas de validação.

---

## Credenciais inválidas

**Status:** `401 Unauthorized`

Retornado quando usuário ou senha são inválidos.

---

## Token inválido ou expirado

**Status:** `401 Unauthorized`

Retornado quando o token informado é inválido, expirou ou não foi enviado em um endpoint protegido.

---

# Arquitetura

A autenticação está distribuída entre as camadas da aplicação:

```text
API
 ├── AuthController
 └── Configuração dos Middlewares

Application
 ├── AuthService
 ├── DTOs
 ├── Validators
 └── Interfaces

Infrastructure
 ├── JwtTokenService
 ├── PasswordHasher
 ├── JwtOptions
 └── Configuração JWT

Persistence
 └── UserRepository
```

Essa organização mantém a camada de aplicação independente da implementação do JWT, permitindo evoluções futuras sem impactar as regras de negócio.

---

# Próximas Evoluções

A implementação atual estabelece a base para futuras funcionalidades relacionadas à autenticação e autorização, como:

* Refresh Token;
* Logout;
* Recuperação de senha;
* Alteração de senha;
* Confirmação de e-mail;
* Autorização baseada em permissões e perfis (RBAC);
* Revogação de tokens;
* Auditoria de autenticação.