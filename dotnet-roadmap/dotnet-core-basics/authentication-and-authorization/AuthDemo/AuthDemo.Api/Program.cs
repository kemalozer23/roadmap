using System.Text;
using AuthDemo.Api;
using AuthDemo.Api.Infrastructure;
using AuthDemo.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<TokenProvider>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!)),
        ValidIssuer = builder.Configuration["Jwt:Issuers"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/user/register", async (RegisterUser request, UserManager<IdentityUser> userManager) =>
    {
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            Results.BadRequest("Email and Password are required.");

        var user = new IdentityUser { UserName = request.Email, Email = request.Email };
        var result = await userManager.CreateAsync(user, request.Password);

        return result.Succeeded ? Results.Ok("User registered successfully!") : Results.BadRequest(result.Errors);
    })
    .WithName("RegisterUser")
    .WithTags("User")
    .WithOpenApi();

app.MapPost("/user/login",
        async (LoginUser request, UserManager<IdentityUser> userManager, TokenProvider tokenProvider) =>
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                Results.BadRequest("Email and Password are required");
            }

            var user = await userManager.FindByEmailAsync(request.Email);

            if (user == null)
                return Results.BadRequest("User was not found.");

            var verified = await userManager.CheckPasswordAsync(user, request.Password);

            if (!verified)
                return Results.BadRequest("The password is incorrect.");

            var token = tokenProvider.Create(user);

            return Results.Ok(token);
        })
    .WithName("LoginUser")
    .WithTags("User")
    .WithOpenApi();

app.MapGet("/user/{id:guid}", async (UserManager<IdentityUser> userManager, Guid id) =>
    {
        var user = await userManager.FindByIdAsync(id.ToString());

        return user is not null ? Results.Ok(user) : Results.NotFound();
    })
    .WithName("GetUser")
    .WithTags("User")
    .RequireAuthorization()
    .WithOpenApi();

app.Run();