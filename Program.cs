using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TokioMarinApiExample.Models;
using Swashbuckle.AspNetCore.Filters;

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
    c.DocInclusionPredicate((_, apiDesc) =>
    {
        // Prepend /api/v1 to each path
        apiDesc.RelativePath = "/api/v1/" + apiDesc.RelativePath;
        return true;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

var apiV1Group = app.MapGroup("/api/v1");

apiV1Group.MapControllers();

app.Run();
