using System;
namespace ddd_template.Domain.Exceptions
{
    public enum ErrorCode
    {
        CustomerNotFound,
        AccountNotFound
    }

    public static class ErrorCodeExtensions
    {
        public static string ToErrorCode(this ErrorCode error) =>
            error switch
            {
                ErrorCode.CustomerNotFound => "customer_not_found",
                ErrorCode.AccountNotFound => "account_not_found",
                _ => "unknown_error"
            };
    }
}
