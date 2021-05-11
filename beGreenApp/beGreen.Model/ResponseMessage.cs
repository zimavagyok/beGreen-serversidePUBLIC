using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beGreen.Model
{
    public class ResponseMessage
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public ResponseMessage()
        { }

        public ResponseMessage(bool isSuccess, string errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }
    }

    public class ResponseMessage<T> : ResponseMessage where T : new()
    {
        public T ResponseObject = new T();

        public object ResultObject { get; set; }

        public ResponseMessage()
        { }

        public ResponseMessage(bool isSuccess, string errorMessage, T responseObject) : base(isSuccess, errorMessage)
        {
            ResponseObject = responseObject == null ? new T() : responseObject;
        }

        public ResponseMessage(ResponseMessage responseMessage, T responseObject)
        {
            if (responseMessage != null)
            {
                IsSuccess = responseMessage.IsSuccess;
                ErrorMessage = responseMessage.ErrorMessage;
            }

            ResponseObject = responseObject == null ? new T() : responseObject;
        }
    }

}
