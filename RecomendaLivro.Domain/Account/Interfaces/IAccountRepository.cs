using RecomendaLivro.Domain.Account.Models;

namespace RecomendaLivro.Domain.Account.Interfaces
{
    public interface IAccountRepository
    {
        public Task SaveAsync(Models.Account account);
        public Task GetAsync(Models.Account account);
    }
}
