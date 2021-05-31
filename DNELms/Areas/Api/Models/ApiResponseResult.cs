using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DNELms.Areas.Api.Models
{
    public record ApiResponseResult
    {
        public ApiResponseResult(dynamic data)
        {
            Data = data;
            StatusCode = 200;
            Detail = "Processed Successfully";
            Success = true;
            Faulted = false;
        }
        public ApiResponseResult(dynamic data, string message)
        {
            Data = data;
            StatusCode = 200;
            Detail = message;
            Success = true;
            Faulted = false;
        }
        public ApiResponseResult(dynamic data, bool isSuccess)
        {
            Data = data;
            StatusCode = 200;
            Detail = "Processed Successfully";
            Success = isSuccess;
            Faulted = !isSuccess;
        }
        public ApiResponseResult(dynamic data, int statusCode)
        {
            Data = data;
            StatusCode = statusCode;
            Detail = GetMessage(statusCode);
            Success = statusCode is 200 or 201;
            Faulted = statusCode is not 200 and 201;
        }
        public ApiResponseResult(dynamic data, int statusCode, string detail)
        {
            Data = data;
            StatusCode = statusCode;
            Detail = detail ?? GetMessage(statusCode);
            Success = statusCode is 200 or 201;
            Faulted = statusCode is not 200 and 201;
        }
        public dynamic Data { get; set; }
        public int StatusCode { get; set; }
        public string Detail { get; set; }
        public bool Success { get; set; }
        public bool Faulted { get; set; }
        private static string GetMessage(int statusCode)
        {
            return statusCode switch
            {
                StatusCodes.Status200OK or StatusCodes.Status201Created => "Processed or Created SuccessFully",
                StatusCodes.Status400BadRequest => "Bad Request Detected",
                StatusCodes.Status401Unauthorized => "Request Unauthorized please login",
                StatusCodes.Status403Forbidden => "Path Forbidden",
                StatusCodes.Status404NotFound => "Entity Not found",
                StatusCodes.Status500InternalServerError => "Internal server error occured",
                _ => "Success"
            };
        }
    }
}
