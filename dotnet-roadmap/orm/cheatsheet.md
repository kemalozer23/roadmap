# ORM in .NET Backend Development Cheatsheet

## 1. Entity Framework Core (EF Core)

### Basics of Entity Framework Core

- **What is EF Core?**  
  An open-source, lightweight, cross-platform ORM for .NET, mapping objects to relational databases.
- **Setup**  
  Install EF Core packages:

  ```bash
  dotnet add package Microsoft.EntityFrameworkCore
  dotnet add package Microsoft.EntityFrameworkCore.SqlServer
  dotnet add package Microsoft.EntityFrameworkCore.Tools
  ```

- **DbContext Configuration**

```csharp
public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("connection_string");
    }
}
```

### Code First + Migrations

- **Code First Approach:**  
  Define models as C# classes and let EF Core generate the database schema.

  ```csharp
  public class Product
  {
      public int Id { get; set; }
      public string Name { get; set; }
      public decimal Price { get; set; }
  }
  ```

- **Add and Apply Migrations:**

  ```bash
  dotnet ef migrations add InitialCreate
  dotnet ef database update
  ```

- **Revert to a Previous Migration:**
  ```bash
  dotnet ef database update PreviousMigrationName
  ```

### Change Tracker API

- **Overview:** Tracks changes to entities during the DbContext lifetime.
- **States:** 
    - **Added**, **Modified**, **Deleted**, **Unchanged**, **Detached**
  ```csharp
  var product = context.Products.Find(1);
  context.Entry(product).State = EntityState.Modified;
  context.SaveChanges();
    ```

- **Detect changes explicitly:**
```csharp
context.ChangeTracker.DetectChanges();
```

### Loading Strategies

- **Lazy Loading:** Loads related data only when accessed.
```csharp
context.Products.Include(p => p.Category).Load();
```
Requires:
```bash
dotnet add package Microsoft.EntityFrameworkCore.Proxies
```
- **Eager Loading:**  Loads related data immediately.
```csharp
var products = context.Products.Include(p => p.Category).ToList();
```
- **Explicit Loading:**  Loads related data on demand.
```csharp
context.Entry(product).Reference(p => p.Category).Load();
```

### TPH, TPC, TPT (Inheritance Mapping)

- **Table-Per-Hierarchy (TPH):** Single table for all derived types (default in EF).
- **Table-Per-Type (TPT):** Separate table for each type.
- **Table-Per-Concrete-Class (TPC):** Separate table for each concrete class.

### Interceptors

Intercept and modify SQL commands or other EF Core operations.

```csharp
public class CustomCommandInterceptor : DbCommandInterceptor
{
    public override InterceptionResult<DbCommand> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbCommand> result)
    {
        // Modify command or log
        return base.ReaderExecuting(command, eventData, result);
    }
}

optionsBuilder.AddInterceptors(new CustomCommandInterceptor());
```

## 2. Dapper

A micro ORM for .NET, offering high performance and simplicity for executing SQL queries.

```bash
dotnet add package Dapper
```

```csharp
using (var connection = new SqlConnection("connection_string"))
{
    var products = connection.Query<Product>("SELECT * FROM Products");
}
```

### CRUD Operations
- **Insert**
```csharp
connection.Execute("INSERT INTO Products (Name, Price) VALUES (@Name, @Price)", new { Name = "Laptop", Price = 999.99 });
```
- **Update**
```csharp
connection.Execute("UPDATE Products SET Price = @Price WHERE Id = @Id", new { Price = 1099.99, Id = 1 });
```
- **Delete**
```csharp
connection.Execute("DELETE FROM Products WHERE Id = @Id", new { Id = 1 });
```
- **Select**
```csharp
var product = connection.QuerySingle<Product>("SELECT * FROM Products WHERE Id = @Id", new { Id = 1 });
```

### Advanced Features
- **Multi-mapping:**
Maps results to multiple objects.
```csharp
var sql = "SELECT * FROM Products p INNER JOIN Categories c ON p.CategoryId = c.Id";
var products = connection.Query<Product, Category, Product>(
    sql, 
    (product, category) => { product.Category = category; return product; }
);
```
- **Stored Procedures:**
```csharp
var result = connection.Query<Product>("sp_GetProducts", commandType: CommandType.StoredProcedure);
```
- **Transactions:**
```csharp
using (var transaction = connection.BeginTransaction())
{
    connection.Execute("INSERT INTO Products (...) VALUES (...)", transaction: transaction);
    transaction.Commit();
}
```

### Performance Tips
- Use parameterized queries to avoid SQL injection.
- Use QueryMultiple for multi-result sets.
- Leverage caching for frequently used data.

## Conclusion
**Entity Framework Core:** Ideal for complex domain models and abstraction.
**Dapper:** Great for performance-critical and fine-grained SQL control.