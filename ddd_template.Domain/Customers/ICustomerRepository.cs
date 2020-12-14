using System;
namespace ddd_template.Domain.Customers
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(long id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
    }
}
