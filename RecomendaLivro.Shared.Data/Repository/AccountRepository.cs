using RecomendaLivro.Domain.Account.Interfaces;
using RecomendaLivro.Domain.Account.Models;

namespace RecomendaLivro.Shared.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly string _collection; // TODO: insert  database

        public Task GetAsync(AccountModel account)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(AccountModel account)
        {
            throw new NotImplementedException();
        }
    }
}
