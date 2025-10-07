public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName} ({UserName})";
    }
}