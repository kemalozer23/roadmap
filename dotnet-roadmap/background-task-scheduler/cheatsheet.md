# Background Task Scheduling in .NET

## Overview
Background task scheduling is essential for executing tasks asynchronously or at scheduled intervals. In .NET, you can achieve this with **Native Background Services**, **Hangfire**, or **Quartz**.

---

## 1. Native Background Service

### What is it?
.NET provides the `BackgroundService` base class to run long-running tasks.

### Implementation
```csharp
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

public class MyBackgroundService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await DoWork();
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }

    private Task DoWork()
    {
        // Your logic here
        return Task.CompletedTask;
    }
}
```
### Registering the Service
```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<MyBackgroundService>();

var app = builder.Build();
app.Run();
```

---

## 2. Hangfire

### What is it?
**Hangfire** is a library for scheduling and managing background tasks with persistent storage support.

### Installation
```bash
dotnet add package Hangfire
dotnet add package Hangfire.AspNetCore
```
### Configuration
```csharp
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Configure Hangfire to use SQL Server storage
builder.Services.AddHangfire(config => 
    config.UseSqlServerStorage("YourConnectionString"));

// Register Hangfire server
builder.Services.AddHangfireServer();

var app = builder.Build();

// Enable Hangfire Dashboard for monitoring
app.UseHangfireDashboard();

app.MapGet("/", () => "Hangfire Dashboard is running.");

app.Run();
```
### Scheduling Tasks
- Fire-and-Forget Jobs: Executes a job once immediately.
```csharp
BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget task"));
```
- Delayed Jobs: Executes a job after a delay.
```csharp
BackgroundJob.Schedule(() => Console.WriteLine("Delayed task"), TimeSpan.FromMinutes(30));
```
- Recurring Jobs: Executes jobs at specified intervals using CRON expressions.
```csharp
RecurringJob.AddOrUpdate(() => Console.WriteLine("Recurring task"), Cron.Daily);
```
- Continuations: Executes a job after another completes.
```csharp
var parentJobId = BackgroundJob.Enqueue(() => Console.WriteLine("Parent job"));
BackgroundJob.ContinueWith(parentJobId, () => Console.WriteLine("Continuation job"));
```

---

## 3. Quartz.NET
Quartz.NET is a full-featured, open-source job scheduling system.