
# .NET Logging Frameworks Cheat Sheet

## Overview
Logging frameworks help developers record runtime information from their applications for debugging, monitoring, and auditing purposes. In .NET, several popular logging frameworks include **Serilog**, **NLog**, and **log4net**.

---

## 1. Serilog

### Installation
To install Serilog and its sinks:
```bash
dotnet add package Serilog
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File
```

### Basic Configuration
```csharp
using Serilog;

class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Log.Information("This is an information message.");
        Log.Warning("This is a warning message.");
        Log.Error("This is an error message.");

        Log.CloseAndFlush();
    }
}
```

### Logging Levels
- `Verbose`
- `Debug`
- `Information`
- `Warning`
- `Error`
- `Fatal`

### Enrichers
Enrichers add extra information to log events:
```csharp
Log.Logger = new LoggerConfiguration()
    .Enrich.WithMachineName()
    .Enrich.WithThreadId()
    .CreateLogger();
```

### Structured Logging
Serilog supports structured logging by capturing named properties:
```csharp
Log.Information("User {UserId} logged in at {LoginTime}", userId, DateTime.Now);
```

### Configuration from `appsettings.json`
```json
{
  "Serilog": {
    "MinimumLevel": "Information",
    "WriteTo": [
      { "Name": "Console" },
      {
        "Name": "File",
        "Args": { "path": "log.txt", "rollingInterval": "Day" }
      }
    ]
  }
}
```
In `Program.cs`:
```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        CreateHostBuilder(args).Build().Run();
    }
}
```

---

## 2. NLog

### Installation
```bash
dotnet add package NLog
dotnet add package NLog.Config
dotnet add package NLog.Targets
```

### Basic Configuration
```csharp
var logger = NLog.LogManager.GetCurrentClassLogger();
logger.Info("This is an information message.");
logger.Warn("This is a warning message.");
logger.Error("This is an error message.");
```

---

## 3. log4net

### Installation
```bash
dotnet add package log4net
```

### Basic Configuration
```csharp
log4net.Config.XmlConfigurator.Configure();
ILog log = log4net.LogManager.GetLogger(typeof(Program));
log.Info("This is an information message.");
log.Warn("This is a warning message.");
log.Error("This is an error message.");
```

---

## Comparison

| Feature         | Serilog        | NLog           | log4net        |
|-----------------|----------------|----------------|----------------|
| Structured Logs | ✅             | ⚠️ (Limited)   | ❌             |
| Async Support   | ✅             | ✅             | ⚠️ (Partial)   |
| Configuration   | JSON / Code    | XML / Code     | XML            |
| Popular Sinks   | Many           | Many           | Limited        |

---

## Conclusion
Serilog is a powerful, flexible logging framework in .NET, offering structured logging and various sinks. NLog and log4net are also popular but have different strengths.

### Further Reading
- [Serilog Documentation](https://serilog.net/)
- [NLog Documentation](https://nlog-project.org/)
- [log4net Documentation](https://logging.apache.org/log4net/)
