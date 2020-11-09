using System;
namespace ddd_template.Domain.Exceptions
{
    public class BaseException : Exception
    {
        public ErrorCode ErrorCode { get; private set; }

        public BaseException(ErrorCode error, string message = null) : base(message)
        {
            this.ErrorCode = error;
        }
    }
}
