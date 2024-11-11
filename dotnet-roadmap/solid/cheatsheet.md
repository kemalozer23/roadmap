# SOLID Principles Cheat Sheet

## 1. **S** - **Single Responsibility Principle (SRP)**
A class should have only one reason to change, meaning it should have only one job or responsibility.

### Example:
```csharp
public class Order
{
    public int Id { get; set; }
    public string Customer { get; set; }
    public decimal Amount { get; set; }
}

public class OrderProcessor
{
    public void ProcessOrder(Order order)
    {
        // Process the order
        Console.WriteLine($"Processing order {order.Id}");
    }
}

public class OrderPrinter
{
    public void PrintOrderDetails(Order order)
    {
        // Print order details
        Console.WriteLine($"Order Id: {order.Id}, Customer: {order.Customer}, Amount: {order.Amount}");
    }
}
```
Here, the OrderProcessor class has a responsibility related to processing orders, and the OrderPrinter class handles printing. This follows SRP, as each class has a single responsibility.

## 2. **O** - **Open/Closed Principle (OCP)**
Software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification.

### Example:
```csharp
public abstract class Shape
{
    public abstract double Area();
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double Area() => Width * Height;
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public override double Area() => Math.PI * Radius * Radius;
}

public class AreaCalculator
{
    public double CalculateArea(Shape shape)
    {
        return shape.Area();
    }
}
```
Here, the Shape class is open for extension (you can add new shape types), but closed for modification (you don’t need to change existing classes). New shapes can be added by creating new classes that inherit Shape.

## 3. **L** - **Liskov Substitution Principle (LSP)**
Objects of a derived class should be replaceable with objects of the base class without affecting the functionality.

### Example:
```csharp
public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Flying");
    }
}

public class Sparrow : Bird
{
    public override void Fly()
    {
        Console.WriteLine("Sparrow flying");
    }
}

public class Ostrich : Bird
{
    public override void Fly()
    {
        // Ostriches cannot fly, but this would violate LSP
        throw new InvalidOperationException("Ostriches cannot fly");
    }
}
```
In the example above, Ostrich violates LSP because it cannot substitute Bird without breaking the behavior. Instead, we might want to make a CanFly check or rework the class design.

## 4. **I** - **Interface Segregation Principle (ISP)**
Clients should not be forced to depend on interfaces they do not use.

### Example:
```csharp
public interface IWorker
{
    void Work();
    void Eat();
}

public class Worker : IWorker
{
    public void Work()
    {
        Console.WriteLine("Working");
    }

    public void Eat()
    {
        Console.WriteLine("Eating");
    }
}

public interface IWorkOnly
{
    void Work();
}

public class WorkOnlyEmployee : IWorkOnly
{
    public void Work()
    {
        Console.WriteLine("Working only");
    }
}
```
In this example, the IWorker interface violates ISP because it forces classes that don't need to eat to implement the Eat method. IWorkOnly is a better interface for such cases.

## 5. **D** - **Dependency Inversion Principle (DIP)**
High-level modules should not depend on low-level modules. Both should depend on abstractions. Furthermore, abstractions should not depend on details. Details should depend on abstractions.

### Example:
```csharp
public interface IEmailService
{
    void SendEmail(string message);
}

public class EmailService : IEmailService
{
    public void SendEmail(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

public class Notification
{
    private readonly IEmailService _emailService;

    public Notification(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public void Notify(string message)
    {
        _emailService.SendEmail(message);
    }
}
```
In this example, the Notification class depends on an abstraction (IEmailService), not the concrete implementation (EmailService). This allows easy substitution and testing.

---

## Summary:
- **SRP**: A class should have only one reason to change.
- **OCP**: A class should be open for extension, but closed for modification.
- **LSP**: Derived classes must be substitutable for their base classes.
- **ISP**: Clients should not be forced to depend on interfaces they do not use.
- **DIP**: High-level modules should depend on abstractions, not on concrete implementations.