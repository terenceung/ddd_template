using System;
using System.Collections.Generic;
using System.Linq;
using ddd_template.Domain.Customers;

namespace ddd_template.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private IList<Customer> customers;

        public CustomerRepository()
        {
            customers = new List<Customer>();

            customers.Add(new Customer(1, "terence", "123", "Terence", "Ung", "terenceung@test.com", new Address("a", "a", "a")));
            customers.Add(new Customer(2, "peter", "123", "Peter", "ABC", "peterabc@test.com", new Address("a", "a", "a")));
        }

        public void CreateCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public Customer GetCustomerById(long id)
        {
            return customers.Where(x => x.Id == id).FirstOrDefault();
        }

        public void UpdateCustomer(Customer customer)
        {
            var c = customers.Where(x => x.Id == customer.Id).FirstOrDefault();
            c = customer;
        }
    }
}
