using jh_payment_auth.Constants;
using jh_payment_auth.DTOs;
using Microsoft.IdentityModel.Tokens.Experimental;
using System.Collections.Generic;

namespace jh_payment_auth.Helpers
{
    /// <summary>
    /// This class provides methods to handle errors and populate an ApiResponse object with error details.
    /// </summary>
    public class ErrorHandler
    {
        /// <summary>
        /// Method to handle a single error and populate the ApiResponse object.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        /// <param name="error"></param>
        /// <param name="apiResponse"></param>
        public static void HandleError(string message, int statusCode, string error, ref ApiResponse apiResponse)
        {
            if (apiResponse.Errors == null)
                apiResponse.Errors = new List<string>();

            apiResponse.Errors.Add(error);

            apiResponse.StatusCode = statusCode;

            if (!string.IsNullOrEmpty(message))
                apiResponse.Message = message;
        }

        /// <summary>
        /// Method to handle multiple errors and populate the ApiResponse object.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        /// <param name="errors"></param>
        /// <param name="apiResponse"></param>
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
