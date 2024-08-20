namespace RecomendaLivroApi.Domain.Interface
{
    public record Account
    {
        public string UserName { get; set; }
        public int Id { get; set; }
        public List<Book> Books { get; set; }

        public Account(string userName, int id, List<Book> books)
        {
            UserName = userName;
            Id = id;
            Books = books;
        }
        public void AddBook(Book book)
        {
            Books.Add(book);
        }    
    }
}
