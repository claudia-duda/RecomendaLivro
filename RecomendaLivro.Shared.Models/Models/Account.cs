namespace RecomendaLivroApi.Domain.Interface
{
    public record Account
    {
        public string UserName { get; set; }
        public int Id { get; set; }

        public Account(string userName, int id)
        {
            UserName = userName;
            Id = id;
        }
    }
}
