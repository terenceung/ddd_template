using System;

namespace ddd_template.Domain.Customers
{
    public interface ICustomerDomainService
    {
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Customer GetCustomerById(long id);

    }
}
