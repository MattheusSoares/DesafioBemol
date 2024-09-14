# Desafio Bemol

Abra o arquivo DesafioBemol.sln no Visual Studio

Inicialização: Ao abrir a Solution do projeto, clique com o botão direito na Solution e defina ambas APIs como Startup Project (Solution -> Configure Startup Projects). Marque ApiUm e ApiDois, depois clique em OK.

Seguem também uma collection do Postman para realizar as chamadas das APIs. É necessário atualizar o token JWT para as chamadas de **Characters** (Header X-Authorization).

# ApiUm

A ApiUm possui 3 controllers: **Characters**, **Exceptions** e **Users**. 

A ApiUm também possui os seguintes filtros: **AuthenticationFilter**, **ExceptionFilter** e **PerformanceFilter (ActionFilter)**.

## Filters
### AuthenticationFilter

Implementa a autenticação via JWT para as funcionalidades de **Characters**.

### ExceptionFilter

Configura o tratamento de exceção global para a aplicação. Para facilitar o teste, foi disponibilizado um endpoint específico para testar este filtro de maneira forçada.

### PerformanceFilter

Escreve o tempo de execução de cada requisição no console da ApiUm.

## Controllers


### Users
- Endpoint: POST `v1/login`

    O propósito endpoint deste é realizar o login do usuário e devolver o token JWT para que ele possa acessar as funcionalidades de **Characters**.

    Para realizar o acesso correto utilize as seguintes credenciais:

    `username: user`\
    `password: pass`

### Characters

Para utilizar as funcionalidades desta controller é necessário estar autenticado.

- Endpoint: POST `v1/characters`

    Cria um novo **personagem**. Este **personagem** é inserido no Azure Cosmos DB e enviado para uma queue no Azure Service Bus. 

- Endpoint: GET `v1/characters`

    Lista todos os **personagens** salvos no Azure Cosmos DB. 

    É possível também acessar o Azure Cosmos DB pelo Azure Data Studio utilizando as credenciais presentes no código. As credenciais se encontram nas variáveis de ambiente da ApiUm.

### Exceptions
- Endpoint: POST `v1/error`

    O propósito deste endpoint é testar o ExceptionFilter.

# ApiDois

A ApiDois possui um BackgroundService que se mantém escutando a queue no Azure Service Bus, lê as mensagens e a escreve no console da ApiDois. 

A ApiDois também se comunica via gRPC com a ApiUm para realizar cadastro e leitura de dados de **montros** em memória. Para isso existe a controller **Monster**.

## Controller

### Monster
- Endpoint: POST `v1/monsters`

    Salva um novo **monstro** em memória em tempo de execução.

- Endpoint: GET `v1/monsters/{id}`

    Busca um **monstro** salvo em memória a partir do Id provido.

- Endpoint: GET `v1/monsters/`

    Busca todos os **monstros** salvos em memória.
