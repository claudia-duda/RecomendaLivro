namespace RecomendaLivro.Presentation.Application.Controllers.Request;

public record BookRequestEdit(string Id, string name, string? imageUrl)
    : BookRequest(name, imageUrl);