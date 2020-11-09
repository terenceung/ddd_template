using System;
namespace ddd_template.Application.Responses.Customers
{
    public class UpdateCustomerResponse
    {
        public long id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string building { get; set; }
    }
}
