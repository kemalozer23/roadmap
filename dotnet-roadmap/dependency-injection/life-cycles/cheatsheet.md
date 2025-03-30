# Lifecycle Events in .NET Cheat Sheet

## Object Lifecycle in .NET
- **Object Creation**: Objects are created using constructors.
- **Initialization**: Initialization logic happens in the constructor or `Initialize` methods.
- **Usage**: Methods are called on the object as needed.
- **Finalization**: Objects are finalized and resources are released when the object is no longer needed.

### Important Methods:
- **Constructor**: Initializes the object.
- **Dispose (IDisposable)**: Explicit resource cleanup.
- **Finalize (Destructor)**: Implicit cleanup (Garbage Collection).

---

## ASP.NET Core Application Lifecycle
ASP.NET Core manages the application lifecycle through several key events and services.

### Application Lifecycle Events:
1. **Application Starting**:
    - Configure services and middleware.
    - Called in `Program.cs` or `Startup.cs`.

2. **Application Running**:
    - Middleware pipeline handles incoming requests.
    - Lifecycle: `Request → Middleware → Controller → Response`.

3. **Application Stopping**:
    - Cleanup logic is executed when the application shuts down.

---

### Key Methods:
- **`ConfigureServices(IServiceCollection services)`**:
    - Registers dependencies and services.

- **`Configure(IApplicationBuilder app)`**:
    - Defines middleware pipeline.

---

## Middleware Lifecycle
Middleware components process requests in a pipeline.

1. **Incoming Request**:
    - Middleware processes the request in order.
  
2. **Outgoing Response**:
    - Response flows back through the middleware in reverse order.

```csharp
public void Configure(IApplicationBuilder app)
{
    app.UseMiddleware<CustomMiddleware>();
    app.UseRouting();
    app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
}
```

---

## ASP.NET Core Request Lifecycle
Each HTTP request passes through a defined pipeline:

1. **HTTP Context Created.**
2. **Routing Middleware** identifies the endpoint.
3. **Authorization Middleware** checks permissions.
4. **Endpoint Execution:** The action method runs.
5. **Response Sent:** Middleware handles the outgoing response.

---

## Service Lifecycles in Dependency Injection
.NET DI container manages service lifetimes:

**1. Singleton:**
Created once and shared across the app.
Example: Configuration services.
**2. Scoped:**
Created once per request.
Example: Database contexts.
**3. Transient:**
Created every time they are requested.
Example: Lightweight stateless services.

```csharp
builder.Services.AddSingleton<IMyService, MyService>();
builder.Services.AddScoped<IMyScopedService, MyScopedService>();
builder.Services.AddTransient<IMyTransientService, MyTransientService>();
```

---

## Lifecycle of Background Services
Background services derive from BackgroundService.

```csharp
public class MyBackgroundService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Perform background work
            await Task.Delay(1000, stoppingToken);
        }
    }
}
```
### Key Methods:
- **StartAsync:** Invoked when the service starts.
- **ExecuteAsync:** Contains the background task logic.
- **StopAsync:** Invoked when the service stops.

---

## Best Practices
- **Dispose Resources:** Implement IDisposable or use using statements.
- **Graceful Shutdown:** Use IHostApplicationLifetime for shutdown logic.
- **Monitor and Log:** Log key lifecycle events for debugging and monitoring.