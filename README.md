## Visão Geral

Este projeto é uma aplicação web criada com o objetivo de realizar o CRUD completo da tabela **Tanque**, utilizando tecnologias modernas no front-end e back-end, com uma arquitetura baseada em boas práticas de desenvolvimento.

### Principais Funcionalidades

- **Cadastro de Tanques**: 
  - Tela com formulário para inclusão de novos tanques, contendo os campos:
    - **Depósito**: Descrição e chave do tanque.
    - **Capacidade**: Capacidade do tanque.
    - **Tipo de Produto**: Tipo de produto armazenado no tanque.
  - Validação dos dados inseridos no formulário.

- **Consulta de Tanques**: 
  - Listagem de todos os tanques cadastrados com as informações principais.
  - Possibilidade de filtrar e buscar tanques específicos.

- **Edição de Tanques**: 
  - Permite a edição dos detalhes de um tanque previamente cadastrado.

- **Exclusão de Tanques**: 
  - Opção para excluir tanques da base de dados.

## Demonstração

Para uma visualização rápida do projeto, você pode assistir aos vídeos abaixo. Eles mostram uma demonstração das principais funcionalidades da aplicação.

![Demonstração do Projeto - Cadastro de Tanques](angular/src/assets/img/computer.gif)
![Demonstração do Projeto - Consulta e Edição de Tanques](angular/src/assets/img/mobile.gif)

## 💻 Tecnologias

Esse projeto foi desenvolvido com as seguintes tecnologias:

- **Frontend:** Angular 12
- **Backend:** .NET 4.6.1 / Entity Framework Core / RESTful API
- **Padrões:** DDD (Domain-Driven Design) e Injeção de Dependência
- **Node:** 14.20.0

## Como Executar o Projeto

1. Clone este repositório para sua máquina local:
    ```bash
    git clone https://github.com/EnilsonNeto/enilson-unisolution.git
    ```

2. Navegue até o diretório do projeto:
    ```bash
    cd enilson-unisolution
    ```

3. Para o **Frontend**:
   - Navegue até a pasta do frontend:
     ```bash
     cd angular
     ```
   - Instale as dependências utilizando o Node.js:
     ```bash
     npm install
     ```
   - Execute a aplicação:
     ```bash
     npm start
     ```

4. Para o **Backend**:
   - Navegue até a pasta do backend:
     ```bash
     cd aspnet-core
     ```
   - Abra o projeto em uma IDE compatível, como Visual Studio.
   - Inicialize as migrations como projeto de inicialização.    
   - Configure o banco de dados no arquivo de configuração do projeto (appsettings.json ou Web.config) com os detalhes da sua instância.
   - Compile e execute o projeto.

5. Acesse a aplicação em seu navegador:
    - **Frontend**: `http://localhost:4200`
    - **API**: `http://localhost:21021/swagger/index.html`

## Endpoints da API

### Tanques

- **POST** `/api/services/app/Tank/CreateTankAsync`: Cria um novo tanque.
- **GET** `/api/services/app/Tank/GetByIdAsync`: Retorna um tanque pelo seu ID.
- **DELETE** `/api/services/app/Tank/DeleteTankAsync`: Exclui um tanque pelo seu ID.
- **PUT** `/api/services/app/Tank/UpdateTankAsync`: Atualiza um tanque existente.
- **GET** `/api/services/app/Tank/Get`: Retorna todos os tanques cadastrados.
- **GET** `/api/services/app/Tank/GetAll`: Retorna todos os tanques cadastrados.
- **POST** `/api/services/app/Tank/Create`: Cadastra um novo tanque.
- **PUT** `/api/services/app/Tank/Update`: Atualiza os dados de um tanque existente.
- **DELETE** `/api/services/app/Tank/Delete`: Remove um tanque da base de dados.

## Estrutura da Base de Dados

A tabela **Tanque** foi criada com os seguintes campos:

```sql
CREATE TABLE Tanque (
    Deposito NVARCHAR(255) PRIMARY KEY,
    Capacidade DECIMAL(18, 2) NOT NULL,
    TipoDeProduto NVARCHAR(255) NOT NULL
);
