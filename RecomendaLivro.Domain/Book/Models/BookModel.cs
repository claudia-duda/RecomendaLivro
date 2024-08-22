namespace RecomendaLivro.Domain.Book.Models
{
    public record BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public BookModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
