# Design Patterns Cheat Sheet

## Creational Patterns
Creational patterns focus on how objects are created, providing flexibility and reuse.

### 1. Singleton
- Ensures a class has only one instance and provides a global point of access.
```csharp
public class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new object();

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }
    }
}
```

### 2. Factory Method
- Provides an interface for creating instances of a class, with its subclasses deciding which class to instantiate.
```csharp
public abstract class Creator
{
    public abstract IProduct FactoryMethod();
}

public class ConcreteCreator : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProduct();
    }
}
```

### 3. Abstract Factory
- Provides an interface for creating families of related or dependent objects.
```csharp
public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

public class WindowsFactory : IGUIFactory
{
    public IButton CreateButton() => new WindowsButton();
    public ICheckbox CreateCheckbox() => new WindowsCheckbox();
}
```

## Structural Patterns
- Structural patterns deal with object composition and relationships, simplifying the structure.

### 1. Adapter
- Converts the interface of a class into one expected by the client.
```csharp
public interface ITarget
{
    void Request();
}

public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public void Request()
    {
        _adaptee.SpecificRequest();
    }
}
```
### 2. Decorator
- Dynamically adds responsibilities to an object without altering its structure.
```csharp
public interface IComponent
{
    void Operation();
}

public class ConcreteComponent : IComponent
{
    public void Operation() { }
}

public class Decorator : IComponent
{
    private readonly IComponent _component;

    public Decorator(IComponent component)
    {
        _component = component;
    }

    public void Operation()
    {
        _component.Operation();
        // Additional behavior
    }
}
```
### 3. Proxy
- Provides a surrogate or placeholder for another object.
```csharp
public interface ISubject
{
    void Request();
}

public class Proxy : ISubject
{
    private RealSubject _realSubject;

    public void Request()
    {
        if (_realSubject == null)
        {
            _realSubject = new RealSubject();
        }
        _realSubject.Request();
    }
}
```

## Behavioral Patterns
- Behavioral patterns define how objects communicate and interact.

### 1. Observer
- Defines a one-to-many dependency where multiple objects are notified of changes.
```csharp
public interface IObserver
{
    void Update();
}

public class Subject
{
    private List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }
}
```
## 2. Strategy
- Encapsulates a family of algorithms and allows them to be interchangeable.
```csharp
public interface IStrategy
{
    void Execute();
}

public class ConcreteStrategyA : IStrategy
{
    public void Execute() { }
}

public class Context
{
    private IStrategy _strategy;

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        _strategy.Execute();
    }
}
```
### 3. Command
- Encapsulates a request as an object, enabling parameterization and queuing.
```csharp
public interface ICommand
{
    void Execute();
}

public class Receiver
{
    public void Action() { }
}

public class ConcreteCommand : ICommand
{
    private readonly Receiver _receiver;

    public ConcreteCommand(Receiver receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.Action();
    }
}
```