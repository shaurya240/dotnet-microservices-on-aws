using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum ResponseStatus
    {
        OK,
        ERROR,
        VALIDATION
    }

    public class ResponseError
    {
        public string ErrorMessage { get; set; }
    }

    public class ResponseMeta
    {
    }

    public class Response<T>
    {
        public ResponseStatus Status { get; set; }
        public T Data { get; set; }
        public ResponseError Error { get; set; }
        public ResponseMeta Meta { get; set; }


        public static Response<T> Ok(T data, ResponseMeta meta = null)
        {
            return new Response<T>
            {
                Status = ResponseStatus.OK,
                Data = data,
                Meta = meta ?? new ResponseMeta(),
            };
        }

        public static Response<T> OfError(ResponseStatus status, T data, ResponseMeta meta = null,
            string errorMessage = "unknown error")
        {
            return new Response<T>
            {
                Status = status,
                Data = data,
                Meta = meta ?? new ResponseMeta(),
                Error = new ResponseError {ErrorMessage = errorMessage}
            };
        }
    }
}