# .NET Filters and Attributes Cheat Sheet

## Introduction to Filters
Filters in ASP.NET Core are components that run code before or after specific stages in the request processing pipeline. They are used to:
- **Inspect** or **modify** incoming requests and outgoing responses.
- **Encapsulate** cross-cutting concerns like logging, authorization, caching, etc.

Filters can be applied globally, to controllers, or to individual actions.

## Types of Filters
ASP.NET Core provides several types of filters, each serving a distinct purpose:

1. **Authorization Filters**
2. **Resource Filters**
3. **Action Filters**
4. **Exception Filters**
5. **Result Filters**

## Types of Filters

### 1. Authorization Filters
- **Purpose**: Handle authorization logic, verifying if the user is allowed to access a resource.
- **Execution**: Runs first in the filter pipeline, before any other filters.
- **Usage**: Typically used for role-based or policy-based authorization.
  
```csharp
public class CustomAuthorizationFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Custom authorization logic
        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
```
### 2. Resource Filters
- **Purpose**: Execute code before and after the rest of the pipeline, allowing for caching or resource management.
- **Execution**: Runs after authorization filters and before model binding.
- **Usage**: Useful for operations that need to run early, like setting up resources.

```csharp
public class CustomResourceFilter : IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        // Code before the action executes
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        // Code after the action executes
    }
}
```

### 3. Action Filters
- **Purpose**: Run code immediately before and after an action method.
- **Execution**: Runs after resource filters, before the action, and after the action completes.
- **Usage**: Commonly used for validation, logging, or modifying action results.

```csharp
public class CustomActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Code before the action method executes
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Code after the action method executes
    }
}
```

### 4. Exception Filters
- **Purpose**: Handle exceptions thrown by actions or other filters.
- **Execution**: Runs only if there is an unhandled exception.
- **Usage**: Used for centralized error handling or logging.

```csharp
public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        // Exception handling logic
        context.Result = new ContentResult
        {
            Content = "An error occurred.",
            StatusCode = 500
        };
    }
}
```

### 5. Result Filters
- **Purpose**: Run code before and after the execution of the action result.
- **Execution**: Runs after action filters, but only when the action method has executed successfully.
- **Usage**: Used to modify the result, add headers, or log results.

```csharp
public class CustomResultFilter : IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        // Code before the result executes
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        // Code after the result executes
    }
}
```

## Using Filters with Attributes

Filters can be applied to controllers or actions using attributes. This makes it easy to specify which filter should apply to a given controller or action.

```csharp
[CustomAuthorizationFilter]
public class SampleController : Controller
{
    [CustomActionFilter]
    public IActionResult SampleAction()
    {
        return View();
    }
}
```

## Applying Filters
Filters can be applied in several ways:
1. **Globally**: Applied to all controllers and actions.
2. **Controller-level**: Applied to all actions in a specific controller.
3. **Action-level**: Applied to a single action.

### 1. Global Filters
Add filters globally in `Startup.cs`.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers(options =>
    {
        options.Filters.Add<CustomExceptionFilter>();
    });
}
```

### 2. Controller-Level and Action-Level Filters
You can apply filters at the controller or action level by using attributes, allowing for fine-grained control over where filters are applied.

```csharp
[CustomAuthorizationFilter]
public class SampleController : Controller
{
    [CustomActionFilter]
    public IActionResult SampleAction()
    {
        return View();
    }
}
```
In this example:
- CustomAuthorizationFilter is applied to the entire controller, affecting all actions within it.
- CustomActionFilter is applied only to SampleAction, affecting only this specific action.

## Creating Custom Attributes for Filters

To create custom filters as attributes, implement the filter interface and inherit from `Attribute`.

### Example: Custom Logging Attribute

```csharp
public class CustomLoggingAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Logic before the action executes
        Console.WriteLine("Action is starting.");
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        // Logic after the action executes
        Console.WriteLine("Action has finished.");
    }
}
```

## Applying Custom Attributes
Apply the custom attribute directly to controllers or actions.
```csharp
[CustomLogging]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
```

### Additional Notes
- Order of Execution: Filters are executed in a specific order (Authorization → Resource → Action → Exception → Result).
- Dependency Injection: Custom filters can also use Dependency Injection by implementing IAsyncActionFilter and using constructor injection.
