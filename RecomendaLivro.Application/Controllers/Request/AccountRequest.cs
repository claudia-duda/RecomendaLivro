using System.ComponentModel.DataAnnotations;

namespace RecomendaLivro.Presentation.Application.Controllers.Request;
public record AccountRequest([Required] string nome, string book);

