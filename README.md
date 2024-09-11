# RecomendaLivro

RecomendaLivro é um sistema de recomendação de livros desenvolvido com .NET, que permite a consulta e recomendação de livros utilizando uma API RESTful. O projeto inclui um banco de dados SQL Server para armazenar informações relacionadas aos livros e recomendações.

## Índice
- [Requisitos](#requisitos)
- [Configuração Local](#configuração-local)
  - [Configuração do Banco de Dados](#configuração-do-banco-de-dados)
  - [Execução de Migrations](#execução-de-migrations)
- [Endpoints](#endpoints)

## Requisitos

Para executar este projeto localmente, você precisará dos seguintes requisitos:
- .NET 6 ou superior
- SQL Server
- Entity Framework Core

## Configuração Local

### Configuração do Banco de Dados

Para configurar o banco de dados SQL Server local, siga os passos abaixo:

1. Certifique-se de ter o SQL Server instalado e em execução em sua máquina.
2. No projeto, a camada de dados se encontra em [`RecomendaLivro.Shared.Data`](https://github.com/claudia-duda/RecomendaLivro/tree/master/RecomendaLivro.Shared.Data).
3. Configure a string de conexão com o banco de dados no arquivo `appsettings.Development.json` da camada principal do projeto:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=RecomendaLivroDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

### Execução de Migrations
Para criar o banco de dados e aplicar as migrations localmente, execute os seguintes comandos no terminal ou console do Gerenciador de Pacotes do Visual Studio:

1. Abra o terminal na raiz do projeto ou navegue até o diretório principal do projeto RecomendaLivro.
2. Execute o comando para adicionar uma migration (se ainda não estiver adicionada):
```
dotnet ef migrations add InitialCreate --project RecomendaLivro.Shared.Data --startup-project RecomendaLivro
```
3. Aplique as migrations para criar o banco de dados:
```
dotnet ef database update --project RecomendaLivro.Shared.Data --startup-project RecomendaLivro
```
Isso criará o banco de dados **RecomendaLivroDb** localmente no seu SQL Server.


### Endpoints
Os principais endpoints da API podem ser encontrados na camada RecomendaLivro.Application/Controllers.

Lista de Endpoints: Livros

**GET** /api/books <br>
**Descrição:** Retorna a lista de todos os livros cadastrados do usuário.

**GET** /api/books/{id} <br>
**Descrição:** Retorna os detalhes de um livro específico com base no id fornecido. <br>
**Parâmetros:**
  id: O ID do livro que deseja buscar.

**DELETE** /api/books/{id} <br>
**Descrição:** Deleta o livro cadastrado <br>
**Parâmetros:**
  id: O ID do livro que deseja deletar.

**PUT** /api/books/{id} <br>
**Descrição:** Deleta o livro cadastrado <br>
**Parâmetros:**
  id: O ID do livro que deseja deletar.

Obs: Endpoint de autenticação também estaram disponíveis, você pode consulta pela página do swagger, como demonstrado abaixo:
![image](https://github.com/user-attachments/assets/74257e81-8235-45be-8c1c-7c9f56206940)


