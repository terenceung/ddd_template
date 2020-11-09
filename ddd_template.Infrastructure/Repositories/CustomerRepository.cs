using System;
using System.Collections.Generic;
using System.Linq;
using ddd_template.Domain.Customers;
using ddd_template.Domain.Customers.Repositories;

namespace ddd_template.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private IList<Customer> customers;

        public CustomerRepository()
        {
            customers = new List<Customer>();


            customers.Add(new Customer.Builder()
                .SetId(1)
                .SetLogin("terence", "123")
                .SetName("Terence", "Ung")
                .Locate(new Address("Macau", "macau", "macau"))
                .Build());

            customers.Add(new Customer.Builder()
                .SetId(2)
                .SetLogin("mary", "123")
                .SetName("Mary", "BB")
                .Locate(new Address("zz", "zz", "zz"))
                .Build());
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
