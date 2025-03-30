using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthDemo.Api.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.HasDefaultSchema("auth_demo_db");
    //     base.OnModelCreating(modelBuilder);
    // }
}