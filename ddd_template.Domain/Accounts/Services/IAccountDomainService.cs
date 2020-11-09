using System;
namespace ddd_template.Domain.Accounts.Services
{
    public interface IAccountDomainService
    {
        Account GetAccountById(long id);
        void Save(Account account, decimal amount);
        void Withdraw(Account account, decimal amount);
        void TransferTo(Account source, Account target, decimal amount);
    }
}
