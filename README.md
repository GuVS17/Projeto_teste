# Teste Técnico


## 📌 Sobre
Este projeto é uma aplicação web desenvolvida com **.NET 8** (Web API) e **Angular** (FrontEnd).
Inclui funcionalidades como **Listar, Criar, Editar e Excluir**.

---

## 🚀 Tecnologias Utilizadas
 - **Backend:** .NET 8 + Entity Framework Core 
 - **Frontend:** Angular 19
 - **Banco de Dados:** PostgreSQL

---

## ⚙️ Pré-requisitos
 Antes de Rodar o projeto, certifique-se de ter instalado:
 - [Node.js](https://nodejs.org/)
 - [Angular CLI](https://angular.io/cli)
 - [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
 - [PostgreSQL](https://www.postgresql.org/download/)

---

## 📥  Como instalar e Rodar o Projeto

### 🔹 Backend (.NET 8)

1. **Clone o repositório**

     `git clone https://github.com/GuVS17/Projeto_teste.git`  

2. **Acesse a pasta da API**

     `cd TesteWebAPI`

3. **Instale as dependências**

     `dotnet restore`

4. **Configure a string de conexão no ´appsettings.json´**

     `"ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=SeuBanco;Username=SeuUsuario;Password=SuaSenha"
     }`

5. **Execute as migrations**

     `dotnet ef database update`

6. **Rode a API**

     `dotnet run`

A API estará rodando em: http://localhost:5110

**Ou então você pode restaurar um banco de dados que está criado**

5. **Instale o PostgreSQL.**
6. **No terminal do PostgreSQL**, crie o banco

     `CREATE DATABASE nomedobanco`

depois restaure o banco com:

     `psql -U SeuUsuario -d SeuBanco -f backup.sql`

**O arquivo backup.sql está na raiz do diretório**

### 🔹 Frontend (Angular)

1. **Acesse a pasta do frontend**

     `cd TesteAPP`

2. **Instale as dependências**

     `npm install`

3. **Configure o ambiente**

Se a API estiver rodando em uma URL diferente, atualize a variável apiUrl no arquivo `environments.ts`.

4. **Inicie o Angular**
  
    `ng serve`

O frontend estará disponível em: http://localhost:4200

---

## 🛠️ Testando a API 

Você pode testar as requisições da API usando:



### 🔹 Postman
Baixe e instale o [Postman](https://www.postman.com/)

* Crie uma nova requisição e escolha o tipo de método:
    + GET: Para listar os produtos
    + POST: Para criar um novo produto
    + PUT: Para atualizar um produto
    + DELETE: Para excluir um produto

Exemplo de requisição POST (Criar um Produto)

URL: http://localhost:5110/api/alunos

Vá para a aba "Body", escolha "raw", e selecione "JSON"

Cole este JSON:
     
     { 
        "nome": "Cabo de Rede",
        "quantidade": 20
     }
 ---

## 🎯 Possíveis problemas e soluções

* Erro ao conectar ao PostgreSQL
    + Verifique se o banco está rodando e se a string de conexão está correta

* Erro ao rodar dotnet ef database update
    + Certifique-se de que o Entity Framework Core está instalado com:
      
        `dotnet tool install --global dotnet-ef`

---
### 📌 Autor

Desenvolvido por **Gustavo Vieira**
