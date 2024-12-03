# Caching Cheatsheet for .NET Backend Developers  

Caching improves application performance by storing frequently accessed data in a fast-access storage layer, reducing the need for repeated database calls or expensive computations.

---

## 1. **Memory Cache**  
Memory Cache stores data in the server’s memory, making it the fastest caching option but limited to a single server instance.

### Key Features  
- Local to the application.  
- Suitable for short-lived data.  
- Lost when the application restarts.  

### Setup and Usage  
1. **Install NuGet Package** (if using .NET Core/ASP.NET Core):  
```bash
dotnet add package Microsoft.Extensions.Caching.Memory
```
2. **Register Memory Cache:** (if using .NET Core/ASP.NET Core):  
```csharp
builder.Services.AddMemoryCache();
```
3. **Use Memory Cache:** (if using .NET Core/ASP.NET Core):  
```csharp
public class MyService
{
    private readonly IMemoryCache _cache;

    public MyService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public string GetCachedData()
    {
        string cacheKey = "myKey";
        if (!_cache.TryGetValue(cacheKey, out string cachedValue))
        {
            cachedValue = "Expensive data"; // Fetch or compute data
            _cache.Set(cacheKey, cachedValue, TimeSpan.FromMinutes(5));
        }
        return cachedValue;
    }
}
```

## 2. **Distributed Cache**
Distributed Cache allows sharing cached data across multiple servers, providing high availability and scalability.

### Key Features
- Shared across servers in a distributed system.
- Backed by external systems like Redis, SQL Server, or NCache.
- Suitable for large-scale, cloud-based, or multi-instance environments.

### Setup and Usage
(a) Redis Distributed Cache
```bash
dotnet add package Microsoft.Extensions.Caching.StackExchangeRedis
```
```csharp
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
});

public class MyService
{
    private readonly IDistributedCache _cache;

    public MyService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<string> GetCachedDataAsync()
    {
        string cacheKey = "myKey";
        var cachedValue = await _cache.GetStringAsync(cacheKey);
        if (cachedValue == null)
        {
            cachedValue = "Expensive data"; // Fetch or compute data
            await _cache.SetStringAsync(cacheKey, cachedValue, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });
        }
        return cachedValue;
    }
}
```

## 3. Application-Level Caching
Application-level caching involves using static variables or custom caching logic within the application. It’s suitable for highly specific use cases and lightweight data.
### Key Features
- Offers full control over caching logic.
- Static variables or in-memory data structures can be used.
- Not scalable across instances without external coordination.

### Usage
1- Static Variables:
```csharp
public static class AppCache
{
    private static readonly Dictionary<string, string> Cache = new();

    public static string Get(string key)
    {
        return Cache.TryGetValue(key, out var value) ? value : null;
    }

    public static void Set(string key, string value)
    {
        Cache[key] = value;
    }
}
```
2- Using Singleton Services:
```csharp
public class SingletonCache
{
    private readonly Dictionary<string, string> _cache = new();

    public string Get(string key) => _cache.TryGetValue(key, out var value) ? value : null;

    public void Set(string key, string value) => _cache[key] = value;
}

builder.Services.AddSingleton<SingletonCache>();
```

## Best Practices for Caching
- Cache Invalidation: Ensure you have strategies to invalidate or update stale data.
- Cache Size: Monitor and manage cache size to avoid memory issues.
- Consistency: Consider the consistency requirements of your application when choosing a caching strategy.
- Expiration Policies: Use absolute and sliding expirations to control cache lifetime.
- Concurrency: Be mindful of race conditions when updating cache.