using Microsoft.AspNetCore.Mvc;
using RecomendaLivro.Domain.Book.Models;
using RecomendaLivro.Presentation.Application.Controllers.Request;
using RecomendaLivro.Presentation.Application.Controllers.Response;
using RecomendaLivro.Shared.Data.DataBase;

namespace RecomendaLivro.Presentation.Application.Controllers
{
    public static class BookRecomendationController
    {

        public static void AddEndPointsBookRecomendation(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("BookRecomendation")
                .RequireAuthorization()
                .WithTags("BookRecomendation");

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
