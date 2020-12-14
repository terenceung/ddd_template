using System;
namespace ddd_template.API.Responses
{
    public class BaseResponse<T>
    {
        public bool isSuccess { get; set; }
        public  string errorCode { get; set; }
        public string error { get; set; }
        public T data { get; set; }

        public BaseResponse()
        {
            this.data = default;
            isSuccess = false;
            errorCode = "unknown_error";
            error = "uninit";
        }

        public void SetData(T data)
        {
            this.data = data;
            isSuccess = true;
            error = null;
            errorCode = null;
        }

        public void SetError(Exception e)
        {
            data = default;
            isSuccess = false;
            error = e.Message;
            errorCode = "unknown_error";
        }
    }
}
