using Ardil.Application.Helper.Communication;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Application.Helper.BaseClasses
{
    public class BaseController 
    {
        public ArdilResponse<T> Success<T>(T data)
        {
            return new ArdilResponse<T>(data, true, null);
        }
        public ArdilResponse<T> Error<T>(int statusCode, string message)
        {
            return new ArdilResponse<T>(default, false, new Error() { Code = statusCode, Message = message });
        }
    }
}
