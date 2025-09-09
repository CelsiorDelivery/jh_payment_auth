using System.Net;

namespace jh_payment_auth.Models
{
    /// <summary>
    /// The ResponseModel class represents a standard structure for API responses, encapsulating the response body,
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// Represents the body of the response, typically containing data or information returned from an API endpoint.
        /// </summary>
        public string ResponseBody { set; get; }

        /// <summary>
        /// Represents the HTTP status code associated with the response, indicating the result of the API request.
        /// </summary>
        public HttpStatusCode StatusCode { set; get; }

        /// <summary>
        /// Represents a message providing additional context or information about the response, such as success or error details.
        /// </summary>
        public string Message { set; get; }
    }
}
