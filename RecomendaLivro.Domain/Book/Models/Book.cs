namespace RecomendaLivro.Domain.Book.Models
{
    public class Book
    {
        public int Id { get; init; }
        public string BookIdentification { get; init; }
        public string Name { get; set; }
        public string ImageUrl { get; private set; } = "";

        public Book(string name)
        {
            Name = name;
            BookIdentification = new Guid().ToString();
        }
        public Book(string name, string url)
        {
            Name = name;
            ImageUrl = url;
            BookIdentification = new Guid().ToString();
        }
        public void setImageUrl(string imageUrl)
        {
            ImageUrl = imageUrl;
        }

    }
}
