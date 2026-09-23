# SMBS API

ASP.NET Core backend for **SMBS**, covering training programs, trainers, students, applications and website content. The application separates HTTP endpoints from command/query handlers and persistence.

[Live website](https://smbs.az/) · [Developer profile](https://github.com/CavidanMammadov)

## Features

- Trainings, corporate trainings and training programs.
- Trainer and student records, applications and messages.
- Services, blogs, landing pages, advice and company information.
- JWT access/refresh-token flows and role-based access for Admin, Trainer and Student roles.
- MediatR command/query handlers and FluentValidation integration.
- Cloudinary media integration and Swagger/OpenAPI documentation.
- Rate limiting on selected anonymous endpoints.

## Technology & structure

**C# · .NET 8 · ASP.NET Core Web API · EF Core · SQL Server · MediatR · FluentValidation · JWT · Cloudinary · Swagger**

| Project | Responsibility |
| --- | --- |
| `Smbs.Api` | Controllers, authentication, HTTP pipeline and configuration |
| `Smbs.Application` | Commands, queries, handlers, validation and application logic |
| `Smbs.Domain` | Entities, repository interfaces and result contracts |
| `Smbs.Persistence` | Repository implementations and EF Core migrations |

## Local development

Prerequisites: .NET 8 SDK, SQL Server, EF Core CLI tools (8.x), and a Cloudinary account for media functionality.

```sh
git clone https://github.com/CavidanMammadov/smbsAPI.git
cd smbsAPI
dotnet restore Smbs.Api/Smbs.Api.csproj
```

**Current checkout requirement:** `AppDbContext.cs` is excluded by `.gitignore` and is not included in the public repository. A fresh clone therefore needs that context and its SQL Server configuration restored before it can build or run. The migration snapshot is available in `Smbs.Persistence/Migrations`, but is not a substitute for the application context.

The API reads these settings from local configuration (`Smbs.Api/appsettings.Development.json`, ignored by Git):

```json
{
  "JwtConfig": {
    "Issuer": "SMBS.Local",
    "Audience": "SMBS.Local.Client",
    "Key": "<your-own-random-secret-at-least-32-bytes>",
    "TokenValidityMin": 15,
    "RefreshTokenValidityMin": 7
  },
  "CloudinarySettings": {
    "CloudName": "<your-cloud-name>",
    "ApiKey": "<your-api-key>",
    "ApiSecret": "<your-api-secret>"
  }
}
```

Despite its name, `RefreshTokenValidityMin` is currently passed to `AddDays` by the token service; the sample value represents seven days. SQL Server configuration depends on the missing context and is not assumed here. Use your own local credentials and never commit them.

After restoring the context and configuring a local database:

```sh
dotnet ef database update --project Smbs.Persistence --startup-project Smbs.Api -- --environment Development
dotnet run --project Smbs.Api --launch-profile https
```

Swagger is configured at **https://localhost:7163/swagger**. If needed, trust the local development certificate with `dotnet dev-certs https --trust`. These startup steps remain conditional on restoring the omitted context.

## Example endpoints

| Method | Route | Purpose |
| --- | --- | --- |
| GET | `/api/Services/GetAll` | Public service listing; rate limited |
| POST | `/api/Services/Create` | Create a service; Admin role required |
| PUT | `/api/Services` | Update a service; Admin role required |

```sh
curl https://localhost:7163/api/Services/GetAll
```

Use the running application's Swagger page for request schemas and the full route list. Authenticated requests use `Authorization: Bearer <access-token>`.

## Scope

This is the backend repository, not a complete deployment package. The live website is a project reference, not a public API sandbox. Production data and frontend source are not included.

[LinkedIn](https://www.linkedin.com/in/cavidan-m%C9%99mm%C9%99dov-780305216/)
