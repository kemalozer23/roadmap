# .NET Middleware Cheat Sheet

## Introduction to Middleware
Middleware in .NET is software that processes requests and responses in a pipeline. Each middleware component:
- Can handle requests and responses.
- Can pass control to the next middleware in the pipeline or terminate the request.
  
The middleware is executed in the order they are added.

## Basic Middleware Pipeline
1. **Configure Middleware** in `Startup.cs` -> `Configure` method.
2. Each middleware component should call `next()` to pass the request to the next component.

```csharp
public void Configure(IApplicationBuilder app)
{
    app.UseMiddleware<FirstMiddleware>();
    app.UseMiddleware<SecondMiddleware>();
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Response from terminal middleware.");
    });
}
```

## Types of Middleware
- **Request Delegation Middleware**: Passes the request to the next component using `await next()`.
- **Terminal Middleware**: Ends the pipeline and does not call the next middleware, often by using `Run()` method.

## Built-in Middleware
1. **UseRouting**: Adds route matching to the request pipeline.
2. **UseEndpoints**: Executes matched endpoint.
3. **UseAuthentication**: Adds authentication capabilities.
4. **UseAuthorization**: Adds authorization capabilities.
5. **UseStaticFiles**: Serves static files (e.g., HTML, CSS, JS).
6. **UseCors**: Configures CORS policies.

```csharp
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
```

## Custom Middleware
Create a custom middleware by implementing the `IMiddleware` interface or by creating a method to handle `HttpContext`.

### Example: Custom Middleware Class
```csharp
public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Pre-processing
        await context.Response.WriteAsync("Before next middleware.\n");

        await _next(context);

        // Post-processing
        await context.Response.WriteAsync("After next middleware.\n");
    }
}
```
### Registering Custom Middleware
```csharp
public void Configure(IApplicationBuilder app)
{
    app.UseMiddleware<CustomMiddleware>();
}
```

## Short-hand Middleware with Lambda
You can create quick middleware inline using lambda expressions.

```csharp
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello from inline middleware!\n");
    await next();
    await context.Response.WriteAsync("Goodbye from inline middleware!\n");
});
```

## Middleware Order
The order in which middleware components are added is crucial because each middleware depends on the previous ones. Always add middlewares in this general order:

1. Exception handling and logging.
2. Static files.
3. Routing.
4. Authentication.
5. Authorization.
6. Endpoint execution.

## Common Middleware Extensions
- **UseExceptionHandler**: Global error handling.
- **UseHttpsRedirection**: Redirect HTTP to HTTPS.
- **UseStaticFiles**: Serves static files.
- **UseRouting**: Adds route matching.
- **UseAuthentication**: Enables authentication.
- **UseAuthorization**: Enables authorization.

### Example: Full Middleware Pipeline
```csharp
public void Configure(IApplicationBuilder app)
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    });
}
```

## Dependency Injection in Middleware
Middleware can access services via Dependency Injection.

```csharp
public class ServiceMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMyService _myService;

    public ServiceMiddleware(RequestDelegate next, IMyService myService)
    {
        _next = next;
        _myService = myService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _myService.DoWork();
        await _next(context);
    }
}
```
## Testing Middleware
Testing middleware can be done by:
1. **Unit Testing** the middleware with a mocked `HttpContext`.
2. **Integration Testing** using a test server with `WebApplicationFactory`.

```csharp
var context = new DefaultHttpContext();
var middleware = new CustomMiddleware((innerHttpContext) => Task.CompletedTask);
await middleware.InvokeAsync(context);
```