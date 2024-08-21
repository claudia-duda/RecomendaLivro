using RecomendaLivro.Domain.Account.Models;

namespace RecomendaLivro.Domain.Account.Interfaces
{
    public interface IAccountRepository
    {
        public Task SaveAsync(AccountModel account);
        public Task GetAsync(AccountModel account);
    }
}
