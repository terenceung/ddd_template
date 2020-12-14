using System;
namespace ddd_template.API.Requests.Accounts
{
    public class AccountTransferRequest
    {
        public long fromAccountId { get; set; }
        public decimal amount { get; set; }
        public long toAccountId { get; set; }
    }
}
