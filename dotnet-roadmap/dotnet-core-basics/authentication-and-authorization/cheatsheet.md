# Authentication & Authorization Cheat Sheet

## Introduction to Authentication & Authorization

- **Authentication**: Verifies the identity of a user or system.
- **Authorization**: Determines the permissions of an authenticated user or system.

### Common Terminologies
- **Claims**: Key-value pairs representing user information (e.g., `email`, `role`).
- **Tokens**: Encoded data structures used to convey identity or authorization (e.g., JWT).
- **Scopes**: Represent specific access rights or permissions.
- **Identity Providers (IdP)**: Services that manage user authentication (e.g., Auth0, IdentityServer).

### Key Standards
- **OAuth 2.0**: Framework for delegation-based authorization.
- **OpenID Connect (OIDC)**: Built on OAuth 2.0, adds authentication capabilities.
- **OWASP Top 10**: A set of security risks to address when implementing authentication and authorization.

## ASP.NET Core Identity

ASP.NET Core Identity is a membership system for managing users, roles, and authentication in applications.

### Key Features
- User management (registration, login, etc.)
- Role-based access control (RBAC)
- Password management and security
- Token-based authentication (e.g., JWT)

### Setting Up Identity
1. **Install the necessary packages**:
    ```bash
    dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
    ```

2. **Configure services in `Startup.cs`**:

    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

        services.AddControllersWithViews();
    }
   ```

3. **Add middleware in the request pipeline**:

    ```csharp
    public void Configure(IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });
    }
   ```

## Customizing Identity

You can extend the IdentityUser class to add custom properties.

    ```csharp
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
   ```

Update the configuration to use your custom user class:

    ```csharp
    services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
    ```

## IdentityServer and OpenIddict

### IdentityServer
IdentityServer is an OpenID Connect and OAuth 2.0 framework for ASP.NET Core, enabling secure authentication and authorization in modern applications.

#### Key Features
- Supports OAuth 2.0 and OpenID Connect (OIDC)
- Centralized authentication for multiple apps
- Token issuance (JWT, reference tokens)
- Extensible with custom grant types and stores

#### Setting Up IdentityServer
1. **Install the necessary package**:
   ```bash
   dotnet add package Duende.IdentityServer
   ```
2. **Configure IdentityServer in Startup.cs**:
   ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddIdentityServer()
                .AddInMemoryClients(Clients.Get())
                .AddInMemoryApiResources(ApiResources.Get())
                .AddInMemoryIdentityResources(IdentityResources.Get())
                .AddTestUsers(TestUsers.Users)
                .AddDeveloperSigningCredential();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseIdentityServer();
    }
   ```
3. **Define resources and clients**:
- Clients: Represent applications that can request tokens.
- ApiResources: Represent APIs protected by IdentityServer.
- IdentityResources: Represent user identity data (e.g., openid, profile).

Example configuration for clients:
```csharp
public static IEnumerable<Client> Get() =>
    new List<Client>
    {
        new Client
        {
            ClientId = "client_id",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = { new Secret("client_secret".Sha256()) },
            AllowedScopes = { "api1" }
        }
    };
```

### OpenIddict
OpenIddict is a flexible library for implementing OpenID Connect and OAuth 2.0 in .NET.

#### Key Features
- Simplified integration with ASP.NET Core Identity
- Works seamlessly with Entity Framework Core
- Supports various grant types (authorization code, client credentials, etc.)

#### Setting Up OpenIddict

**1. Install Required Packages**
Use the following command to install the necessary packages:
- `OpenIddict.AspNetCore`
- `OpenIddict.EntityFrameworkCore`

**2. Configure OpenIddict in `Startup.cs`**

**Core Configuration**
- Use Entity Framework Core for the database context.

**Server Configuration**
- Enable the Authorization Code flow.
- Configure endpoints like `/connect/authorize` and `/connect/token`.

