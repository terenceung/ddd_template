using System;
namespace ddd_template.API.Requests.Customers
{
    public class CustomerCheckSameAddressRequest
    {
        public long customerAId { get; set; }
        public long customerBId { get; set; }

        public void Validate()
        {
            if(customerAId <= 0)
            {
                throw new ArgumentNullException(nameof(customerAId));
            }

            if (customerBId <= 0)
            {
                throw new ArgumentNullException(nameof(customerBId));
            }
        }
    }
}
