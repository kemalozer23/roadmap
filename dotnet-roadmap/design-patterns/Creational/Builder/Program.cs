var endpointBuilder = new EndpointBuilder("https://localhost");
endpointBuilder
    .Append("api")
    .Append("v1")
    .Append("user")
    .AppendParam("id", "5")
    .AppendParam("name", "test");
var url = endpointBuilder.Build();
// Console.WriteLine(url);


IEmployeeBuilder employeeBuilder = new InternalEmployeeBuilder();
employeeBuilder.SetFullName("Test User");
employeeBuilder.SetEmail("testuser@gmail.com");

var employee = employeeBuilder.BuildEmployee();

Console.WriteLine(employee.FirstName + " " + employee.LastName + " " + employee.Email);