using System;
namespace ddd_template.Application.Responses.Accounts
{
    public class AccountResponse
    {
        public long id { get; set; }
        public string customerUsername { get; set; }
        public decimal amount { get; set; }

        public AccountResponse()
        {
        }
    }
}
