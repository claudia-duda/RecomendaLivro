namespace RecomendaLivroApi.Domain.Interface
{
    public record Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image {  get; set; }

        public Book(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
