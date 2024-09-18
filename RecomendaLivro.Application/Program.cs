using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecomendaLivro.Domain.Book.Models;
using RecomendaLivro.Presentation.Application.Controllers;
using RecomendaLivro.Shared.Data;
using RecomendaLivro.Shared.Data.DataBase;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentityApiEndpoints<UserAuthorized>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthorization();

builder.Services.AddTransient<DAL<Book>>();
builder.Services.AddTransient<DAL<UserAuthorized>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "wasm",
        builder =>
        {
            builder
              .AllowAnyMethod()
              .AllowAnyOrigin()
              .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors("wasm");

app.UseStaticFiles();
app.UseAuthorization();

app.AddEndPointsBooks();
app.AddEndPointsBookRecomendation();

app.MapGroup("auth").MapIdentityApi<UserAuthorized>().WithTags("Authorized");

app.MapPost("auth/logout", async ([FromServices] SignInManager<UserAuthorized> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Ok();
}).RequireAuthorization().WithTags("Authorized");

app.UseSwagger();
app.UseSwaggerUI();

app.Run();