using System;
namespace ddd_template.Domain.Exceptions
{
    public class CustomerNotFoundException : BaseException
    {
        public CustomerNotFoundException(string message = null) : base(ErrorCode.CustomerNotFound, message)
        {
        }
    }
}
