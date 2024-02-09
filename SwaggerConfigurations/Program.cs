using SwaggerConfigurations.Utils;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();
builder.Services.AddSwaggerConfigurations();
builder.Services.AddAuthentication().AddJwtBearer();
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.Run();