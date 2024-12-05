
# API Clients & Communications in .NET

## Overview
.NET provides robust support for building APIs and communicating with external services using different protocols, including REST, gRPC, and GraphQL.

---

## 1. REST APIs

### a. Minimal APIs & REPR Pattern
.NET 6+ introduced **Minimal APIs**, which simplify the process of building APIs by reducing boilerplate.

#### Minimal API Example
```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/create", (TodoItem item) => Results.Ok(item));

app.Run();
```

#### REPR Pattern
- **Resource**: Represents the main entities (e.g., Users, Orders).
- **Endpoint**: Maps to the corresponding HTTP method (GET, POST, PUT, DELETE).
- **Parameters**: Define filters, sort orders, and pagination options.
- **Response**: Return appropriate HTTP status codes and data.

#### Example:
```csharp
app.MapGet("/users/{id}", (int id) => GetUserById(id))
    .WithName("GetUserById")
    .Produces<User>(StatusCodes.Status200OK);
```

---

### b. Gridify
**Gridify** is a library that helps you filter, sort, and paginate REST API responses efficiently.

#### Installation
```bash
dotnet add package Gridify
```

#### Usage
```csharp
var gridifyQuery = new GridifyQuery() { Filter = "Name=John", Sort = "Age" };
var result = dbContext.Users.Gridify(gridifyQuery);
```

---

## 2. gRPC

### Overview
gRPC is a high-performance, cross-platform framework for building RPC (Remote Procedure Call) APIs.

### Installation
```bash
dotnet add package Grpc.AspNetCore
dotnet add package Grpc.Net.Client
```

### Basic gRPC Service
Define a `.proto` file:
```proto
syntax = "proto3";

service Greeter {
  rpc SayHello (HelloRequest) returns (HelloReply);
}

message HelloRequest {
  string name = 1;
}

message HelloReply {
  string message = 1;
}
```

Generate C# code:
```bash
dotnet grpc --proto_file=greeter.proto --csharp_out=.
```

Implement the service:
```csharp
public class GreeterService : Greeter.GreeterBase
{
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply { Message = $"Hello {request.Name}" });
    }
}
```

---

## 3. GraphQL

### a. HotChocolate
**HotChocolate** is a popular GraphQL server for .NET.

#### Installation
```bash
dotnet add package HotChocolate.AspNetCore
```

#### Basic Configuration
```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();
app.MapGraphQL();
app.Run();
```

Define a query class:
```csharp
public class Query
{
    public string Hello() => "Hello, world!";
}
```

#### Query Example
```graphql
query {
  hello
}
```

---

## Comparison of Communication Protocols

| Feature       | REST            | gRPC             | GraphQL        |
|---------------|-----------------|------------------|----------------|
| Communication | HTTP            | HTTP/2           | HTTP           |
| Payload       | JSON            | Protobuf         | JSON           |
| Flexibility   | High            | Low (fixed RPC)  | High           |
| Performance   | Moderate        | High             | Moderate       |

---

## Conclusion
- Use **REST** for standard CRUD operations with flexible HTTP methods.
- Use **gRPC** for high-performance, low-latency communication.
- Use **GraphQL** with **HotChocolate** for flexible data querying.

### Further Reading
- [Minimal APIs Documentation](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis)
- [gRPC in .NET](https://grpc.io/docs/languages/csharp/)
- [HotChocolate Documentation](https://chillicream.com/docs/hotchocolate)
