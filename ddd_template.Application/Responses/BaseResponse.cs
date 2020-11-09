using System;
using ddd_template.Domain.Exceptions;

namespace ddd_template.Application.Responses
{
    public class BaseResponse<T>
    {
        public bool isSuccess { get; private set; }
        public string errorCode { get; private set; }
        public string errorMessage { get; private set; }
        public T data { get; private set; }

        public BaseResponse()
        {
            isSuccess = false;
            errorCode = null;
            errorMessage = null;
            data = default;
        }

        public void SetData(T data)
        {
            isSuccess = true;
            errorCode = null;
            errorMessage = null;
            this.data = data;
        }

        public void SetError(Exception e)
        {
            isSuccess = false;
            data = default;
            errorMessage = e.Message;

            if(e is BaseException)
            {
                errorCode = ((BaseException)e).ErrorCode.ToErrorCode();
                
            }
        }
    }
}
