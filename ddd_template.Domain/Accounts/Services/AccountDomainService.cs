using System;
using ddd_template.Domain.Accounts.Repositories;
using ddd_template.Domain.Customers.Services;

namespace ddd_template.Domain.Accounts.Services
{
    public class AccountDomainService : IAccountDomainService
    {
        private IAccountRepository accountRepository { get; set; }

        public AccountDomainService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public Account GetAccountById(long id)
        {
            return accountRepository.GetAccountById(id);
        }

        public void Save(Account account, decimal amount)
        {
            account.Save(amount);
            accountRepository.UpdateAccount(account);
        }

        public void TransferTo(Account source, Account target, decimal amount)
        {
            if (amount > source.Amount)
            {
                throw new InvalidOperationException("insufficient amount");
            }

            source.Withdraw(amount);
            target.Save(amount);
            accountRepository.UpdateAccount(source);
            accountRepository.UpdateAccount(target);
        }

        public void Withdraw(Account account, decimal amount)
        {
            if(amount > account.Amount)
            {
                throw new InvalidOperationException("insufficient amount");
            }

            account.Withdraw(amount);
            accountRepository.UpdateAccount(account);
        }
    }
}
