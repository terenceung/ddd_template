using System;
using System.Collections.Generic;
using System.Linq;
using ddd_template.Domain.Accounts;
using ddd_template.Domain.Accounts.Repositories;
using ddd_template.Domain.Customers;

namespace ddd_template.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private IList<Account> accounts { get; set; }

        public AccountRepository()
        {
            accounts = new List<Account>();

            var c1 = new Customer.Builder()
                .SetId(1)
                .SetLogin("terence", "123")
                .SetName("Terence", "Ung")
                .Locate(new Address("Macau", "macau", "macau"))
                .Build();

            var c2 = new Customer.Builder()
                .SetId(1)
                .SetLogin("terence", "123")
                .SetName("Terence", "Ung")
                .Locate(new Address("Macau", "macau", "macau"))
                .Build();

            accounts.Add(new Account(1, c1, 100));
            accounts.Add(new Account(2, c2, 50));
        }

        public void UpdateAccount(Account newAccount)
        {
            var account = accounts.Where(x => x.Id == newAccount.Id).FirstOrDefault();
            account = newAccount;
        }

        public Account GetAccountById(long id)
        {
            return accounts.Where(x => x.Id == id).FirstOrDefault();
        }

        public IList<Account> GetAccountsByCustomer(Customer customer)
        {
            return accounts.Where(x => x.Customer.Id == customer.Id).ToList();
        }
    }
}
