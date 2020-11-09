using System;
namespace ddd_template.Application.Responses.Accounts
{
    public class TransferAccountResponse
    {
        public long id { get; set; }
        public decimal sourceAmount { get; set; }

        public TransferAccountResponse()
        {
        }
    }
}
