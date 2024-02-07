## Integrating Swagger into a .NET Web Application
### Install the "Swashbuckle.AspNetCore" Package:
Start by installing the "Swashbuckle.AspNetCore" package into your project.

### Configure Swagger in the Startup.cs:
In your Startup.cs file, add Swagger to the services and application pipelines using the following code snippets:
```csharp
// Add Swagger to the services
builder.Services.AddSwaggerGen();

// Add Swagger to the application
app.UseSwagger();
app.UseSwaggerUI();
```

### Adding Minimal API to Swagger:
If you’re using Minimal API, incorporate it into Swagger by including `AddEndpointsApiExplorer()` in your service configuration:
```csharp
builder.Services.AddEndpointsApiExplorer();
```

### Adding Controller Endpoints to Swagger:
To expose your controller endpoints in Swagger, follow these steps:
Use AddControllers() to include controllers in the services. This method internally invokes `AddApiExplorer()` to generate the OpenAPI document

Use MapControllers() to add the controllers to the application
```csharp
// Add controllers to the services
builder.Services.AddControllers();

// Add controllers to the application
app.MapControllers();
```

### Accessing Swagger:
Build and run the ASP.NET Core MVC Web API project, then browse this URL (https://localhost:<port>/swagger/index.html).

### Understanding OpenAPI Document:

An OpenAPI document, typically in JSON or YAML format, serves as a comprehensive description of your API. It encompasses vital details such as available endpoints, request and response schemas, authentication methods, and more.

For further reference, you can explore the basic structure of an OpenAPI document [here](https://swagger.io/docs/specification/basic-structure/) .