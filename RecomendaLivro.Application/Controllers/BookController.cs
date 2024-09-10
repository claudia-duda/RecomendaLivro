using Microsoft.AspNetCore.Mvc;
using RecomendaLivro.Domain.Book.Models;
using RecomendaLivro.Presentation.Application.Controllers.Request;
using RecomendaLivro.Presentation.Application.Controllers.Response;
using RecomendaLivro.Shared.Data;
using RecomendaLivro.Shared.Data.DataBase;
using System.Security.Claims;

namespace RecomendaLivro.Presentation.Application.Controllers
{
    public static class BookController
    {

        public static void AddEndPointsBooks(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("Book")
                .RequireAuthorization()
                .WithTags("Book");

            #region Endpoint Books

            groupBuilder.MapGet("PersonalReadedBook", (
                HttpContext context,
                [FromServices] DAL<Book> dal,
                [FromServices] DAL<UserAuthorized> dalUser) =>
            {
                var email = context.User.Claims
                   .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? throw new InvalidOperationException("Usuário não logado");

                var user = dalUser.RecoverBy(u => u.Email.Equals(email)) ?? throw new InvalidOperationException("Usuário não logado");

                var listaDeBooks = dal.List();

                if (listaDeBooks is null)
                {
                    return Results.NotFound();
                }
                var booklist = EntityListToResponseList(listaDeBooks, user.Id);
                return Results.Ok(booklist);

            }).RequireAuthorization();

            groupBuilder.MapGet("{name}", ([FromServices] DAL<Book> dal, string name) =>
            {
                var Book = dal.RecoverBy(a => a.Name.ToUpper().Equals(name.ToUpper()));
                if (Book is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(EntityToResponse(Book));

            }).RequireAuthorization();

            groupBuilder.MapPost("", async (
                HttpContext context, 
                [FromServices] IHostEnvironment env, 
                [FromServices] DAL<Book> dal,
                [FromServices] DAL < UserAuthorized > dalUser,
                [FromBody] BookRequest BookRequest) =>
            {
                var email = context.User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? throw new InvalidOperationException("Usuário não logado");

                var user = dalUser.RecoverBy(u => u.Email.Equals(email)) ?? throw new InvalidOperationException("Usuário não logado");

                var nome = BookRequest.nome.Trim();

                var Book = new Book(BookRequest.nome, BookRequest.imageUrl, user.Id);
                
                dal.Add(Book);
                return Results.Created();
            }).RequireAuthorization();

            groupBuilder.MapDelete("{id}", (HttpContext context, [FromServices] DAL<UserAuthorized> dalUser, [FromServices] DAL<Book> dal, string id) =>
            {
                var email = context.User.Claims
                   .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? throw new InvalidOperationException("Usuário não logado");

                var user = dalUser.RecoverBy(u => u.Email.Equals(email)) ?? throw new InvalidOperationException("Usuário não logado");

                var Book = dal.RecoverBy(a => a.BookIdentification == id && a.UserId == user.Id);

                if (Book is null)
                {
                    return Results.NotFound();
                }
                dal.Delete(Book);
                return Results.NoContent();

            }).RequireAuthorization();

            groupBuilder.MapPut("", ([FromServices] DAL<Book> dal, [FromBody] BookRequestEdit BookRequestEdit) =>
            {
                var updateBook = dal.RecoverBy(a => a.BookIdentification == BookRequestEdit.Id);
                if (updateBook is null)
                {
                    return Results.NotFound();
                }

                updateBook.Name = BookRequestEdit.name;
                dal.Update(updateBook);

                return Results.Ok();
            }).RequireAuthorization();
            #endregion
        }

        private static ICollection<BookResponse> EntityListToResponseList(IEnumerable<Book> BookList, int userId)
        {
            return BookList.Where(b => b.UserId == userId).Select(EntityToResponse).ToList();
        }

        private static BookResponse EntityToResponse(Book Book)
        {
            return new BookResponse(Book.BookIdentification, Book.Name, Book.ImageUrl);
        }


    }
}
