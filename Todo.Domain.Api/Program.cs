using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Context;
using Todo.Domain.Infra.Repositories;
using Todo.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

DependencieInjection(builder);
FirebaseAuthentication(builder);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x =>
    x.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


void DependencieInjection(WebApplicationBuilder builder)
{
    #region Databases

    //builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("Database"));
    builder.Services.AddDbContext<TodoContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    #endregion

    #region Repositories

    builder.Services.AddTransient<ITodoRepository, TodoRepository>();

    #endregion


    #region Handlers

    builder.Services.AddTransient<TodoHandler>();

    #endregion
}

void FirebaseAuthentication(WebApplicationBuilder builder)
{
    builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.Authority = "https://securetoken.google.com/test-proj-5face";
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "https://securetoken.google.com/test-proj-5face",
                ValidateAudience = true,
                ValidAudience = "test-proj-5face",
                ValidateLifetime = true
            };
        });
}