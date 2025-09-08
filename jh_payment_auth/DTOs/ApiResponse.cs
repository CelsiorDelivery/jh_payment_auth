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

    /// <summary>
    /// Represents pagination metadata for a collection of items.
    /// </summary>
    /// <remarks>This class provides information about the current page, the size of each page,  the total
    /// number of pages, and the total number of records in the collection.  It is typically used to support paginated
    /// data retrieval in APIs or data-driven applications.</remarks>
    public class Pagination
    {
        /// <summary>
        /// Gets or sets the current page number in a paginated collection.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the current page size in a paginated collection.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages available in the paginated collection.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the total number of records in the entire collection.
        /// </summary>
        public int TotalRecords { get; set; }
    }
}
