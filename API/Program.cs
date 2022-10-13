using Application;
using Application.Configuration;
using Domain.Entities.Models.DTO;
using Domain.Services;
using Infra.Database;
using Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ApplicationModuleDepedency.AddApplicationModule(builder.Services);
DataBaseModuleDependency.AddDataBaseModule(builder.Services);
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));


builder.Services.AddDbContext<TodosContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/todos", async (ITodosService _service) =>
{
    var result = await _service.GetAll();

    return result.Success ? Results.Ok(result) : Results.NotFound();

}).WithTags("Todos");

app.MapPost("/todos", async (TodosDTO todo, ITodosService _service) =>
{
    var result = await _service.Add(todo);

    return result.Success ? Results.Ok(result) : Results.BadRequest(result);

}).WithTags("Todos");

app.MapPut("/todos/closedtodo", async(TodosDTO todo, ITodosService _service) =>
{
    var result = await _service.Update(todo);

    return result.Success ? Results.Ok(result) : Results.BadRequest(result);
}).WithTags("Todos");

app.MapDelete("todos/{id:int}", async (int id, ITodosService _service) =>
{
    var result = await _service.Remove(id);

    return result.Success ? Results.Ok(result) : Results.NotFound(result);
}).WithTags("Todos");


app.Run();

