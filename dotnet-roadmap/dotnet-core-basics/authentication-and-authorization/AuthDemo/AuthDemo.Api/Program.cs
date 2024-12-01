using System.Security.Claims;
using System.Text;
using AuthDemo.Api;
using AuthDemo.Api.Infrastructure;
using AuthDemo.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(o =>
    {
        o.Password.RequireDigit = false;
        o.Password.RequireLowercase = false;
        o.Password.RequireUppercase = false;
        o.Password.RequireNonAlphanumeric = false;
        o.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<TokenProvider>();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!)),
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(o =>
{
    o.CustomSchemaIds(id => id.FullName!.Replace("+", "-"));

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter your JWT token in this field",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT"
    };
    o.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);

    var securityRequirement = new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            new List<string>()
        }
    };

    o.AddSecurityRequirement(securityRequirement);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
// app.UseHttpsRedirection();

app.MapGet("/user/{id}", async (string id, UserManager<IdentityUser> userManager) =>
    {
        var user = await userManager.FindByIdAsync(id);

        return user is not null ? Results.Ok(user) : Results.NotFound();
    })
    .WithName("GetUser")
    .WithTags("User")
    .RequireAuthorization();

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

            return Results.Ok(new
            {
                token
            });
        })
    .WithName("LoginUser")
    .WithTags("User")
    .WithOpenApi();

app.Run();