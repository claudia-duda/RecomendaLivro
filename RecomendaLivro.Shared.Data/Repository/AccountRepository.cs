using RecomendaLivroApi.Domain.Interface;

namespace RecomendaLivro.Shared.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly string _collection; // TODO: insert  database

        public Task GetAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
