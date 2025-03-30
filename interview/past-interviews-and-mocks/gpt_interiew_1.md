# Junior/Mid-Level .NET Developer Interview Questions and Answers

---

## **1. C# and .NET Fundamentals**

### **Q: What are access modifiers in C#?**
**A:** Access modifiers define the accessibility of classes, methods, and other members in C#. The main access modifiers are:
- `public`: Accessible from anywhere.
- `private`: Accessible only within the containing class.
- `protected`: Accessible within the containing class and derived classes.
- `internal`: Accessible within the same assembly.
- `protected internal`: Accessible within the same assembly and derived classes.

---

### **Q: What is the difference between `var`, `dynamic`, and `object`?**
**A:**
- `var`: Statically typed. The type is determined at compile time.
- `dynamic`: Dynamically typed. The type is resolved at runtime.
- `object`: Base type for all data types in .NET. Requires casting for specific type usage.

---

### **Q: What are `ref` and `out` keywords? What are their differences?**
**A:** Both are used to pass arguments by reference, but:
- `ref`: Requires that the variable be initialized before being passed.
- `out`: Does not require prior initialization. The method must assign a value to the variable before returning.

---

### **Q: What is Garbage Collection (GC) in .NET?**
**A:** Garbage Collection automatically manages memory by reclaiming unused objects and freeing up space. It reduces memory leaks by periodically cleaning up unreferenced objects.

---

### **Q: What is the difference between `IEnumerable`, `IQueryable`, and `List`?**
**A:**
- `IEnumerable`: Used for forward-only iteration. Query executed in memory.
- `IQueryable`: Supports deferred execution. Queries can be translated to SQL for database execution.
- `List`: A concrete collection type for storing items in memory. Provides more methods for manipulation.

---

## **2. Object-Oriented Programming (OOP) and SOLID Principles**

### **Q: What are the four main principles of OOP?**
**A:**
1. **Encapsulation**: Bundling data and methods together while restricting access.
2. **Inheritance**: Deriving new classes from existing ones.
3. **Polymorphism**: Using a single interface for different underlying forms (e.g., method overriding).
4. **Abstraction**: Hiding implementation details and exposing only necessary functionality.

---

### **Q: What is Dependency Injection (DI), and why is it important?**
**A:** DI is a design pattern where a class's dependencies are provided externally rather than created within the class. This improves testability, modularity, and maintainability.

---

### **Q: What is the Single Responsibility Principle (SRP)?**
**A:** SRP states that a class should have only one reason to change, i.e., it should focus on a single functionality or responsibility.

---

## **3. ASP.NET Core and Web Development**

### **Q: What is Middleware in ASP.NET Core?**
**A:** Middleware is a component that processes HTTP requests and responses in the ASP.NET Core pipeline. Examples include authentication, logging, and exception handling.

---

### **Q: What is Model Binding in ASP.NET Core?**
**A:** Model Binding maps incoming request data (e.g., query strings, form data) to controller action parameters or ViewModel properties.

---

### **Q: What is the difference between `GET`, `POST`, `PUT`, and `DELETE`?**
**A:**
- `GET`: Retrieve data.
- `POST`: Create new resources.
- `PUT`: Update existing resources.
- `DELETE`: Remove resources.

---

## **4. Entity Framework Core and Databases**

### **Q: What is the difference between Lazy Loading, Eager Loading, and Explicit Loading?**
**A:**
- **Lazy Loading**: Loads related data only when accessed.
- **Eager Loading**: Loads related data with the initial query using `Include`.
- **Explicit Loading**: Loads related data manually with additional queries.

---

### **Q: What is Migration in Entity Framework Core?**
**A:** Migration is a way to incrementally update the database schema based on changes in the model classes.

---

### **Q: What is the N+1 Query Problem? How do you solve it?**
**A:** N+1 occurs when a query generates additional queries for each related entity. Use `Include` in Entity Framework to load related data efficiently.

---

## **5. Testing and Debugging**

### **Q: What is Unit Testing?**
**A:** Unit Testing involves testing individual components of an application in isolation to ensure correctness.

---

### **Q: What is Exception Handling?**
**A:** Exception Handling captures and manages runtime errors. Use `try-catch-finally` blocks to handle exceptions gracefully.

---

## **6. Docker and CI/CD**

### **Q: What is Docker, and why is it used?**
**A:** Docker is a platform for containerization. It enables packaging applications with their dependencies to ensure consistency across environments.

---

### **Q: What is the difference between Docker Container and Virtual Machine?**
**A:** Containers share the host OS kernel and are lightweight, while VMs include a full OS and are more resource-intensive.

---

## **7. General Questions**

### **Q: What is Clean Code?**
**A:** Clean Code is easy to read, understand, and maintain. Characteristics include meaningful names, small functions, and adherence to design principles.

---

### **Q: What is the difference between Monolithic and Microservices architectures?**
**A:**
- **Monolithic**: Single codebase, tightly coupled components.
- **Microservices**: Independent, loosely coupled services focused on specific functionalities.