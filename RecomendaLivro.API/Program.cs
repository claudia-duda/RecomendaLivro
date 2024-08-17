using RecomendaLivro.Shared.Data.DataBase;
using RecomendaLivroApi.Domain.Interface;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () =>
{
    var dal = new DAL<Account>(new DatabaseContext());
    return dal.List();
});

app.Run();

