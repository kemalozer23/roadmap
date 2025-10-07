public interface IEmployeeBuilder
{
    Employee BuildEmployee();
    void SetEmail(string email);
    void SetFullName(string fullName);
    void SetUserName(string userName);
}

public abstract class EmployeeBuilder : IEmployeeBuilder
{
    protected Employee Employee { get; set; }

    public EmployeeBuilder()
    {
        Employee = new Employee();
    }

    public abstract void SetFullName(string fullName);
    public abstract void SetEmail(string email);
    public abstract void SetUserName(string userName);

    public Employee BuildEmployee() => Employee;
}