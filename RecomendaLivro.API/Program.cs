using RecomendaLivro.Domain.Account;
using RecomendaLivro.Domain.Account.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
