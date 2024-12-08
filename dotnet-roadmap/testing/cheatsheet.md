
# Testing in .NET Cheat Sheet

## Unit Testing

### Frameworks
#### **xUnit**
- Lightweight and extensible testing framework for .NET.
- Features:
  - `[Fact]` attribute for test methods without parameters.
  - `[Theory]` attribute for parameterized tests.
  - Parallel test execution to improve speed.
- Installation: `dotnet add package xunit`
- Example:
  ```csharp
  public class CalculatorTests
  {
      [Fact]
      public void Add_ShouldReturnSum()
      {
          var calculator = new Calculator();
          var result = calculator.Add(2, 3);
          Assert.Equal(5, result);
      }
  }
  ```

#### **NUnit**
- Another popular testing framework for .NET.
- Features:
  - `[Test]` for basic test methods.
  - `[TestCase]` for parameterized tests.
  - `[SetUp]` and `[TearDown]` for setup and cleanup logic.
- Installation: `dotnet add package NUnit`
- Example:
  ```csharp
  [TestFixture]
  public class CalculatorTests
  {
      private Calculator _calculator;

      [SetUp]
      public void SetUp()
      {
          _calculator = new Calculator();
      }

      [Test]
      [TestCase(2, 3, 5)]
      [TestCase(10, 15, 25)]
      public void Add_ShouldReturnSum(int a, int b, int expected)
      {
          var result = _calculator.Add(a, b);
          Assert.AreEqual(expected, result);
      }
  }
  ```

### Mocking
#### **Moq**
- Used for mocking dependencies in unit tests.
- Features:
  - Create mock objects for interfaces and classes.
  - Verify method calls and setup return values.
- Installation: `dotnet add package Moq`
- Example:
  ```csharp
  var mockRepository = new Mock<IRepository>();
  mockRepository.Setup(repo => repo.GetData()).Returns("Test Data");

  var service = new Service(mockRepository.Object);
  var result = service.GetData();

  mockRepository.Verify(repo => repo.GetData(), Times.Once);
  ```

### Assertion
#### **FluentAssertions**
- Provides an expressive syntax for assertions, improving readability.
- Installation: `dotnet add package FluentAssertions`
- Example:
  ```csharp
  result.Should().Be(expectedValue);
  list.Should().Contain(item);
  exception.Should().Throw<InvalidOperationException>();
  ```

### Fake Data Generators
#### **AutoFixture**
- Automatically creates mock data for complex objects.
- Installation: `dotnet add package AutoFixture`
- Example:
  ```csharp
  var fixture = new Fixture();
  var user = fixture.Create<User>(); // Creates a user with random data
  ```

#### **Bogus**
- Generates realistic fake data for properties like names, emails, etc.
- Installation: `dotnet add package Bogus`
- Example:
  ```csharp
  var faker = new Faker<User>()
      .RuleFor(u => u.Name, f => f.Name.FullName())
      .RuleFor(u => u.Email, f => f.Internet.Email());

  var fakeUser = faker.Generate();
  ```

## Integration Testing

### WebApplicationFactory
- Simplifies setup for ASP.NET Core integration tests.
- Automatically creates an in-memory server for testing.
- Example:
  ```csharp
  using var factory = new WebApplicationFactory<Program>();
  var client = factory.CreateClient();
  var response = await client.GetAsync("/api/endpoint");
  ```

### .NET Aspire
- Simplified integration testing framework for .NET.
- Focuses on reducing boilerplate and setup complexities.

## Snapshot Testing

### Verify
- Framework for snapshot-based testing, storing test outputs for comparison.
- Installation: `dotnet add package Verify`
- Example:
  ```csharp
  var result = new { Name = "Test", Age = 30 };
  await Verifier.Verify(result);
  ```

## Behavior Testing

### SpecFlow
- Supports Behavior-Driven Development (BDD) using Gherkin syntax.
- Features:
  - Write scenarios in natural language.
  - Bind steps to C# code.
- Installation: `dotnet add package SpecFlow`
- Example:
  ```gherkin
  Scenario: Add two numbers
    Given I have entered 50 into the calculator
    And I have entered 70 into the calculator
    When I press add
    Then the result should be 120
  ```

## E2E Testing

### Playwright
- Cross-browser automation framework for end-to-end tests.
- Installation: `dotnet add package Microsoft.Playwright`
- Example:
  ```csharp
  using var playwright = await Playwright.CreateAsync();
  var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
  var page = await browser.NewPageAsync();
  await page.GotoAsync("https://example.com");
  ```

## Performance Testing

### K6
- Open-source performance testing tool.
- Installation: Download [K6](https://k6.io/).
- Example script (JavaScript):
  ```javascript
  import http from 'k6/http';
  import { check } from 'k6';

  export default function () {
    const res = http.get('https://example.com');
    check(res, { 'status was 200': (r) => r.status == 200 });
  }
  ```

## Architecture Testing

### ArchUnitNet
- Ensures your application follows architecture guidelines.
- Installation: `dotnet add package ArchUnitNET`
- Example:
  ```csharp
  var rule = ArchRuleDefinition.Classes()
      .That().ResideInNamespace("MyApp.Services")
      .Should().BeSealed();
  rule.Check(Assembly.Load("MyApp"));
  ```
