using System;
using ddd_template.Domain.Customers.Repositories;

namespace ddd_template.Domain.Customers.Services
{
    public class CustomerDomainService : ICustomerDomainService
    {
        private ICustomerRepository _customerRepository;

        public CustomerDomainService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void CreateCustomer(Customer customer)
        {
            _customerRepository.CreateCustomer(customer);
        }

        public Customer GetCustomerById(long id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }
    }
}
