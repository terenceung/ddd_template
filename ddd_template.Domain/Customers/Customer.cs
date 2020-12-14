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
        private string Password { get; set; }
        public string Firstname { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public Address Address { get; private set; }

        public Customer() { }

        // for simplicity I use normal constructor to control the creation of customer object
        // if many parameters are required to create an object, consider using factory/builder pattern
        public Customer(long id, string username, string password, string firstname, string surname, string email, Address address)
        {
            Id = id;
            Username = username;
            Password = password;
            Firstname = firstname;
            Surname = surname;
            Email = email;
            Address = address;
        }

        public Customer(string username, string password, string firstname, string surname, string email, Address address)
            : this(0, username, password, firstname, surname, email, address)
        {
        }

        public void MoveTo(Address address)
        {
            Address = address;
        }

        public override bool Equals(object obj)
        {
            return obj is Customer customer &&
                   Id == customer.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public static bool operator == (Customer a, Customer b)
        {
            if(a == null || b == null)
            {
                return false;
            }

            return a.Id == b.Id;
        }

        public static bool operator != (Customer a, Customer b)
        {
            return !(a == b);
        }

        //this method does not require other aggregate root, therefore it is not belong to domain service
        public bool IsLiveTogether(Customer customer)
        {
            return Address == customer.Address;
        }
    }
}
