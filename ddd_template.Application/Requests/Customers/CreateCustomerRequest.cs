using System;
namespace ddd_template.Application.Requests.Customers
{
    /// <summary>
    /// this object will be map by json
    /// therefore, tend to be camel case naming convention
    /// </summary>
    public class CreateCustomerRequest
    {
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
