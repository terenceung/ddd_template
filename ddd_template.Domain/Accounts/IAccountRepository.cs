using System;
using System.Collections.Generic;
using ddd_template.Domain.Customers;

namespace ddd_template.Domain.Accounts.Repositories
{
    public interface IAccountRepository
    {
        void UpdateAccount(Account account);
        Account GetAccountById(long id);
        IList<Account> GetAccountsByCustomer(Customer customer);
    }
}
