# 📦 ArmazingXStock

Sistema de gerenciamento de estoque e endereçamento de armazéns desenvolvido com **C#, .NET, Entity Framework Core e MySQL**.

## 🎯 Sobre o projeto

O ArmazingXStock é um projeto desenvolvido para praticar conceitos de desenvolvimento Back-end, modelagem de dados, regras de negócio e gerenciamento de estoque.

O sistema tem como objetivo controlar produtos, fornecedores, posições e movimentações de estoque dentro de uma estrutura hierárquica de armazém.

### 🏭 Estrutura de endereçamento

**Armazém → Corredor → Rua → Módulo → Nível → Endereço**

Exemplo de endereço:

`NOT01-C01-R01-M01-N01-E01`

## 🛠️ Tecnologias

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- Pomelo.EntityFrameworkCore.MySql
- MySQL
- Git / GitHub

## 🧠 Conceitos aplicados

- Programação Orientada a Objetos
- Entity Framework Core
- DbContext
- Migrations
- Primary Keys (PK)
- Foreign Keys (FK)
- Relacionamentos entre entidades
- Propriedades de navegação
- Índices simples e compostos
- Índices únicos
- Check Constraints
- DeleteBehavior.Restrict
- User Secrets
- Enums
- Collections

## 📦 Estrutura de estoque

O estoque é controlado através da entidade `PosicaoEstoque`, que relaciona um produto a um endereço e mantém sua quantidade disponível.

Cada combinação de:

`EnderecoId + ProdutoId`

deve ser única.

## 🔄 Movimentações

O projeto prevê três tipos de movimentação:

- Entrada
- Saída
- Transferência

As movimentações utilizam posições de origem e/ou destino de acordo com o tipo da operação.

## 🗄️ Banco de dados

A persistência de dados está configurada utilizando **Entity Framework Core com MySQL**.

A Migration inicial:

`InitialCreate`

já foi criada e aplicada ao banco de dados.

Ela é responsável pela criação inicial de:

- Tabelas
- Chaves primárias
- Chaves estrangeiras
- Índices
- Índices únicos
- Check Constraints
- Relacionamentos entre as entidades

## 🔐 Segurança e configuração

A string de conexão é mantida fora do código-fonte utilizando **.NET User Secrets**, evitando o versionamento de informações sensíveis no Git.

## 🚧 Status do projeto

### Concluído

- [x] Modelagem inicial das entidades
- [x] Relacionamentos entre entidades
- [x] Configuração do Entity Framework Core
- [x] Configuração do DbContext
- [x] Integração com MySQL
- [x] Regras de integridade no banco
- [x] Migration inicial
- [x] Criação da estrutura inicial do banco

### Próximos passos

- [ ] Implementação dos CRUDs
- [ ] Criação dos Controllers
- [ ] Criação dos endpoints da API
- [ ] Validação das regras de movimentação de estoque
- [ ] Testes dos endpoints
- [ ] Documentação da API
- [ ] Desenvolvimento do front-end

## 🎯 Objetivo

Projeto desenvolvido para estudo, prática e aprimoramento em desenvolvimento Back-end com **C# e .NET**, aplicando conceitos utilizados em aplicações reais.