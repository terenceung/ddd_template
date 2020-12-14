using System;
namespace ddd_template.Application.Responses.Customers
{
    public class CustomerCheckSameAddressResponse
    {
        public bool isSame { get; set; }
        public string customerACity { get; set; }
        public string customerAStreet { get; set; }
        public string customerABuilding { get; set; }
        public string customerBCity { get; set; }
        public string customerBStreet { get; set; }
        public string customerBBuilding { get; set; }
    }
}
