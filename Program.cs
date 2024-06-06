using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TokioMarineApiExample.Models;
using Swashbuckle.AspNetCore.Filters;
using TokioMarinApiExample.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson();

// Add services to the container.
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tokio marine api example", Version = "v1" });
    c.ExampleFilters();
});
builder.Services.Configure<MetaData>(builder.Configuration.GetSection("MetaData"));

builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>(); // Add this line to include examples from the current assembly

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tokio marine api example v1");
    });
}

app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
