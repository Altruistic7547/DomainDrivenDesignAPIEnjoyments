# PolyForge API

PolyForge is an ASP.NET Core Web API project structured using the Domain-Driven Design (DDD) approach, aligning the design of the software with the business domain.

The intention behind this project is to enjoy Asp .Net Web API in a way that ensures reusability, maintainability and scalability, which was achieved through mind-bending concepts such as mediator pattern, bounded contexts, entities, and value objects, just to name a few!

## Tech Enjoyed In This Project

- .NET 7
- Entity Framework Core
- AutoMapper
- MediatR
- FluentValidator
- Microsoft Dependency Injection extensions
- OpenAPI/Swagger
- MSTest
- Microsoft Logging Extension




## Solution content

API
- PolyForge AspNetCore Api

Common
- PolyForge Common Utilities

Module

- Project Management
	- ProjectManagement DependencyInjection
		- Automapper configuration, migration handler and dependency injections
  
	- ProjectManagement Domain
 		- Business Models
	
	- ProjectManagement Infrastructure
		- Context, Migrations, Repositories
  
  	- ProjectManagement Application
		- DataObjects, Queries and commands, Services, validators

Tests

- PolyForge Application UnitTests



## How to really enjoy this repository

1. Update the `ConnectionStrings` section in the `appsettings.json` file to match your database setup.

2. Open the NuGet Package Manager Console and run:
   - `update-database`

3. Enjoy!

## Key concepts enjoyed

- **Understanding Logging**: Explore structured logging and various log levels to understand their practical use cases.

- **DTO Concepts**: Learn the importance of Data Transfer Objects (DTOs) in maintaining clean data flow between layers.

- **Understanding Dependency Injection**: Understand how and when to apply DI for decoupled, maintainable code.

- **Mediator Pattern**: Use MediatR to decouple request handling from core business logic, improving the separation of concerns.

- **Modular API Approach**: Design a modular architecture for better scalability and maintainability.

## Resources I have enjoyed

- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)

- [Designing a DDD-oriented microservice - .NET](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice)

- [How to Structure Your Domain Driven Design Project in ASP.NET Core](https://medium.com/@cizu64/how-to-structure-your-domain-driven-design-project-in-asp-net-core-dbec0cc0ce53)

- [ASP.NET 6 REST API Following CLEAN ARCHITECTURE & DDD Tutorial](https://youtube.com/playlist?list=PLzYkqgWkHPKBcDIP5gzLfASkQyTdy0t4k&si=DXv3I72KVyvb467F)


## Concluding..

The goal of PolyForge is to create a flexible and extensible modular-driven API project development using DDD principles.

Thank you for reading!😊