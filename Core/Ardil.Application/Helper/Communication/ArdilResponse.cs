using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Application.Helper.Communication
{
    public class ArdilResponse<T>
    {
        public ArdilResponse()
        {
            Success = true;
            Error = null;
        }
        public ArdilResponse(T? data, bool success, Error? error)
        {
            Data = data;
            Success = success;
            Error = error;
        }
        public T? Data { get; set; }
        public bool Success { get; set; }
        public Error? Error { get; set; }
    }

    public class Error
    {
        public int? Code { get; set; }
        public string? Message { get; set; }
    }
}
