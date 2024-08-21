using System.ComponentModel.DataAnnotations;

namespace RecomendaLivro.Presentation.Application.Controllers.Request;
public record AccountRequest([Required] string nome, [Required] string bio, string? fotoPerfil);

