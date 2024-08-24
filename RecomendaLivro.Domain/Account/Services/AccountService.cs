using RecomendaLivro.Domain.Account.Interfaces;

namespace RecomendaLivro.Domain.Account.Services
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
