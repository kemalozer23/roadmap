public class InternalEmployeeBuilder : EmployeeBuilder
{
    public override void SetEmail(string email)
    {
        var arr = email.Split("@");

        Employee.Email = arr[0] + "@company.com";
    }

    public override void SetFullName(string fullName)
    {
        var arr = fullName.Split(new[] { ' ', '_', '.' });

        Employee.FirstName = arr[0];
        Employee.LastName = arr[1];
    }

    public override void SetUserName(string userName)
    {
        throw new NotImplementedException();
    }
}