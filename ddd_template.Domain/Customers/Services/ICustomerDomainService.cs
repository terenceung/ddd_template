using System;
using ddd_template.Domain.Customers;

namespace ddd_template.Domain.Customers.Services
{
    public interface ICustomerDomainService
    {
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Customer GetCustomerById(long id);

    }
}
