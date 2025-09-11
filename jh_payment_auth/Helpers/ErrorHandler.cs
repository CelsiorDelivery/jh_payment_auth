using jh_payment_auth.Constants;
using jh_payment_auth.DTOs;
using Microsoft.IdentityModel.Tokens.Experimental;
using System.Collections.Generic;

namespace jh_payment_auth.Helpers
{
    public class ErrorHandler
    {
        public static void HandleError(string message, int statusCode, string error, ref ApiResponse apiResponse)
        {
            if (apiResponse.Errors == null)
                apiResponse.Errors = new List<string>();

            apiResponse.Errors.Add(error);

            apiResponse.StatusCode = statusCode;

            if (!string.IsNullOrEmpty(message))
                apiResponse.Message = message;
        }

        public static void HandleErrors(string message, int statusCode, List<string> errors, ref ApiResponse apiResponse)
        {
            if (apiResponse == null)
                apiResponse = new ApiResponse();

            if (apiResponse.Errors == null)
                apiResponse.Errors = new List<string>();

            apiResponse.Errors.AddRange(errors);

            apiResponse.StatusCode = statusCode;

            if (!string.IsNullOrEmpty(message))
                apiResponse.Message = message;
        }
    }
}
