# API

Thin layer is only responsible for exposing Data and implements the app's interaction with the client UI.
This layer must not contain business rules or domain knowledge.

https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice#the-application-layer

## OpenAPI spec generation

OpenAPI schema generation on build via target OpenAPI (see API.csproj)

## Automapper for Entity <> DTO mapping

https://docs.automapper.org/en/stable/

## JsonPatch for patching entites

https://learn.microsoft.com/en-us/aspnet/core/web-api/jsonpatch?view=aspnetcore-8.0
