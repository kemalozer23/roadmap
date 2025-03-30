# .NET Options and Configuration Cheatsheet

## Chapter 1: What is Configuration in .NET?

Configuration in .NET allows you to read settings from various sources (files, environment variables, etc.) to customize how an application behaves at runtime.

### Sources:
- `appsettings.json`
- `appsettings.{Environment}.json` (e.g., `appsettings.Development.json`)
- Environment variables
- Command line arguments
- Azure App Configuration
- Custom sources

## Chapter 2: Configuration API

.NET provides the `IConfiguration` interface to interact with configuration settings.

### Reading Values:
```csharp
IConfiguration configuration = builder.Build();
var value = configuration["Key"];
```
### Binding to Objects:

Use IConfiguration.GetSection() to bind configuration sections to classes.
```csharp
public class MySettings
{
    public string Option1 { get; set; }
    public int Option2 { get; set; }
}

var mySettings = new MySettings();
configuration.GetSection("MySettings").Bind(mySettings);
```

## Chapter 3: Setting Up Configuration in .NET Core

In `Program.cs` or `Startup.cs`, set up configuration sources:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, config) =>
        {
            var env = context.HostingEnvironment;
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                  .AddEnvironmentVariables();
        })
        .ConfigureServices((hostContext, services) =>
        {
            services.Configure<MySettings>(hostContext.Configuration.GetSection("MySettings"));
        });
```

## Chapter 4: Options Pattern

The **Options Pattern** provides a way to bind configuration data to strongly typed objects and inject those objects where needed.

### Defining Options:
```csharp
public class MyOptions
{
    public string Option { get; set; }
}
```
### Registering Options
```csharp
services.Configure<MyOptions>(configuration.GetSection("MyOptions"));
```
### Injecting Options:
```csharp
public class MyService
{
    private readonly IOptions<MyOptions> _options;
    public MyService(IOptions<MyOptions> options)
    {
        _options = options;
    }
}
```
### IOptionsSnapshot for runtime options (supports live reload):
```csharp
public class MyService
{
    private readonly IOptionsSnapshot<MyOptions> _optionsSnapshot;
    public MyService(IOptionsSnapshot<MyOptions> optionsSnapshot)
    {
        _optionsSnapshot = optionsSnapshot;
    }
}
```
### IOptionsMonitor for real-time changes and notifications:
```csharp
public class MyService
{
    private readonly IOptionsMonitor<MyOptions> _optionsMonitor;
    public MyService(IOptionsMonitor<MyOptions> optionsMonitor)
    {
        _optionsMonitor = optionsMonitor;
    }
}
```

## Chapter 5: Environment-Specific Configurations

Use environment-specific configuration files, like `appsettings.Development.json`, and specify which environment to use via the `ASPNETCORE_ENVIRONMENT` environment variable.

```bash
ASPNETCORE_ENVIRONMENT=Development
```

## Chapter 6: Secrets Management

### User Secrets:
Store secrets in development environments. Use `dotnet user-secrets` for managing sensitive information.

```bash
dotnet user-secrets init
dotnet user-secrets set "ApiKey" "your_api_key"
```
### Azure Key Vault:
Securely store secrets in production.
```csharp
builder.AddAzureKeyVault(new Uri("https://<your-keyvault-name>.vault.azure.net/"), new DefaultAzureCredential());
```

## Chapter 7: Configuration in Unit Testing

For unit tests, you can mock or provide a specific configuration setup:

```csharp
var inMemorySettings = new Dictionary<string, string> {
    { "MySetting:Option", "TestValue" }
};

IConfiguration configuration = new ConfigurationBuilder()
    .AddInMemoryCollection(inMemorySettings)
    .Build();
```

## Chapter 8: Key Methods

### **AddJsonFile()**: 
Loads configuration from JSON files.

### **AddEnvironmentVariables()**: 
Loads configuration from environment variables.

### **AddCommandLine()**: 
Loads configuration from command line arguments.

### **GetValue<T>()**: 
Retrieves a single configuration value.
```csharp
var option = configuration.GetValue<string>("MyOption");
```
### **GetSection()**:
Retrieves a specific section of configuration.
```csharp
var section = configuration.GetSection("MySection");
```

## Chapter 9: Benefits of the Options Pattern

- **Type safety**: Provides strongly typed configuration binding, reducing errors caused by typos.
- **Centralized configuration management**: Makes it easier to manage and organize settings in one place.
- **Support for multiple configuration sources**: You can combine configuration from various sources like JSON files, environment variables, and more.
- **Support for binding configuration to strongly typed objects**: It allows binding complex configuration structures into POCOs (Plain Old CLR Objects), making them easier to work with in your application.