using System;
namespace ddd_template.Domain.Exceptions
{
    public abstract class BaseException : Exception
    {
        public ErrorCode ErrorCode { get; private set; }

        public BaseException(ErrorCode error, string message = null, Exception e = null) : base(message, e)
        {
            ErrorCode = error;
        }
    }
}
