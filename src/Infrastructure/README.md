# Infrastructure

The infrastructure layer is how the data that is initially held in domain entities (in memory) is persisted in databases or another persistent store.

We use Entity Framework Core to implement the Repository pattern classes that use a DBContext to persist data in a PostgreSQL relational database.

https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice#the-infrastructure-layer

## PostgreSQL and pgAdmin with Docker compose

At root folder level:

```
docker compose up
```

pgAdmin : http://localhost:5050

https://github.com/docker/awesome-compose/tree/master/postgresql-pgadmin

## EF Code First

At Infrastructure folder level:

```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef --startup-project ../API/ migrations add Initial
dotnet ef --startup-project ../API/ database update
```

The commands above create the DB if needed or update it.

https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli#create-the-database

## Pagination

Repositories support Pagination.

https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page?view=aspnetcore-8.0

## Id generation

To prevent index fragmentation, the UUID of the entities are sequential.

https://github.com/mareek/UUIDNext?tab=readme-ov-file

## Ollama integration

Open-webui and Ollama to run IA in docker.

OllamaSharp to call IA from .NET context.

```
docker compose up
```

https://github.com/ollama/ollama

https://github.com/awaescher/OllamaSharp
