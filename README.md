# BiblioTechA - Sistema de Biblioteca

Este é um sistema de gerenciamento de biblioteca desenvolvido com ASP.NET Core e Entity Framework. Ele permite que os usuários gerenciem livros e bibliotecas de forma simples e eficiente.

## Pré-requisitos

Antes de começar, certifique-se de ter as seguintes ferramentas instaladas:

- [.NET SDK](https://dotnet.microsoft.com/download) (versão 6.0 ou superior)
- [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) ou outro banco de dados compatível com o Entity Framework

## Passos para Execução

Siga os passos abaixo para clonar e executar o projeto em sua máquina local:

### 1. Clonar o Repositório

Clone o repositório para sua máquina local:

```bash
git clone https://github.com/RodegheriLucas/BiblioTechA.git
```

### 2. Acessar o Diretório do Projeto

Entre no diretório do projeto clonado:

```
cd BiblioTechA
```

### 3. Restaurar Dependências

Restaure as dependências do projeto com o comando:

```
dotnet restore
```
### 4. Atualizar o Banco de Dados

Aplique as migrações e atualize o banco de dados com o comando:

```
dotnet ef database update
```
