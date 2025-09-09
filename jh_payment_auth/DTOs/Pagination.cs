namespace jh_payment_auth.DTOs
{
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
