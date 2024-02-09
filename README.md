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


### Implementing JWT Authentication with Swagger:
Adding JWT authentication to your Swagger documentation not only enhances security but also provides a seamless experience for API users. Fortunately, with the right configuration, integrating JWT authentication into Swagger is straightforward. Let’s walk through the process step by step.

To learn how to configure Swagger in a .NET environment, I recommend referring to my earlier blog post Integrating Swagger into a .NET Web Application.

### 1. Define Security Schemes in Startup.cs
   In your Startup.cs file, you can define security schemes using the AddSwaggerGen method. Here's an example:
```csharp
services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                }
            );
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
```

In this code block, AddSecurityDefinition is used to define a security scheme named "Bearer", specifying that the API expects a JWT token in the Authorization header using the Bearer scheme.

### 2. Enable JWT Authentication
   To enable JWT authentication in your application, add the following code to your Startup.cs file:
```csharp
builder.Services.AddAuthentication().AddJwtBearer();
```

Here, AddAuthentication is used to enable authentication, while AddJwtBearer configures the JWT authentication scheme.

### 3. Incorporate Authentication and Authorization into the Application Pipeline
   Ensure that authentication and authorization are integrated into the application pipeline by adding the UseAuthentication and UseAuthorization methods:

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

UseAuthentication is responsible for establishing the user's identity, while UseAuthorization determines whether the identified user is authorized to perform the requested action or access the requested resource. It's essential to note that authorization typically follows authentication in the middleware pipeline.

By following these steps, you successfully integrate JWT authentication into Swagger, enhancing security and access control for your API endpoints.

![JWTAuth.png](SwaggerConfigurations%2FReferences%2FImages%2FJWTAuth.png)

From the screen below, it is evident that the JWT token is included in the header along with the request.

![JWTInCurl.png](SwaggerConfigurations%2FReferences%2FImages%2FJWTInCurl.png)