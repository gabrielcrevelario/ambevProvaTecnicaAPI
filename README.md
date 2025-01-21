# Ambev API

Este projeto é desenvolvido em **.NET Core 8** e utiliza **PostgreSQL** como banco de dados padrão. Ele segue os princípios de **CQRS** (Command Query Responsibility Segregation) e **DDD** (Domain-Driven Design).

## **Pré-requisitos**

Certifique-se de ter as ferramentas abaixo instaladas:

- **.NET SDK 8.0 ou superior**  
  [Baixar .NET SDK](https://dotnet.microsoft.com/download/dotnet)

- **PostgreSQL**  
  [Baixar PostgreSQL](https://www.postgresql.org/download/)

- **Ferramenta de Migração do Entity Framework Core** (opcional, para rodar migrações diretamente do terminal):  
  ```bash
  dotnet tool install --global dotnet-ef
Estrutura do Projeto
Este projeto segue uma estrutura baseada em CQRS e DDD, com as seguintes camadas principais:

Domain:

Contém as entidades, agregados, interfaces de repositórios e regras de negócio.
Application:

Contém os casos de uso (commands/queries), manipuladores e DTOs.
Infrastructure:

Contém implementações de repositórios, configurações do banco de dados e integração com serviços externos.
-- Você precisa do DOCKER instalado e ligado para usar o postgreSQL
Na pasta raiz do projeto digite 
 ```bash
 docker-compose up -d
```
- API:

Camada de apresentação, responsável por expor os endpoints REST.
va para a pasta raiz do projeto e digite no terminal
 ```bash
 dotnet restore
```