**Validation Configuration**
- Set up local server validation and integrate with ASP.NET Core.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddOpenIddict()
        .AddCore(options =>
        {
            options.UseEntityFrameworkCore()
                   .UseDbContext<ApplicationDbContext>();
        })
        .AddServer(options =>
        {
            options.AllowAuthorizationCodeFlow()
                   .RequireProofKeyForCodeExchange()
                   .AcceptAnonymousClients();
            options.RegisterScopes("api1");
            options.SetAuthorizationEndpointUris("/connect/authorize")
                   .SetTokenEndpointUris("/connect/token");
            options.UseAspNetCore()
                   .EnableAuthorizationEndpointPassthrough()
                   .EnableTokenEndpointPassthrough();
        })
        .AddValidation(options =>
        {
            options.UseLocalServer();
            options.UseAspNetCore();
        });
}
```

## Auth0 and OpenID Connect (OIDC)

### Auth0
Auth0 is a cloud-based authentication and authorization service that simplifies the integration of secure login and access control into applications.

#### Key Features
- Supports multiple identity providers (social, enterprise, database).
- Built-in support for OAuth 2.0 and OpenID Connect.
- Provides tools for Single Sign-On (SSO) and Multi-Factor Authentication (MFA).

#### Setting Up Auth0 with ASP.NET Core

**1. Install Required Packages**
Install the `Microsoft.AspNetCore.Authentication.OpenIdConnect` package.

**2. Configure Authentication in `Startup.cs`**

- Add the OpenID Connect authentication scheme.
- Configure Auth0 details like domain, client ID, and client secret.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "Cookies";
        options.DefaultChallengeScheme = "oidc";
    })
    .AddCookie("Cookies")
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = "https://YOUR_AUTH0_DOMAIN/";
        options.ClientId = "YOUR_CLIENT_ID";
        options.ClientSecret = "YOUR_CLIENT_SECRET";
        options.ResponseType = "code";
        options.SaveTokens = true;
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("email");
    });

    services.AddControllersWithViews();
}

public void Configure(IApplicationBuilder app)
{
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapDefaultControllerRoute();
    });
}
```

### OpenID Connect (OIDC)
OpenID Connect is an identity layer built on top of OAuth 2.0 for authentication.

#### Key Features
- Standardized user authentication with an identity token (ID Token).
- Provides basic profile information (e.g., name, email, picture).
- Compatible with major identity providers (Google, Facebook, Microsoft).
#### Basic OIDC Flow
- Authorization Request: The client redirects the user to the identity provider.
- Authorization Code: The identity provider returns an authorization code to the client.
- Token Exchange: The client exchanges the authorization code for access and ID tokens.
- Token Validation: The client validates the ID token.

Example: Using OIDC with ASP.NET Core
Already demonstrated above with Auth0.


## OWASP Top 10 Security Risks in Authentication

OWASP (Open Web Application Security Project) highlights common security risks in authentication and authorization. Below are key risks and how to mitigate them:

### 1. Broken Access Control
- **Risk**: Unauthorized users accessing restricted resources.
- **Mitigation**:
  - Enforce role-based and claims-based access control.
  - Use middleware like `AuthorizeAttribute` to restrict access.
  - Perform server-side validation of permissions.

### 2. Cryptographic Failures
- **Risk**: Weak encryption of sensitive data like passwords and tokens.
- **Mitigation**:
  - Use strong hashing algorithms like `PBKDF2`, `bcrypt`, or `Argon2` for passwords.
  - Enable HTTPS for all communication.
  - Use secure token storage mechanisms (e.g., secure cookies or local storage).

### 3. Injection
- **Risk**: Malicious input altering queries or commands.
- **Mitigation**:
  - Use parameterized queries to prevent SQL injection.
  - Sanitize inputs, especially in OAuth or OpenID Connect parameters.

### 4. Insecure Design
- **Risk**: Designing authentication systems without considering security.
- **Mitigation**:
  - Follow security principles like "least privilege" and "fail securely."
  - Use frameworks like IdentityServer or Auth0 to avoid custom implementations.

### 5. Security Misconfiguration
- **Risk**: Incorrect security settings, such as misconfigured CORS policies or weak JWT validation.
- **Mitigation**:
  - Validate JWTs using the correct public key and issuer.
  - Harden your authentication middleware configurations.

### 6. Vulnerable and Outdated Components
- **Risk**: Using outdated libraries or components with known vulnerabilities.
- **Mitigation**:
  - Regularly update authentication libraries like IdentityServer or OpenIddict.
  - Monitor vulnerabilities via tools like Dependabot or Snyk.

### 7. Identification and Authentication Failures
- **Risk**: Weak passwords, lack of account lockout, or improper session management.
- **Mitigation**:
  - Enforce strong password policies and MFA.
  - Implement account lockout mechanisms for repeated failed attempts.
  - Use secure session tokens and ensure they are invalidated on logout.

### 8. Software and Data Integrity Failures
- **Risk**: Unauthorized tampering with data or software updates.
- **Mitigation**:
  - Use code signing and TLS to protect integrity.
  - Secure token issuance pipelines with proper access controls.

### 9. Security Logging and Monitoring Failures
- **Risk**: Lack of auditing and logging for authentication events.
- **Mitigation**:
  - Log all authentication events (logins, logouts, failed attempts).
  - Use tools like Azure Monitor or ELK stack to analyze logs.

### 10. Server-Side Request Forgery (SSRF)
- **Risk**: Exploiting server-side calls to third-party APIs.
- **Mitigation**:
  - Validate and sanitize all user-controlled URLs.
  - Restrict outgoing network traffic from your server.

---

### Best Practices for Authentication Security
1. Use established libraries (e.g., ASP.NET Core Identity, Auth0, IdentityServer).
2. Implement Multi-Factor Authentication (MFA).
3. Regularly audit and test your authentication systems.
4. Follow OWASP standards for secure coding and design.