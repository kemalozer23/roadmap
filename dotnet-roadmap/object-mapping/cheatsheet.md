# Object Mapping in .NET

## Overview
Object mapping is the process of transforming an object of one type into another. In .NET, object mapping can be done manually or using libraries like **Mapperly** and **AutoMapper**.

---

## 1. Manual Mapping
Manual mapping gives full control over how properties are mapped between objects.

### Example
```csharp
public class Source
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Destination
{
    public string FullName { get; set; }
    public int Age { get; set; }
}

public static Destination Map(Source source)
{
    return new Destination
    {
        FullName = source.Name,
        Age = source.Age
    };
}
```
Pros:
- Full control over mapping logic.
- No additional library dependency.
Cons:
- Tedious and error-prone for large objects.
- Requires manual updates when models change.

---

## 2. Mapperly
Mapperly is a source generator that creates object mappers at compile time, improving performance.

## 3. AutoMapper
AutoMapper is a popular object-to-object mapper that uses reflection to map properties.