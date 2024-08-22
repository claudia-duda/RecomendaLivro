using RecomendaLivro.Domain.Book.Models;

namespace RecomendaLivro.Domain.Account.Models
{
    public class AccountModel
    {
        public virtual ICollection<BookModel> Book { get; set; } = new List<BookModel>();
        public AccountModel()
        {
            //FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
        }
        public AccountModel(string nome, string bio)
        {
            Nome = nome;
            Bio = bio;
            //FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
        }

        public string Nome { get; set; }
        public string FotoPerfil { get; set; } = string.Empty;
        public string Bio { get; set; }
        public int Id { get; set; }

        public void AddBook(BookModel musica)
        {
            Book.Add(musica);
        }


        public override string ToString()
        {
            return $@"Id: {Id}
            Nome: {Nome}
            Foto de Perfil: {FotoPerfil}
            Bio: {Bio}";
        }
    }
}
