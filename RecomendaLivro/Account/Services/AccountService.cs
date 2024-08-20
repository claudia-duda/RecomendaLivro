using RecomendaLivro.Domain.Account.Interfaces;
using RecomendaLivro.Shared.Data.Repository;

namespace RecomendaLivro.Domain.Account
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
             _accountRepository = accountRepository;
        }

    }
}
