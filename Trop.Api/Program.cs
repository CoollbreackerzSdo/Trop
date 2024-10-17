using Microsoft.EntityFrameworkCore;

using Scalar.AspNetCore;

using Trop.Api.Helpers.Env;
using Trop.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Envs
Env.ReadEnvFile(@"../.env");
builder.Configuration.ConfigureEnvs();
// Services
builder.Services.AddContext();
builder.Services.AddRedisCaching();
builder.Services.AddEndpoints();
builder.Services.AddHandlers();
builder.Services.AddHandlers();
builder.Services.AddUnitOfWord();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Migration
    using var scopeContext = app.Services.CreateScope().ServiceProvider.GetService<TropContext>()!;
    scopeContext.Database.Migrate();
    app.MapOpenApi();
    app.MapScalarApiReference(options => options.WithTheme(ScalarTheme.Moon)
                .WithTitle("Trop")
                .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient));
}
app.UseHttpsRedirection();
app.MapEndpoints();
app.MapGet("/", () => "Hola");

app.Run();