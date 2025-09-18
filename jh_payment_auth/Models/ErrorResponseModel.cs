using Microsoft.AspNetCore.Http;
using System.Net;

namespace jh_payment_auth.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorResponseModel : ResponseModel
    {
        /// <summary>
        /// Response status code indicating the result of the API request.
        /// </summary>
        public string ErrorCode { set; get; }

        /// <summary>
        /// Response message providing additional information about the response.
        /// </summary>
        public string ErrorMessage { set; get; }

        /// <summary>
        /// This method creates a response model for bad requests with status code 400 (Bad Request).
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ErrorResponseModel BadRequest(string message, string errorCode)
        {
            return new ErrorResponseModel
            {
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessage = message ?? "Bad Request",
                ErrorCode = errorCode ?? StatusCodes.Status400BadRequest.ToString(),
            };
        }

        /// <summary>
        /// This method creates an internal server error response model with status code 500 (Internal Server Error).
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ErrorResponseModel InternalServerError(string message, string errorCode)
        {
            return new ErrorResponseModel
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ErrorMessage = message ?? "Internal Server Error",
                ErrorCode = errorCode ?? StatusCodes.Status500InternalServerError.ToString(),
            };
        }
    }
}
