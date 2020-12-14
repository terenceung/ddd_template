using System;
namespace ddd_template.API.Responses.Accounts
{
    public class AccountTransferResponse
    {
        public decimal fromAccountAmount { get; set; }
        public decimal toAccountAmount { get; set; }
    }
}
