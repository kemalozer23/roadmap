using AuthDemo.Api.Entities;

namespace AuthDemo.Api.Infrastructure;

public class ApplicationContext : IdentityDbContext<User, Role>
{
    
}