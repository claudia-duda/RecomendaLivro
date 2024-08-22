namespace RecomendaLivro.Presentation.Application.Controllers.Request;

public record AccountRequestEdit(int Id, string nome, string? book)
    : AccountRequest(nome, book);