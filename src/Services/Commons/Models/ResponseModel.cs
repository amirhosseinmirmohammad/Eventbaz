namespace Commons.Models
{
    /// <summary>
    /// Represents a standard response model for API responses.
    /// </summary>
    /// <typeparam name="T">The type of data being returned in the response.</typeparam>
    public class ResponseModel<T>
    {
        /// <summary>
        /// The status code of the response.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// The data being returned in the response.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// A message describing the result of the operation.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Details about any exception that occurred during the operation.
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        /// Metadata for pagination details.
        /// </summary>
        public MetaData Meta { get; set; }

        /// <summary>
        /// Represents metadata for pagination.
        /// </summary>
        public class MetaData
        {
            /// <summary>
            /// The current page number.
            /// </summary>
            public int PageNumber { get; set; }

            /// <summary>
            /// The number of items per page.
            /// </summary>
            public int PageSize { get; set; }

            /// <summary>
            /// The total number of pages.
            /// </summary>
            public int PageCount { get; set; }

            /// <summary>
            /// The total number of records.
            /// </summary>
            public int RecordCount { get; set; }
        }
    }
}
