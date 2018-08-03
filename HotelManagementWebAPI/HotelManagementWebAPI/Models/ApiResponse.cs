using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagementWebAPI.Models
{
    public class ApiResponse
    {
        public string ApiStatus { get; set; }
        public StatusCodeNumber StatusCode { get; set; }
        public string Message { get; set; }
    }
    public enum ApiStatus
    {
        Success,
        Failure,
        Warning,
        NotFound,
        InternalServerError,
    }
    public enum StatusCodeNumber
    {
        Success = 200,
        NotFound = 404,
        InternalServerError = 500,
    }
}