using Microsoft.AspNetCore.Mvc;
using RecomendaLivro.Domain.Account.Models;
using RecomendaLivro.Presentation.Application.Controllers.Request;
using RecomendaLivro.Presentation.Application.Controllers.Response;
using RecomendaLivro.Shared.Data.DataBase;

namespace RecomendaLivro.Presentation.Application.Controllers
{
    public static class ArtistasExtensions
    {
        public static void AddEndPointsAccounts(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("Accounts")
                .RequireAuthorization()
                .WithTags("Accounts");

            #region Endpoint Accounts
            groupBuilder.MapGet("", ([FromServices] DAL<AccountModel> dal) =>
            {
                var listaDeAccounts = dal.Listar();
                if (listaDeAccounts is null)
                {
                    return Results.NotFound();
                }
                var listaDeAccountResponse = EntityListToResponseList(listaDeAccounts);
                return Results.Ok(listaDeAccountResponse);
            }).RequireAuthorization();

            groupBuilder.MapGet("{nome}", ([FromServices] DAL<AccountModel> dal, string nome) =>
            {
                var Account = dal.RecoverBy(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (Account is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(EntityToResponse(Account));

            });

            groupBuilder.MapPost("", async ([FromServices] IHostEnvironment env, [FromServices] DAL<AccountModel> dal, [FromBody] AccountRequest AccountRequest) =>
            {

                var nome = AccountRequest.nome.Trim();
                var imagemAccount = DateTime.Now.ToString("ddMMyyyyhhss") + "." + nome + ".jpg";

                var path = Path.Combine(env.ContentRootPath,
                    "wwwroot", "FotosPerfil", imagemAccount);

                using MemoryStream ms = new MemoryStream(Convert.FromBase64String(AccountRequest.fotoPerfil!));
                using FileStream fs = new(path, FileMode.Create);
                await ms.CopyToAsync(fs);

                var Account = new AccountModel(AccountRequest.nome, AccountRequest.bio) { FotoPerfil = $"/FotosPerfil/{imagemAccount}" };

                dal.Add(Account);
                return Results.Ok();
            });

            groupBuilder.MapDelete("{id}", ([FromServices] DAL<AccountModel> dal, int id) =>
            {
                var Account = dal.RecoverBy(a => a.Id == id);
                if (Account is null)
                {
                    return Results.NotFound();
                }
                dal.Delete(Account);
                return Results.NoContent();

            });

            groupBuilder.MapPut("", ([FromServices] DAL<AccountModel> dal, [FromBody] AccountRequestEdit AccountRequestEdit) =>
            {
                var AccountAAtualizar = dal.RecoverBy(a => a.Id == AccountRequestEdit.Id);
                if (AccountAAtualizar is null)
                {
                    return Results.NotFound();
                }
                AccountAAtualizar.Nome = AccountRequestEdit.nome;
                AccountAAtualizar.Bio = AccountRequestEdit.bio;
                dal.Update(AccountAAtualizar);
                return Results.Ok();
            });
            #endregion
        }

        private static ICollection<AccountResponse> EntityListToResponseList(IEnumerable<AccountModel> listaDeAccounts)
        {
            return listaDeAccounts.Select(a => EntityToResponse(a)).ToList();
        }

        private static AccountResponse EntityToResponse(AccountModel Account)
        {
            return new AccountResponse(Account.Id, Account.Nome, Account.Bio, Account.FotoPerfil);
        }


    }
}
