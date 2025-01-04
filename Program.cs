using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/about", () =>
{
    var applicationInfo = new
    {
        Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString(),
    };

    return applicationInfo;
})
.WithName("About");

app.Run();
