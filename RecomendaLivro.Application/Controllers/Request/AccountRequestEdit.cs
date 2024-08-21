namespace RecomendaLivro.Presentation.Application.Controllers.Request;

public record AccountRequestEdit(int Id, string nome, string bio, string? fotoPerfil)
    : AccountRequest(nome, bio, fotoPerfil);