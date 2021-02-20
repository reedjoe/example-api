# example-api

## An example API using .Net Core, comprised of multiple layers

### Projects:
- Example.API
  - API layer
  - Contains the controllers for the application
  - Contains the `Startup.cs` that configures the application
- Example.Core
  - Class library containing shared code for all projects
  - Contains: Models, Exceptions, Dtos
- Example.Data
  - Data Access Layer
  - **Not implemented yet**
- Example.Service
  - Service Layer
  - Contains all services and converters for the entity types
  - To add a new service/converter, configure in `ServiceRegistry.cs`
- Example.Test
  - Unit Test Project
  - **Not implemented yet**
