using Microsoft.EntityFrameworkCore;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Context;
using Todo.Domain.Infra.Repositories;
using Todo.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

DependencieInjection(builder);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void DependencieInjection(WebApplicationBuilder builder)
{
    #region Databases

    builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("Database"));
    // builder.Services.AddDbContext<TodoContext>(opt => opt.UseSqlServer("ConnectionString"));

    #endregion

    #region Repositories

    builder.Services.AddTransient<ITodoRepository, TodoRepository>();

    #endregion


    #region Handlers

    builder.Services.AddTransient<TodoHandler>();

    #endregion

}