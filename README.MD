# 📦 ArmazingXStock.Api

API REST para gerenciamento de estoque, desenvolvida com **C#, ASP.NET Core Web API, Entity Framework Core e MySQL**.

O ArmazingXStock é um projeto de portfólio voltado ao desenvolvimento Backend, com foco em modelagem de dados, relacionamentos entre entidades, persistência de informações e implementação de regras de negócio.

## 🎯 Sobre o projeto

O sistema tem como objetivo apoiar o gerenciamento de produtos e informações relacionadas ao estoque, aplicando conceitos de desenvolvimento de APIs e integração com banco de dados relacional.

O projeto está sendo desenvolvido incrementalmente, priorizando a construção e a evolução do Backend antes da implementação do Frontend.

## 🛠️ Tecnologias utilizadas

- **C#**
- **.NET 10**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **Pomelo.EntityFrameworkCore.MySql**
- **MySQL**
- **Swagger / OpenAPI**
- **Git e GitHub**

## ⚙️ Funcionalidades e implementações

- Modelagem de entidades para categorias, tipos de produtos e produtos.
- Relacionamentos entre entidades por meio de chaves primárias e estrangeiras.
- Persistência e consulta de dados utilizando Entity Framework Core e MySQL.
- Desenvolvimento de endpoints para as entidades implementadas.
- Geração automática de prefixos SKU com base no nome do tipo de produto.
- Implementação da lógica de geração sequencial de SKU, com prefixo e numeração de quatro dígitos por tipo de produto.
- Aplicação de regras de negócio e restrições de integridade dos dados.
- Configuração do Swagger para documentação e exploração dos endpoints da API.

## 🗄️ Banco de dados

A aplicação utiliza o MySQL para persistência dos dados e o Entity Framework Core para o mapeamento objeto-relacional (ORM).

A estrutura de dados utiliza relacionamentos entre entidades, chaves estrangeiras e restrições de unicidade para reforçar a integridade das informações.

A configuração da conexão com o banco utiliza **.NET User Secrets** no ambiente de desenvolvimento, evitando manter credenciais diretamente no código-fonte.

## 🚀 Como executar o projeto

### Pré-requisitos

- .NET SDK compatível com a versão utilizada no projeto.
- MySQL Server.
- Visual Studio ou outra IDE compatível com .NET.

### Passos

1. Clone o repositório:

   ```bash
   git clone https://github.com/Brayanpj/ArmazingXStock.Api.git
   ```

2. Acesse a pasta do projeto:

   ```bash
   cd ArmazingXStock.Api
   ```

3. Configure a conexão com o MySQL utilizando o mecanismo de configuração adotado no projeto.

4. Execute a aplicação:

   ```bash
   dotnet run
   ```

5. Acesse a interface do Swagger pela URL exibida no terminal, caso esteja habilitada no ambiente de execução.

> **Observação:** a configuração do banco de dados e os comandos de inicialização devem corresponder à versão atual do projeto.

📌 Status do projeto

Em desenvolvimento — MVP Backend.

O foco atual está na evolução da API, nas regras de negócio relacionadas aos produtos e na validação das operações implementadas.

Próximas etapas

Consolidar e validar as operações CRUD.

Aprimorar as validações e o tratamento de erros.

Evoluir o gerenciamento de estoque e fornecedores.

Implementar movimentações e endereçamento de armazém.

Desenvolver o Frontend para consumir a API.

Ampliar os testes e a documentação técnica.

### Próximas etapas

- Consolidar e validar as operações CRUD.
- Aprimorar as validações e o tratamento de erros.
- Evoluir o gerenciamento de estoque e fornecedores.
- Implementar movimentações e endereçamento de armazém.
- Desenvolver o Frontend para consumir a API.
- Ampliar os testes e a documentação técnica.

## 🎯 Objetivo profissional

Projeto desenvolvido para consolidar e demonstrar conhecimentos em **desenvolvimento Backend com C# e .NET**, incluindo APIs REST, persistência de dados, modelagem relacional e implementação de regras de negócio.

---

Desenvolvido por **Brayan Prates Jardim**.

[GitHub](https://github.com/Brayanpj)