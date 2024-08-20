using RecomendaLivroApi.Domain.Interface;

namespace RecomendaLivro.Shared.Data.Repository
{
    public interface IAccountRepository
    {
        public Task SaveAsync(Account account);
        public Task GetAsync(Account account);
    }
}
