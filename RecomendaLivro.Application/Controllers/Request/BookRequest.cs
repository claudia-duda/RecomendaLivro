using System.ComponentModel.DataAnnotations;

namespace RecomendaLivro.Presentation.Application.Controllers.Request;
public record BookRequest([Required] string nome, string? imageUrl);

