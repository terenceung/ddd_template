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

        public static bool operator == (Address a, Address b)
        {
            if(a == null || b == null)
            {
                return false;
            }

            if(a.City == b.City
                && a.Street == b.Street
                && a.Building == b.Building)
            {
                return true;
            }

            return false;
        }

        public static bool operator != (Address a, Address b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return obj is Address address &&
                   City == address.City &&
                   Street == address.Street &&
                   Building == address.Building;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(City, Street, Building);
        }
    }
}
