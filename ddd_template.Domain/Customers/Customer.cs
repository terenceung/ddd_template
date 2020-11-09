using System;
namespace ddd_template.Domain.Customers
{
    /// <summary>
    /// this is a entity object
    /// </summary>
    public class Customer
    {
        public long Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Firstname { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public Address Address { get; private set; }

        private Customer() { }

        public void MoveTo(Address address)
        {
            Address = address;
        }

        /// <summary>
        /// for many variables/properties, can use builder patterns
        /// </summary>
        public class Builder
        {
            private Customer customer;

            public Builder() {
                customer = new Customer();
            }

            public Builder SetId(long id)
            {
                customer.Id = id;
                return this;
            }

            public Builder SetLogin(string username, string password)
            {
                customer.Username = username;
                customer.Password = password;
                return this;
            }

            public Builder SetName(string firstname, string surname)
            {
                customer.Firstname = firstname;
                customer.Surname = surname;
                return this;
            }

            public Builder Email(string email)
            {
                customer.Email = email;
                return this;
            }

            public Builder Locate(Address address)
            {
                customer.Address = address;
                return this;
            }

            public Customer Build()
            {
                return customer;
            }
        }
    }
}
