using System;
namespace ddd_template.Application.Requests.Accounts
{
    public class TransferAccountRequest
    {
        public long sourceId { get; set; }
        public long targetId { get; set; }
        public decimal amount { get; set; }

        public TransferAccountRequest()
        {
        }
    }
}
