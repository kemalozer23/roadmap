# Dependency Injection (DI) in .NET Cheat Sheet

## What is Dependency Injection?
- **Dependency Injection** is a design pattern that allows for the creation of dependent objects outside of a class and provides those objects to a class in various ways.
- It promotes loose coupling and easier testing.

---

## Benefits of Dependency Injection
- **Loose Coupling**: Classes depend on abstractions rather than concrete implementations.
- **Testability**: Makes unit testing easier by injecting mock dependencies.
- **Maintainability**: Easier to change or extend the application by swapping implementations.

---

## DI in ASP.NET Core
DI is built-in and configured in the `Startup` class or via the `Program.cs` file in minimal APIs.

### Registering Services
You register services in the DI container using the `IServiceCollection` in `Program.cs` or `Startup.cs`.

```csharp
// Program.cs (Minimal APIs)
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMyService, MyService>();
builder.Services.AddScoped<IMyService, MyService>();
builder.Services.AddTransient<IMyService, MyService>();

var app = builder.Build();
```

### Service Lifetimes
- **Singleton:** Created once and shared across the entire application.
- **Scoped:** Created once per request.
- **Transient:** Created every time they are requested.

### Constructor Injection
The most common way to inject dependencies.
```csharp
public class HomeController : Controller
{
    private readonly IMyService _myService;

    public HomeController(IMyService myService)
    {
        _myService = myService;
    }
}
```

### Method Injection
Dependencies are provided as method parameters.
```csharp
public class MyService
{
    public void PerformAction(IMyDependency dependency)
    {
        dependency.DoWork();
    }
}
```

### Property Injection
Dependencies are injected into public properties.
```csharp
public class MyController
{
    [Inject]
    public IMyService MyService { get; set; }
}
```

## Built-in Services
ASP.NET Core provides many built-in services that you can inject, such as:

- ILogger<T>
- IConfiguration
- IHostingEnvironment
- IHttpClientFactory

## Using IServiceProvider
For scenarios where dependencies need to be resolved dynamically.

```csharp
public class MyClass
{
    private readonly IServiceProvider _serviceProvider;

    public MyClass(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void DoSomething()
    {
        var service = _serviceProvider.GetService<IMyService>();
        service.DoWork();
    }
}
```

## Modules and Configurations
You can organize registrations into modules.
```csharp
public static class ServiceModule
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<IMyService, MyService>();
    }
}

// Usage
builder.Services.RegisterServices();
```

## Best Practices
- Inject interfaces, not implementations.
- Avoid service locator pattern (using IServiceProvider everywhere).
- Use scoped services for database contexts.
- Dispose injected services if they implement IDisposable.