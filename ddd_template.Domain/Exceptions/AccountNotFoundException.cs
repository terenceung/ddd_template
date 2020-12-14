using System;
namespace ddd_template.Domain.Exceptions
{
    public class AccountNotFoundException : BaseException
    {
        public AccountNotFoundException(string message = null) : base(ErrorCode.AccountNotFound, message)
        {
        }
    }
}
