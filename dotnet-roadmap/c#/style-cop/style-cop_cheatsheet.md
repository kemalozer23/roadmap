
# StyleCop Cheat Sheet

## What is StyleCop?
StyleCop is a code analysis tool for C# that enforces a set of style and convention rules on your codebase. It helps maintain consistent formatting, naming, and layout across your code by reporting warnings for violations.

### How to Install StyleCop
- **For .NET CLI**: `dotnet add package StyleCop.Analyzers`
- **In Visual Studio**: Use the NuGet Package Manager to install the `StyleCop.Analyzers` package.

### Basic Configuration
- **Default ruleset**: You can configure StyleCop rules in `stylecop.json` or by setting severity levels in `.editorconfig`.
- **EditorConfig Example**:
  ```editorconfig
  # .editorconfig
  [*.cs]
  dotnet_diagnostic.SA1309.severity = warning
  dotnet_diagnostic.SA1401.severity = error
  ```

---

## StyleCop Rule Categories

1. [Documentation Rules](#documentation-rules)
2. [Layout Rules](#layout-rules)
3. [Maintainability Rules](#maintainability-rules)
4. [Naming Rules](#naming-rules)
5. [Ordering Rules](#ordering-rules)
6. [Readability Rules](#readability-rules)
7. [Spacing Rules](#spacing-rules)

---

## Documentation Rules
These rules enforce XML documentation for classes, methods, properties, etc.

- **SA1600**: All public elements must have documentation.
- **SA1601**: Partial elements should have documentation.
- **SA1611**: Documentation for parameters must be included.
- **SA1615**: Documentation for return values should be provided.
- **SA1623**: The summary must match element behavior.

```csharp
/// <summary>
/// Calculates the area of a circle.
/// </summary>
/// <param name="radius">Radius of the circle.</param>
/// <returns>Area of the circle.</returns>
public double CalculateArea(double radius) { ... }
```

---

## Layout Rules
These rules enforce consistent layout of code elements for readability.

- **SA1501**: Braces must be on the same line as the declaration.
- **SA1503**: `if` statements should use braces.
- **SA1516**: Elements should have one blank line between them.
- **SA1518**: Code files should not have blank lines at the end.

```csharp
// SA1503 Example
if (condition)
{
    DoSomething();
}
```

---

## Maintainability Rules
These rules help maintain clean, manageable code.

- **SA1400**: Code elements should be declared explicitly (no `var` for unclear types).
- **SA1401**: Fields must be private.
- **SA1402**: Only one type per file.
- **SA1404**: Code should not include `#pragma` directives to suppress warnings.

```csharp
// SA1401 Example
private int counter;
```

---

## Naming Rules
Enforce consistent naming conventions for identifiers.

- **SA1300**: Elements should start with an uppercase letter.
- **SA1305**: Variables should not use Hungarian notation.
- **SA1309**: Field names should start with an underscore `_`.
- **SA1311**: Static readonly fields should be in uppercase.

```csharp
// SA1309 Example
private int _age;

// SA1311 Example
private static readonly int MAX_AGE = 100;
```

---

## Ordering Rules
These rules specify the order of elements within files.

- **SA1200**: Using directives must be placed at the top of the file.
- **SA1201**: Fields should appear before methods in a class.
- **SA1210**: Static members should appear before non-static members.

```csharp
using System; // SA1200 Example

public class MyClass
{
    private int _count; // Fields before methods - SA1201
    
    public void Method() { }
}
```

---

## Readability Rules
Rules that improve code clarity and readability.

- **SA1101**: Prefix instance members with `this`.
- **SA1121**: Use built-in types (e.g., `int` instead of `Int32`).
- **SA1119**: Avoid unnecessary parentheses.
- **SA1131**: Use lambda expression syntax for simple expressions.

```csharp
// SA1101 Example
this.DoSomething();

// SA1121 Example
int number = 5;
```

---

## Spacing Rules
These rules enforce consistent use of spacing.

- **SA1000**: Keywords must be spaced correctly.
- **SA1005**: Single space between closing parentheses and an opening brace.
- **SA1028**: Code must not use trailing whitespace.

```csharp
// SA1005 Example
if (condition) { DoSomething(); }

// No trailing whitespace - SA1028
```

---

## Customizing StyleCop Rules
To customize rules, edit the `stylecop.json` file in your project.

```json
{
  "settings": {
    "documentationRules": {
      "documentPrivateElements": true
    },
    "orderingRules": {
      "elementOrder": [
        "kind",
        "accessibility"
      ]
    }
  }
}
```

---

## Key StyleCop Analyzers

| Rule ID  | Description                            |
|----------|----------------------------------------|
| SA1600   | Documentation required for public APIs |
| SA1401   | Fields must be private                 |
| SA1309   | Field names should begin with `_`      |
| SA1516   | Elements separated by one blank line   |
| SA1101   | Prefix instance members with `this`    |
| SA1200   | Using directives at top of file        |
| SA1201   | Fields before methods                  |

---

## Additional Resources

- **Documentation**: [StyleCop Analyzers GitHub](https://github.com/DotNetAnalyzers/StyleCopAnalyzers)
- **Rule Reference**: [StyleCop Rule Descriptions](https://documentation.help/StyleCop/)

This cheat sheet covers essential StyleCop rules and basic configuration tips to help you maintain consistent code style in C# projects.
