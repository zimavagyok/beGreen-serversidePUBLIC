using beGreen.Model.Enums;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beGreen.WebApplication.exceptionResponseMiddleware
{
    public class HttpStatusCodeException : Exception
    {
        public int StatusCode { get; set; }
        public string ContentType { get; set; } = @"text/plain";

        public HttpStatusCodeException(HttpResponseType statusCode)
        {
            this.StatusCode = (int)statusCode;
        }

        public HttpStatusCodeException(HttpResponseType statusCode, string message) : base(message)
        {
            this.StatusCode = (int)statusCode;
        }

        public HttpStatusCodeException(HttpResponseType statusCode, Exception inner) : this(statusCode, inner.ToString()) { }

        public HttpStatusCodeException(HttpResponseType statusCode, JObject errorObject) : this(statusCode, errorObject.ToString())
        {
            this.ContentType = @"application/json";
        }
    }
}
