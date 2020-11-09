using System;
using ddd_template.Domain.Customers;

namespace ddd_template.Domain.Accounts
{
    public class Account
    {
        public long Id { get; private set; }
        public Customer Customer { get; private set; }
        public decimal Amount { get; private set; }


        public Account(long id, Customer customer, decimal amount)
        {
            Id = id;
            Customer = customer;
            Amount = amount;
        }

        public void Save(decimal amount)
        {
            Amount += amount;
        }

        public void Withdraw(decimal amount)
        {
            Amount -= amount;
        }
    }
}
