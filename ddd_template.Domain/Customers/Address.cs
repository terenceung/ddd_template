using System;
namespace ddd_template.Domain.Customers
{
    /// <summary>
    /// this is a value object
    /// the lifetime of this object is depends on corresponding entities
    /// it is immutable
    /// to change it just declare a brand new object
    /// </summary>
    public class Address
    {
        public string City { get; private set; }
        public string Street { get; private set; }
        public string Building { get; private set; }

        public Address(string city, string street, string building)
        {
            City = city;
            Street = street;
            Building = building;
        }
    }
}
