using Microsoft.AspNetCore.Mvc;
using RecomendaLivro.Domain.Book.Models;
using RecomendaLivro.Presentation.Application.Controllers.Request;
using RecomendaLivro.Presentation.Application.Controllers.Response;
using RecomendaLivro.Shared.Data.DataBase;

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
            groupBuilder.MapGet("", ([FromServices] DAL<Book> dal) =>
            {
                var listaDeBooks = dal.List();
                if (listaDeBooks is null)
                {
                    return Results.NotFound();
                }
                var booklist = EntityListToResponseList(listaDeBooks);
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

            groupBuilder.MapPost("", async ([FromServices] IHostEnvironment env, [FromServices] DAL<Book> dal, [FromBody] BookRequest BookRequest) =>
            {

                var nome = BookRequest.nome.Trim();
                var Book = new Book(BookRequest.nome, BookRequest.imageUrl);
                
                dal.Add(Book);
                return Results.Ok();
            }).RequireAuthorization();

            groupBuilder.MapDelete("{id}", ([FromServices] DAL<Book> dal, string id) =>
            {
                var Book = dal.RecoverBy(a => a.BookIdentification == id);
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

        private static ICollection<BookResponse> EntityListToResponseList(IEnumerable<Book> BookList)
        {
            return BookList.Select(a => EntityToResponse(a)).ToList();
        }

        private static BookResponse EntityToResponse(Book Book)
        {
            return new BookResponse(Book.BookIdentification, Book.Name, Book.ImageUrl);
        }


    }
}
