namespace RecomendaLivro.Domain.Account.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Book { get; set; }

        public Account()
        {
        }
        public Account(string nome, string book)
        {
            Nome = nome;
            Book = book;
        }

        public override string ToString()
        {
            return $@"Id: {Id}
            Nome: {Nome}
            Books: {Book}";
        }
    }
}
