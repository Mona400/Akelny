using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int _statusCode, string? _message = null)
        {
            StatusCode = _statusCode;
            Message = _message ?? GetDefaultMessageForStatusCode(_statusCode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request ,you have made",
                401 => "Authorized you are not",
                404 => "Response found it is not",
                500 => "Server error occured",
                _ => "No Such Code Please Try Again",
            };
        }
    }
}
