namespace jh_payment_auth.DTOs
{
    /// <summary>
    /// Represents a standardized response structure for API operations.
    /// </summary>
    /// <remarks>This class encapsulates the data returned by an API, including the main response data, 
    /// pagination details, status information, and any associated messages or errors.  It is designed to provide a
    /// consistent format for API responses, making it easier  for clients to parse and handle results.</remarks>
    public class ApiResponse
    {
        /// <summary>
        /// Gets or sets the data associated with the response.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the pagination details for the current data set.
        /// </summary>
        public Pagination Pagination { get; set; }

        /// <summary>
        /// Gets or sets the message associated with the current request or context.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the list of error messages associated with the current request.
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Gets or sets the HTTP status code associated with the response.
        /// </summary>
        public int StatusCode { get; set; }
    }    
}
